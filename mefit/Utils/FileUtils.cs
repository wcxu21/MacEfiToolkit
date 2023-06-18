﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// FileUtils.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Mac_EFI_Toolkit.Utils
{
    class FileUtils
    {

        /// <summary>
        /// Calculates the SHA256 hash of a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the hash for.</param>
        /// <returns>The SHA256 checksum of the byte array.</returns>
        internal static string GetSha256Digest(byte[] sourceBytes)
        {
            using (var provider = SHA256.Create())
            {
                var digestBytes = provider.ComputeHash(sourceBytes);
                return BitConverter.ToString(digestBytes).Replace("-", "");
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
        /// <param name="lSize">The number of bytes to format.</param>
        /// <returns>A string representation of the number of bytes with commas.</returns>
        internal static string FormatFileSize(long lSize)
        {
            return string.Format("{0:#,##0}", lSize);
        }

        /// <summary>
        /// Navigate to, and highlight a path in Windows Explorer.
        /// </summary>
        /// <param name="path">The path of the file to open in Windows Explorer.</param>
        internal static void HighlightPathInExplorer(string path)
        {
            Process.Start("explorer.exe", $"/select,\"{path}\"");
        }

        /// <summary>
        /// Checks if a given integer size is a valid size for a firmware image.
        /// </summary>
        /// <param name="size">The integer size to check.</param>
        /// <returns>True if the size is valid, otherwise false.</returns>
        internal static bool GetIsValidBinSize(long size)
        {
            int expectedSize = FWBase.MIN_IMAGE_SIZE;
            int maxSize = FWBase.MAX_IMAGE_SIZE;

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
            long closestSize = FWBase.MIN_IMAGE_SIZE;

            // Calculate the initial difference between the input size and the closest size
            long difference = Math.Abs(size - closestSize);

            // Iterate through the valid sizes to find the closest size
            while (closestSize <= FWBase.MAX_IMAGE_SIZE)
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

    }
}