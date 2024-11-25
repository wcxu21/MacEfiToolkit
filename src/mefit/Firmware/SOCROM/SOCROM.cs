﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// SOCROM.cs - Handles parsing of T2 SOCROM data
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Tools;
using System;
using System.Diagnostics;
using System.Text;

namespace Mac_EFI_Toolkit.Firmware.SOCROM
{
    internal class SOCROM
    {
        #region Internal Members
        internal static string LoadedBinaryPath = null;
        internal static byte[] LoadedBinaryBuffer = null;
        internal static bool FirmwareLoaded = false;
        internal static string iBootVersion = null;
        internal static string ConfigCode = null;
        internal static string NewSerial = null;

        internal static FileInfoStore FileInfoData;
        internal static SCfgStore SCfgSectionData;

        internal const int SCFG_EXPECTED_BASE = 0x28A000;
        internal const int SCFG_EXPECTED_LENGTH = 0xB8;
        internal const int SERIAL_LENGTH = 12;

        internal static TimeSpan ParseTime { get; private set; }
        #endregion

        #region Private Members
        private static readonly byte[] _t2RomMarker = { 0x30, 0x83 };
        #endregion

        #region Private Members
        const int _serialLength = 12;
        private static readonly byte[] _limitChars = new byte[] { 0x00, 0x00, 0x00 };
        private static readonly Encoding _utf8 = Encoding.UTF8;
        #endregion

        #region Parse Fimware
        internal static void LoadFirmwareBaseData(byte[] sourceBytes, string fileName)
        {
            // Start bench.
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Parse file info.
            FileInfoData = FileTools.GetBinaryFileInfo(fileName);

            // Parse iBoot version.
            iBootVersion = GetIbootVersion(sourceBytes);

            // Parse Scfg Store data.
            SCfgSectionData = GetSCfgData(sourceBytes, false);

            // Fetch the Config Code.
            ConfigCode = SCfgSectionData.HWC != null ? MacTools.GetDeviceConfigCodeLocal(SCfgSectionData.HWC) : null;

            stopwatch.Start();
            ParseTime = stopwatch.Elapsed;
        }

        internal static void ResetFirmwareBaseData()
        {
            LoadedBinaryPath = null;
            LoadedBinaryBuffer = null;
            FirmwareLoaded = false;
            FileInfoData = default;
            iBootVersion = null;
            ConfigCode = null;
            NewSerial = null;
            SCfgSectionData = default;
        }

        internal static bool IsValidImage(byte[] sourceBytes)
        {
            byte[] socromSignature = BinaryTools.GetBytesBaseLength(sourceBytes, 0, _t2RomMarker.Length);

            if (!BinaryTools.ByteArraysMatch(socromSignature, _t2RomMarker))
            {
                return false;
            }

            return (BinaryTools.GetBaseAddress(sourceBytes, IBOOT_VER_SIG, 0) != -1);
        }
        #endregion

        #region IBoot
        internal static string GetIbootVersion(byte[] source)
        {
            int ibootSig = BinaryTools.GetBaseAddress(source, IBOOT_VER_SIG, 0);

            if (ibootSig != -1) // Signature found
            {
                // Get byte containing data length
                byte[] lByte = BinaryTools.GetBytesBaseLength(source, ibootSig + IBOOT_VER_SIG.Length + 1, 1);

                // Convert data length to unsigned int8
                byte dataSize = (byte)lByte[0];

                // Get iboot version data bytes
                byte[] stringData = BinaryTools.GetBytesBaseLength(source, ibootSig + 0x6, dataSize);

                return _utf8.GetString(stringData);
            }

            return APPSTRINGS.UNKNOWN;
        }
        #endregion

        #region Scfg Store
        internal static SCfgStore GetSCfgData(byte[] sourceBytes, bool isScfgStoreOnly)
        {
            int scfgBase = FindScfgBaseAddress(sourceBytes, isScfgStoreOnly);

            if (scfgBase == -1)
            {
                return DefaultScfgData();
            }

            byte dataSize = BinaryTools.GetBytesBaseLength(sourceBytes, scfgBase + SCFG_HEADER_SIG.Length, 1)[0];

            if (dataSize == 0)
            {
                return DefaultScfgData();
            }

            byte[] scfgBytes = BinaryTools.GetBytesBaseLength(sourceBytes, scfgBase, dataSize);

            if (scfgBytes == null)
            {
                return DefaultScfgData();
            }

            int serialBase = BinaryTools.GetBaseAddress(sourceBytes, SCFG_SSN_SIG) + SCFG_SSN_SIG.Length;

            string serial = GetStringFromSig(scfgBytes, SCFG_SSN_SIG, _serialLength, out string hwc);
            string son = GetStringFromSigWithLimit(scfgBytes, SCFG_SON_SIG, _limitChars);
            string regno = GetStringFromSigWithLimit(scfgBytes, SCFG_SON_REGN, _limitChars);
            string crc = $"{FileTools.GetCrc32Digest(scfgBytes):X8}";

            return new SCfgStore
            {
                StoreBase = scfgBase,
                StoreSize = dataSize,
                StoreBuffer = scfgBytes,
                Serial = serial,
                SerialBase = serialBase,
                HWC = hwc,
                SON = son,
                StoreCRC = crc,
                MdlC = null,
                RegNumText = regno
            };
        }

        private static int FindScfgBaseAddress(byte[] sourceBytes, bool isScfgStoreOnly)
        {
            if (isScfgStoreOnly)
            {
                return 0;
            }

            return BinaryTools.GetBaseAddress(sourceBytes, SCFG_HEADER_SIG);
        }

        private static string GetStringFromSig(byte[] scfgBytes, byte[] sig, int expectedLength, out string hwc)
        {
            hwc = null;

            int baseAddress = BinaryTools.GetBaseAddress(scfgBytes, sig);

            if (baseAddress == -1)
            {
                return null;
            }

            byte[] bytes = BinaryTools.GetBytesBaseLength(scfgBytes, baseAddress + sig.Length, expectedLength);

            if (bytes?.Length != expectedLength)
            {
                return null;
            }

            string serial = _utf8.GetString(bytes);

            hwc = serial.Length >= 4 ? serial.Substring(serial.Length - 4, 4) : null;

            return serial;
        }

        private static string GetStringFromSigWithLimit(byte[] scfgBytes, byte[] sig, byte[] limitChars)
        {
            int baseAddress = BinaryTools.GetBaseAddress(scfgBytes, sig);

            if (baseAddress == -1)
            {
                return null;
            }

            baseAddress += sig.Length;

            int limit = BinaryTools.GetBaseAddress(scfgBytes, limitChars, baseAddress);

            if (limit == -1)
            {
                return null;
            }

            byte[] bytes = BinaryTools.GetBytesBaseLimit(scfgBytes, baseAddress, limit);

            return _utf8.GetString(bytes);
        }

        private static SCfgStore DefaultScfgData()
        {
            return new SCfgStore
            {
                StoreBase = -1,
                StoreSize = 0,
                StoreBuffer = null,
                StoreCRC = null,
                Serial = null,
                HWC = null,
                SON = null,
                MdlC = null,
                RegNumText = null
            };
        }

        // iBoot version signature, byte 5 is validity byte?, byte 6 is var size.
        internal static readonly byte[] IBOOT_VER_SIG =
        {
            0x69, 0x6C, 0X6C, 0X62
        };

        // Header.
        internal static readonly byte[] SCFG_HEADER_SIG =
        {
            0x67, 0x66, 0x43, 0x53
        };

        // System Serial Number.
        internal static readonly byte[] SCFG_SSN_SIG =
        {
            0x6D, 0x4E, 0x72, 0x53
        };

        // System Order Number.
        internal static readonly byte[] SCFG_SON_SIG =
        {
            0x23, 0x64, 0x6F, 0x4D
        };

        // Registration Number?
        internal static readonly byte[] SCFG_SON_REGN =
        {
            0x6E, 0x67, 0x65, 0x52
        };
        #endregion
    }
}