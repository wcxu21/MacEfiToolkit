﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// mainWindow.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.UI.Renderers;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using Mac_EFI_Toolkit.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit
{
    public partial class mainWindow : Form
    {
        internal byte[] bytesLoadedFile;
        internal byte[] bytesFsys;
        internal byte[] bytesDxeCompressed;

        internal uint uintCrcOfLoadedFile;
        internal long lngFilesize;
        internal long lngFsysOffset;

        #region Private Members
        private string strInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string strLoadedBinaryFilePath;
        private string strFilenameWithoutExt;
        private string strCreationTime;
        private string strModifiedTime;
        private string strRememberPath;
        private string strFilename;
        private string strSerialNumber;
        private string strHwc;
        private string strEfiVer;
        private string strBootrom;
        private string strApfsCapable;
        private string strFsysChecksumInBinary;
        private string strFsysCalculation;
        private string strFitcVersion;
        private string strMeVersion;
        private string strBoardId;
        private string strSon;
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.Style |= Program.WS_MINIMIZEBOX;
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Window Events
        public mainWindow()
        {
            InitializeComponent();

            lblMessage.Hide();

            Load += mainWindow_Load;
            Shown += mainWindow_Shown;
            FormClosing += mainWindow_FormClosing;
            KeyDown += mainWindow_KeyDown;

            tlpMain.MouseMove += Move_Form;
            tlpMainIcon.MouseMove += Move_Form;
            lblWindowTitle.MouseMove += Move_Form;

            CreateTipHandlers();

            cmsMainMenu.Renderer = new METMenuRenderer();
            cmsApplication.Renderer = new METMenuRenderer();
            cmsFsysMenu.Renderer = new METMenuRenderer();

            cmdMenu.Font = Program.FONT_MDL2_REG_14;
            cmdMenu.Text = "\xE169";
            cmdExportFsysBlock.Font = Program.FONT_MDL2_REG_9;
            cmdExportFsysBlock.Text = "\xE74E";
            cmdFixFsysCrc.Font = Program.FONT_MDL2_REG_9;
            cmdFixFsysCrc.Text = "\xE90F";
            cmdEveryMacSearch.Font = Program.FONT_MDL2_REG_9;
            cmdEveryMacSearch.Text = "\xF6FA";
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            var dbgMode = false;
#if DEBUG
            dbgMode = true;
#endif

            ToggleControlEnable(false);

            lblVersion.Text = Application.ProductVersion;

            if (!Settings._settingsGetBool(SettingsBoolType.DisableVersionCheck))
            {
                if (!dbgMode) CheckForNewVersion();
            }

        }

        private void mainWindow_Shown(object sender, EventArgs e)
        {
            InterfaceUtils.FlashForecolor(cmdOpenBin);
        }

        internal async void CheckForNewVersion()
        {
            var result = await METVersion.CheckForUpdate("https://raw.githubusercontent.com/MuertoGB/MacEfiToolkit/main/files/app/version.xml");

            if (result == VersionCheckResult.NewVersionAvailable)
            {
                lblVersion.ForeColor = Color.Tomato;
                lblVersion.Cursor = Cursors.Hand;
                lblVersion.Click += lblVersion_Click;
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                // We need to cancel the original request to close first, otherwise ExitMet() will close the application regardless of user choice.
                if (!Settings._settingsGetBool(SettingsBoolType.DisableConfDiag))
                {
                    e.Cancel = true;
                }

                Program.ExitMet(this);
            }
        }
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O) cmdOpenBin.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R) cmdReset.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E) cmdExportFsysBlock.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C) cmdEveryMacSearch.PerformClick();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.M) ShowContextMenu(cmdMenu, cmsMainMenu);
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) using (var frm = new settingsWindow()) frm.Show();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A) using (var frm = new aboutWindow()) frm.Show();
        }
        #endregion

        #region Mouse Events
        private void Move_Form(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(new HandleRef(this, Handle));
                NativeMethods.SendMessage(new HandleRef(this, Handle), Program.WM_NCLBUTTONDOWN, (IntPtr)Program.HT_CAPTION, (IntPtr)0);
            }
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Program.ExitMet(this);
        }

        private void cmdMin_Click(object sender, EventArgs e)
        {
            MinimizeWindow();
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsMainMenu);
        }

        private void cmdOpenBin_Click(object sender, EventArgs e)
        {
            string initialDirectory;

            if (!string.IsNullOrEmpty(strRememberPath))
            {
                initialDirectory = strRememberPath;
            }
            else
            {
                initialDirectory = Settings._settingsGetString(SettingsStringType.InitialDirectory);
                if (string.IsNullOrEmpty(initialDirectory) || !Directory.Exists(initialDirectory))
                {
                    initialDirectory = strInitialDirectory;
                }
            }

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = initialDirectory,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    strLoadedBinaryFilePath = dialog.FileName;
                    strFilenameWithoutExt = Path.GetFileNameWithoutExtension(dialog.FileName);
                    bytesLoadedFile = File.ReadAllBytes(strLoadedBinaryFilePath);
                    var fsysOut = FirmwareParser._byteGetFsysBlock(bytesLoadedFile, true);
                    bytesFsys = fsysOut.BlockBytes; lngFsysOffset = fsysOut.Offset;
                    if (boolIsValidFirmware())
                    {
                        ToggleControlEnable(false);
                        strInitialDirectory = strLoadedBinaryFilePath;
                        strRememberPath = strLoadedBinaryFilePath;
                        LoadEfiData();
                    }
                    else
                    {
                        strLoadedBinaryFilePath = string.Empty;
                        ResetData();
                    }
                }
            }
        }

        private void cmdResetUnload_Click(object sender, EventArgs e)
        {
            if (Settings._settingsGetBool(SettingsBoolType.DisableConfDiag))
            {
                ResetData();
            }
            else
            {
                var result = METMessageBox.Show(this, "Reset", "This will clear all data, and unload the binary.\r\nAre you sure you want to reset?", MsgType.Warning, MsgButton.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        ResetData();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void cmdSerialCheck_Click(object sender, EventArgs e)
        {
            // Opens a browser window to EveryMac, and automatically loads in the serial.
            Process.Start(string.Concat("https://everymac.com/ultimate-mac-lookup/?search_keywords=", strSerialNumber));
        }

        private void cmdExportFsysBlock_Click(object sender, EventArgs e)
        {
            if (bytesFsys == null)
            {
                MessageBox.Show("Fsys block bytes[] empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Export Fsys block data...",
                FileName = string.Concat("FSYS_RGN_", strFilenameWithoutExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = strRememberPath
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                File.WriteAllBytes(dialog.FileName, bytesFsys);
            }
        }

        private void cmdFixFsysCrc_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Export repaired binary...",
                FileName = string.Concat("FSYS_Fixed_", strFilenameWithoutExt, ".bin"),
                OverwritePrompt = true,
                InitialDirectory = strRememberPath
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                int len = 0x7FC;
                byte[] bytesTempFsys = new byte[len];
                Array.Copy(bytesFsys, bytesTempFsys, Math.Min(bytesFsys.Length, len));
                uint uintNewCrc = FileUtils._uintGetCrc32FromBytes(bytesTempFsys);
                byte[] newCrc = BitConverter.GetBytes(uintNewCrc);
                BinaryUtils.OverwriteBytesAtOffset(bytesLoadedFile, lngFsysOffset + len, newCrc);

                File.WriteAllBytes(dialog.FileName, bytesLoadedFile);

                if (File.Exists(dialog.FileName))
                {
                    DialogResult result = METMessageBox.Show(this, "File Saved", "New file saved. Would you like to load the new file?", MsgType.Information, MsgButton.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        ReloadData(dialog.FileName);
                    }
                }
            }
        }
        #endregion

        #region Toolstrip Events

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Logger.logFilePath))
            {
                Process.Start(Logger.logFilePath);
            }
            else
            {
                METMessageBox.Show(this, "File Information", "The log file was not detected, it has not yet been created.", MsgType.Information, MsgButton.Okay);
            }
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.RestartMet(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form frm = new settingsWindow()) frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form frm = new aboutWindow()) frm.ShowDialog();
        }

        private void MinimizeWindow()
        {
            WindowState = FormWindowState.Minimized;
        }

        private void resetPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void restartApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.RestartMet(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ExitMet(this);
        }
        #endregion

        #region Label Events
        private void lblVersion_Click(object sender, EventArgs e)
        {
            Process.Start(METVersion.latestUrl);
        }

        private void CreateTipHandlers()
        {
            cmdExportFsysBlock.MouseEnter += HandleMouseEnterTip;
            cmdExportFsysBlock.MouseLeave += HandleMouseLeaveTip;
            cmdFixFsysCrc.MouseEnter += HandleMouseEnterTip;
            cmdFixFsysCrc.MouseLeave += HandleMouseLeaveTip;
            cmdEveryMacSearch.MouseEnter += HandleMouseEnterTip;
            cmdEveryMacSearch.MouseLeave += HandleMouseLeaveTip;
            cmdOpenBin.MouseEnter += HandleMouseEnterTip;
            cmdOpenBin.MouseLeave += HandleMouseLeaveTip;
            cmdReset.MouseEnter += HandleMouseEnterTip;
            cmdReset.MouseLeave += HandleMouseLeaveTip;
            cmdEditEfirom.MouseEnter += HandleMouseEnterTip;
            cmdEditEfirom.MouseLeave += HandleMouseLeaveTip;
        }

        private void HandleMouseEnterTip(object sender, EventArgs e)
        {
            if (sender == cmdExportFsysBlock)
                lblMessage.Text = "Export Fsys block to disk...";
            else if (sender == cmdFixFsysCrc)
                lblMessage.Text = "Repair Fsys CRC32...";
            else if (sender == cmdEveryMacSearch)
                lblMessage.Text = "View serial number information on EveryMac...";
            else if (sender == cmdOpenBin)
                lblMessage.Text = "Open a Mac EFIROM...";
            else if (sender == cmdReset)
                lblMessage.Text = "Unload EFIROM and clear all data...";
            else if (sender == cmdEditEfirom)
                lblMessage.Text = "Edit serial number, clear NVRAM, etc...";

            lblMessage.Show();
        }

        private void HandleMouseLeaveTip(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            lblMessage.Hide();
        }
        #endregion

        #region Picturebox Events
        private void pbxTitleLogo_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ShowContextMenu(control, cmsApplication);
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MinimizeWindow();
        }
        #endregion

        #region Window Events

        private void ShowContextMenu(Control control, ContextMenuStrip menu)
        {
            Point ptLowerLeft = new Point(-1, control.Height + 2);
            ptLowerLeft = control.PointToScreen(ptLowerLeft);
            menu.Show(ptLowerLeft);
        }
        #endregion

        #region Firmware Parsing

        internal bool boolIsValidFirmware()
        {
            FileInfo fInfo = new FileInfo(strLoadedBinaryFilePath);
            // Binary too small? Potential bug here.
            if (fInfo.Length < FirmwareParser.intMinRomSize) // 1048576 bytes
            {
                METMessageBox.Show(this, "File Error", "File ignored, the file was too small.", MsgType.Warning, MsgButton.Okay);
                return false;
            }
            // Binary too large, no Mac EFI is this big.
            if (fInfo.Length > FirmwareParser.intMaxRomSize) // 33554432 bytes
            {
                METMessageBox.Show(this, "File Error", "File ignored, the file was too large.", MsgType.Warning, MsgButton.Okay);
                return false;
            }

            if (!Settings._settingsGetBool(SettingsBoolType.DisableDescriptorEnforce))
            {
                if (!FirmwareParser._boolIsValidFlashHeader(bytesLoadedFile))
                {
                    METMessageBox.Show(this, "File Error", "File ignored, the flash descriptor signature was invalid.", MsgType.Warning, MsgButton.Okay);
                    return false;
                }
            }

            if (!Settings._settingsGetBool(SettingsBoolType.DisableFsysEnforce))
            {
                if (bytesFsys == null)
                {
                    METMessageBox.Show(this, "Data Error", "Could not locate the Fsys block, the file was not loaded.", MsgType.Warning, MsgButton.Okay);
                    return false;
                }
            }
            return true;
        }

        internal void LoadEfiData()
        {
            var fileInfo = new FileInfo(strLoadedBinaryFilePath);
            DateTime creationTime = fileInfo.CreationTime;
            DateTime modifiedTime = fileInfo.LastWriteTime;

            // Filename
            strFilename = Path.GetFileName(strLoadedBinaryFilePath);
            // Size
            lngFilesize = FileUtils._longGetFileSizeBytes(strLoadedBinaryFilePath);
            // File CRC32
            uintCrcOfLoadedFile = FileUtils._uintGetCrc32FromBytes(bytesLoadedFile);
            // Created time
            strCreationTime = $"{creationTime}";
            // Modified time
            strModifiedTime = $"{modifiedTime}";
            // Serial number
            strSerialNumber = FirmwareParser._stringGetFsysSerialNumber(bytesFsys);
            // HWC
            strHwc = FirmwareParser._stringGetFsysHwc(bytesFsys);
            // EFI Version
            strEfiVer = FirmwareParser._stingGetEfiVersionFromAppleRomSection(bytesLoadedFile);
            // ROM version
            strBootrom = FirmwareParser._stringGetBootromVersionFromAppleRomSection(bytesLoadedFile);
            // Fsys CRC32 string
            strFsysChecksumInBinary = FirmwareParser._stringGetFsysCrc32(bytesLoadedFile);
            // Fsys CRC32
            byte[] bytesTempFsys = new byte[0x7FC];
            if (bytesFsys != null) Array.Copy(bytesFsys, 0, bytesTempFsys, 0, bytesTempFsys.Length);
            strFsysCalculation = FileUtils._uintGetCrc32FromBytes(bytesTempFsys).ToString("X8");
            // APFSJumpStart
            strApfsCapable = $"{ FirmwareParser._getIsApfsCapable(bytesLoadedFile) }";
            // FITC
            strFitcVersion = MEParser._stringGetFitcVersion(bytesLoadedFile);
            //ME
            strMeVersion = MEParser._stringGetMeVersion(bytesLoadedFile);
            // Get the BoardId
            strBoardId = FirmwareParser._stringGetPdrBoardId(bytesLoadedFile);
            // SON
            strSon = FirmwareParser._stringGetFsysSon(bytesFsys);

            UpdateControls();
        }

        internal void UpdateControls()
        {
            lblFilename.Text = $"· {strFilename}";
            lblFilesizeBytes.ForeColor = EFIUtils._boolGetIsValidBinarySize((int)lngFilesize) ? Colours.clrGood : Colours.clrUnknown;
            lblFilesizeBytes.Text = FileUtils._stringFormatBytesWithCommas(FileUtils._longGetFileSizeBytes(strLoadedBinaryFilePath));
            lblCreated.Text = strCreationTime;
            lblModified.Text = strModifiedTime;
            lblFileChecksum.Text = uintCrcOfLoadedFile.ToString("X8");
            lblFsysCrc.Text = $"{ strFsysChecksumInBinary }h";
            lblFsysCrc.ForeColor = (strFsysCalculation == strFsysChecksumInBinary) ? lblFsysCrc.ForeColor = Colours.clrGood : lblFsysCrc.ForeColor = Colours.clrError;
            cmdFixFsysCrc.Enabled = (strFsysCalculation == strFsysChecksumInBinary) ? false : true;
            lblApfsCapable.Text = strApfsCapable;
            if (strApfsCapable == "Yes") lblApfsCapable.ForeColor = Colours.clrGood; else lblApfsCapable.ForeColor = Colours.clrUnknown;
            CheckHwcAsync(strHwc);
            lblSerialNumber.Text = strSerialNumber;
            lblHwc.Text = strHwc;
            lblEfiVersion.Text = strEfiVer;
            lblRomVersion.Text = strBootrom;
            lblFitcVersion.Text = strFitcVersion;
            lblMeVersion.Text = strMeVersion;
            lblBoardId.Text = strBoardId;
            lblSon.Text = strSon;

            ToggleControlEnable(true);
        }

        internal async void CheckHwcAsync(string strHwc)
        {
            var configCode = await EFIUtils._stringGetConfigCodeAsync(strHwc);
            lblConfig.Text = $"· {configCode}";
        }
        #endregion

        #region Reset / Reload
        private void ResetData()
        {
            // Clear labels
            Label[] labels =
            {
                lblFilename, lblFileChecksum, lblFilesizeBytes, lblCreated, lblModified,
                lblConfig, lblSerialNumber, lblHwc, lblEfiVersion, lblRomVersion,
                lblFsysCrc, lblApfsCapable, lblFitcVersion, lblMeVersion, lblBoardId,
                lblSon
            };
            foreach (Label label in labels)
            {
                label.Text = string.Empty;
                label.ForeColor = Color.White;
            }

            // Clear strings
            string[] strFields =
            {
                strLoadedBinaryFilePath, strFilenameWithoutExt, strCreationTime, strModifiedTime,
                strRememberPath, strFilename, strSerialNumber, strHwc, strEfiVer, strBootrom,
                strApfsCapable, strFsysChecksumInBinary, strFsysCalculation, strFitcVersion,
                strMeVersion, strBoardId, strSon
            };
            for (int i = 0; i < strFields.Length; i++)
            {
                strFields[i] = string.Empty;
            }

            // Clear byte arrays
            byte[][] byteFields =
            {
                bytesLoadedFile, bytesFsys, bytesDxeCompressed
            };
            for (int i = 0; i < byteFields.Length; i++)
            {
                byteFields[i] = null;
            }

            // Clear the large object heap
            GC.Collect();
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                if (GC.WaitForFullGCComplete() == GCNotificationStatus.Succeeded)
                {
                    GC.WaitForPendingFinalizers();
                }
            }

            // Clear the integers
            uintCrcOfLoadedFile = 0;
            lngFilesize = 0;
            lngFsysOffset = 0;

            // Disable controls
            ToggleControlEnable(false);
        }

        private void ToggleControlEnable(bool Enable)
        {
            Button[] buttons = { cmdReset, cmdExportFsysBlock, cmdEveryMacSearch };
            tlpMain.Enabled = Enable;
            foreach (Button button in buttons)
            {
                button.Enabled = (Enable) ? true : false;
            }
        }

        private void ReloadData(string filePath)
        {
            strFilenameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            bytesLoadedFile = File.ReadAllBytes(filePath);
            var fsysOut = FirmwareParser._byteGetFsysBlock(bytesLoadedFile, true);
            bytesFsys = fsysOut.BlockBytes; lngFsysOffset = fsysOut.Offset;
            if (boolIsValidFirmware())
            {
                ToggleControlEnable(false);
                strInitialDirectory = strLoadedBinaryFilePath;
                strRememberPath = strLoadedBinaryFilePath;
                LoadEfiData();
            }
            else
            {
                strLoadedBinaryFilePath = string.Empty;
                ResetData();
            }
        }
        #endregion

    }
}