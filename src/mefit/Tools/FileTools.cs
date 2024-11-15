﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FileTools.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Firmware;
using Mac_EFI_Toolkit.UI;
using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Windows.Forms;

#region Enum
enum Status
{
    SUCCESS,
    FAILED
}
#endregion

namespace Mac_EFI_Toolkit.Tools
{
    class FileTools
    {
        /// <summary>
        /// Calculates the SHA256 hash of a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the hash for.</param>
        /// <returns>The SHA256 checksum of the byte array.</returns>
        internal static string GetSha256Digest(byte[] sourceBytes)
        {
            using (SHA256 provider = SHA256.Create())
            {
                byte[] digestBytes = provider.ComputeHash(sourceBytes);

                return BitConverter.ToString(digestBytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Calculates the CRC32 checksum of a byte array. 
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the checksum for.</param>
        /// <returns>The CRC32 checksum of the byte array.</returns>
        internal static uint GetCrc32Digest(byte[] sourceBytes)
        {
            const uint polynomial = 0xEDB88320;
            uint crc = 0xFFFFFFFF;

            for (int i = 0; i < sourceBytes.Length; i++)
            {
                crc ^= sourceBytes[i];

                for (int j = 0; j < 8; j++)
                {
                    crc = (uint)((crc >> 1) ^ (polynomial & -(crc & 1)));
                }
            }

            return crc ^ 0xFFFFFFFF;
        }

        /// <summary>
        /// Formats a number of bytes as a string with commas.
        /// </summary>
        /// <param name="size">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        internal static string FormatFileSize(long size)
        {
            return string.Format("{0:#,##0}", size);
        }

        /// <summary>
        /// Checks if a given integer size is a valid size for a firmware image.
        /// </summary>
        /// <param name="size">The integer size to check.</param>
        /// <returns>True if the size is valid, otherwise false.</returns>
        internal static bool GetIsValidBinSize(long size)
        {
            int expectedSize = FirmwareVars.MIN_IMAGE_SIZE;
            int maxSize = FirmwareVars.MAX_IMAGE_SIZE;

            while (expectedSize <= maxSize)
            {
                if (size == expectedSize)
                {
                    return true;
                }

                expectedSize *= 2;
            }

            return false;
        }

        /// <summary>
        /// Calculates the difference between the input size and the closest valid size,
        /// and returns a formatted string indicating whether the size is too large or too small,
        /// along with the byte difference.
        /// </summary>
        /// <param name="size">The input size to compare against valid sizes.</param>
        /// <returns>A formatted string indicating whether the size is too large or too small,
        /// along with the byte difference.</returns>
        internal static string GetSizeDifference(long size)
        {
            // Initialize the closest size with the minimum image size
            long closestSize = FirmwareVars.MIN_IMAGE_SIZE;

            // Calculate the initial difference between the input size and the closest size
            long difference = Math.Abs(size - closestSize);

            // Iterate through the valid sizes to find the closest size
            while (closestSize <= FirmwareVars.MAX_IMAGE_SIZE)
            {
                // Calculate the doubled size and its difference from the input size
                long doubledSize = closestSize * 2;

                long doubledDifference = Math.Abs(size - doubledSize);

                // If the doubled difference is smaller, update the closest size and difference
                if (doubledDifference < difference)
                {
                    closestSize = doubledSize;
                    difference = doubledDifference;
                }
                else
                {
                    // Exit the loop if the doubled difference becomes larger
                    break;
                }
            }

            // Check if the input size is smaller than the closest size
            if (size < closestSize)
            {
                // Return a formatted string indicating the size is too small
                return $"<{difference}";
            }
            // Check if the input size is larger than the closest size
            else if (size > closestSize)
            {
                // Return a formatted string indicating the size is too large
                return $">{difference}";
            }
            else
            {
                // Return a string indicating an exact match
                return "Valid";
            }
        }

        /// <summary>
        /// Writes the specified byte array to the file at the given path and verifies the integrity of the written data.
        /// </summary>
        /// <param name="path">The path of the file to write.</param>
        /// <param name="sourceBytes">The byte array containing the data to be written.</param>
        /// <returns>True if the data was written successfully and integrity is verified; otherwise, false.</returns>
        internal static bool WriteAllBytesEx(string path, byte[] sourceBytes)
        {
            try
            {
                File.WriteAllBytes(path, sourceBytes);

                byte[] fileBytes = File.ReadAllBytes(path);

                return BinaryTools.ByteArraysMatch(sourceBytes, fileBytes);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(WriteAllBytesEx), e.GetType(), e.Message);
                return false;
            }
        }


        /// <summary>
        /// Creates a directory at the specified path.
        /// </summary>
        /// <param name="directory">The path of the directory to create.</param>
        /// <returns>
        /// The status of the directory creation operation. Returns <see cref="Status.SUCCESS"/> if the directory is successfully created,
        /// or <see cref="Status.FAILED"/> if the creation fails.
        /// </returns>
        internal static Status CreateDirectory(string directory)
        {
            Directory.CreateDirectory(directory);

            if (Directory.Exists(directory))
                return Status.SUCCESS;

            return Status.FAILED;
        }

        /// <summary>
        /// Backs up a byte array to a zip file.
        /// </summary>
        /// <param name="sourceBytes">The byte array to be backed up.</param>
        /// <param name="entryName">The name of the entry to be created within the zip archive.</param>
        /// <param name="path">The path of the zip file to be created.</param>
        internal static void BackupFileToZip(byte[] sourceBytes, string entryName, string path)
        {
            try
            {
                using (FileStream zipStream = new FileStream(path, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry fileEntry = archive.CreateEntry(entryName);

                    using (Stream fileStream = fileEntry.Open())
                    {
                        fileStream.Write(sourceBytes, 0, sourceBytes.Length);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLine(nameof(BackupFileToZip), e.GetType(), e.Message);
            }
        }

        /// <summary>
        /// Retrieves file information and calculates the CRC32 checksum of a specified file.
        /// </summary>
        /// <param name="fileName">The full path to the file to be analyzed.</param>
        /// <returns>
        /// A Binary object containing the file's name, name without extension, creation time, last write time, file length, and CRC32 checksum.
        /// </returns>
        internal static FileInfoStore GetBinaryFileInfo(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            byte[] fileBytes = File.ReadAllBytes(fileInfo.FullName);

            return new FileInfoStore
            {
                FileNameExt = fileInfo.Name,
                FileName = Path.GetFileNameWithoutExtension(fileName),
                CreationTime = fileInfo.CreationTime.ToString(),
                LastWriteTime = fileInfo.LastWriteTime.ToString(),
                Length = (int)fileInfo.Length,
                CRC32 = FileTools.GetCrc32Digest(fileBytes)
            };
        }

        internal static bool IsValidMinMaxSize(string filePath, Form owner)
        {
            long fileSize = new FileInfo(filePath).Length;

            if (fileSize < FirmwareVars.MIN_IMAGE_SIZE || fileSize > FirmwareVars.MAX_IMAGE_SIZE)
            {
                string message = fileSize < FirmwareVars.MIN_IMAGE_SIZE
                    ? $"The selected file does not meet the minimum size requirement of {FirmwareVars.MIN_IMAGE_SIZE:X}h."
                    : $"The selected file exceeds the maximum size limit of {FirmwareVars.MAX_IMAGE_SIZE:X}h.";

                METPrompt.Show(
                    owner,
                    message,
                    METPromptType.Error,
                    METPromptButtons.Okay);

                return false;
            }

            return true;
        }
    }
}