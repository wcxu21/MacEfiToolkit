﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Logger.cs - Handles logging of data to .txt file
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{

    #region Enum
    internal enum LogType
    {
        Application,
        Database
    }

    public enum RtbLogPrefix
    {
        Good,
        Info,
        Warn,
        Error
    }
    #endregion

    class Logger
    {
        internal static string strLogFilePath = Path.Combine(Program.appDirectory, "mefit.log");
        internal static string strDbReportPath = Path.Combine(Program.appDirectory, "dbreport.log");

        internal static void WriteToLogFile(string logMessage, LogType logType)
        {
            var pathString = GetLogFilePath(logType);

            using (var writer = new StreamWriter(pathString, true))
            {
                writer.WriteLine($"{DateTime.Now} : {logMessage}");
            }
        }

        internal static void ViewLogFile(LogType logType)
        {
            var pathString = GetLogFilePath(logType);

            if (File.Exists(pathString))
            {
                Process.Start(pathString);
            }
        }

        private static string GetLogFilePath(LogType logType)
        {
            string pathString;

            switch (logType)
            {
                case LogType.Application:
                    pathString = strLogFilePath;
                    break;
                case LogType.Database:
                    pathString = strDbReportPath;
                    break;
                default:
                    pathString = strLogFilePath;
                    break;
            }

            return pathString;
        }

        internal static void WriteLogTextToRtb(string messageString, RtbLogPrefix logPrefix, RichTextBox richTextBox)
        {
            Color prefixColor;
            string timestamp = $"{DateTime.Now:HH:mm:ss}: ";

            switch (logPrefix)
            {
                case RtbLogPrefix.Good:
                    prefixColor = Color.FromArgb(0, 200, 0);
                    break;
                case RtbLogPrefix.Info:
                    prefixColor = Color.FromArgb(0, 122, 204);
                    break;
                case RtbLogPrefix.Warn:
                    prefixColor = Color.FromArgb(255, 165, 0);
                    break;
                case RtbLogPrefix.Error:
                    prefixColor = Color.FromArgb(255, 51, 51);
                    break;
                default:
                    prefixColor = Color.White;
                    break;
            }

            richTextBox.AppendText(timestamp);
            richTextBox.Select(richTextBox.TextLength - timestamp.Length, timestamp.Length - 1);
            richTextBox.SelectionColor = prefixColor;
            richTextBox.AppendText(messageString + Environment.NewLine);
            richTextBox.ScrollToCaret();
        }

    }
}