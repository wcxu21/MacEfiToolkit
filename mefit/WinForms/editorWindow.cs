﻿// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// WinForms
// editorWindow.cs
// Released under the GNU GLP v3.0
// Yes, the code is messy, it's far from complete and unoptimised, stop crying.

using Mac_EFI_Toolkit.Common;
using Mac_EFI_Toolkit.UI;
using Mac_EFI_Toolkit.Utils;
using Mac_EFI_Toolkit.WIN32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mac_EFI_Toolkit.WinForms
{
    public partial class editorWindow : Form
    {

        #region Private Members
        private byte[] _bytesNewFsysRegion = null;
        private byte[] _bytesNewBinary = null;
        private bool _maskCrc = false;
        private bool _buildFailed = false;
        private string _fullBuildPath = string.Empty;
        private readonly string _strChevronRight = "\xE76C";
        #endregion

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;
                Params.ClassStyle = Params.ClassStyle | Program.CS_DBLCLKS | Program.CS_DROP;
                return Params;
            }
        }
        #endregion

        #region Constructor
        public editorWindow()
        {
            InitializeComponent();

            Load += mainWindow_Load;
            lblTitle.MouseMove += editorWindow_MouseMove;

            var font = Program.FONT_MDL2_REG_9;
            var chevronRight = _strChevronRight;
            SetLabelProperties(lblSvsChevRight, font, chevronRight);
            SetLabelProperties(lblVssChevRight, font, chevronRight);
            SetLabelProperties(lblNssChevRight, font, chevronRight);

            SetButtonProperties();
        }
        #endregion

        #region Window Events
        private void mainWindow_Load(object sender, EventArgs e)
        {
            tbxSerialNumber.MaxLength = FWBase.FsysSectionData.Serial.Length;

            Logger.WriteLogTextToRtb($"{DateTime.Now}", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"The editor is unfinished, use caution!", RtbLogPrefix.Warn, rtbLog);

            LogLoadedBinarySize();
            LogFsysData();

            Logger.WriteLogTextToRtb($"Initial checks complete", RtbLogPrefix.Good, rtbLog);
        }
        #endregion

        #region Mouse Events
        private void editorWindow_MouseMove(object sender, MouseEventArgs e)
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
            Close();
        }
        private void cmdOpenBuildsDir_Click(object sender, EventArgs e)
        {
            Program.CreateCheckBuildsFolder();
            Process.Start("explorer.exe", Program.buildsDirectory);
        }

        private void cmdFsysPath_Click(object sender, EventArgs e)
        {
            Program.CheckCreateFsysFolder();

            using (var dialog = new OpenFileDialog
            {
                InitialDirectory = Program.fsysDirectory,
                Filter = "Binary Files (*.rom, *.bin)|*.rom;*.bin|All Files (*.*)|*.*"
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    cbxReplaceFsysRgn.Checked = false;
                    return;
                }

                Logger.WriteLogTextToRtb($"Opening '{dialog.FileName}'", RtbLogPrefix.Info, rtbLog);
                _bytesNewFsysRegion = File.ReadAllBytes(dialog.FileName);
                bool isValid = ValidateNewFsysRegion(_bytesNewFsysRegion);
                if (!isValid) cbxReplaceFsysRgn.Checked = false;
            }
        }

        private void cmdBuild_Click(object sender, EventArgs e)
        {
            ToggleControlEnable(false);

            _bytesNewBinary = FWBase.LoadedBinaryBytes;

            if (cbxReplaceFsysRgn.Checked)
            {
                PatchFsys();
            }

            //if (cbxReplaceSerial.Checked)
            //{
            //    Logger.WriteLogTextToRtb($"Replacing serial number...", RtbLogPrefix.MET, rtbLog);
            //}

            if (cbxClearVssStore.Checked)
            {
                Logger.WriteLogTextToRtb($"Clearing VSS NVRAM Data:", RtbLogPrefix.Info, rtbLog);
                ClearVssStores(cbxClearVssBackup.Checked);
            }

            //if (cbxClearSvsStore.Checked)
            //{
            //    Logger.WriteLogTextToRtb($"Clearing VSS store...", RtbLogPrefix.MET, rtbLog);
            //}

            //if (cbxClearNssStore.Checked)
            //{
            //    Logger.WriteLogTextToRtb($"Clearing VSS store...", RtbLogPrefix.MET, rtbLog);
            //}

            // If the build fails, disallow exporting.
            if (!_buildFailed)
            {
                Logger.WriteLogTextToRtb($"BUILD SUCCEEDED.", RtbLogPrefix.Good, rtbLog);

                var filename = $"outimage_{DateTime.Now:yyMMdd_HHmmss}.bin";

                Program.CreateCheckBuildsFolder();

                _fullBuildPath = Path.Combine(Program.buildsDirectory, filename);

                File.WriteAllBytes(_fullBuildPath, _bytesNewBinary);
                Logger.WriteLogTextToRtb($"Save path: {_fullBuildPath}", RtbLogPrefix.Info, rtbLog);

                var shaNewBinary = FileUtils.GetSha256Digest(_bytesNewBinary);
                var outFileBytes = File.ReadAllBytes(_fullBuildPath);
                var shaOutFile = FileUtils.GetSha256Digest(outFileBytes);

                if (string.Equals(shaNewBinary, shaOutFile))
                {
                    Logger.WriteLogTextToRtb($"Written file checksum is good, export successful!", RtbLogPrefix.Good, rtbLog);
                }
                else
                {
                    Logger.WriteLogTextToRtb($"Written file checksum is bad, export was not successful!", RtbLogPrefix.Error, rtbLog);
                }
            }

            ToggleControlEnable(true);
        }
        #endregion

        #region Checkbox Events

        private void cbxClearVssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

                lblVssChevRight.Visible = cb.Checked;
                cbxClearVssBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearVssBackup.Checked = false;
            }
        }

        private void cbxClearSvsRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

                lblSvsChevRight.Visible = cb.Checked;
                cbxClearSvsBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearSvsBackup.Checked = false;
            }
        }

        private void cbxClearNssRegion_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;

                lblNssChevRight.Visible = cb.Checked;
                cbxClearNssBackup.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxClearNssBackup.Checked = false;
            }
        }

        private void cbxReplaceFsysRgn_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            cmdFsysPath.Enabled = isChecked;
            //tlpSerialA.Enabled = !isChecked;

            if (isChecked)
            {
                cmdFsysPath.PerformClick();
            }
        }

        private void cmdReplaceSerial_CheckedChanged(object sender, EventArgs e)
        {
            METCheckbox cb = (METCheckbox)sender;
            bool isChecked = cb.Checked;

            tlpSerialB.Enabled = isChecked;
            tlpFsysA.Enabled = !isChecked;

            if (!isChecked)
            {
                tbxSerialNumber.Text = string.Empty;
                tbxHwc.Text = string.Empty;
            }
        }

        private void cmdSaveLog_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Save Log File...",
                FileName = $"metlog_{DateTime.Now:yyMMdd_HHmmss}.txt",
                OverwritePrompt = true,
                InitialDirectory = Program.appDirectory
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                File.WriteAllText(dialog.FileName, rtbLog.Text);
            }
        }
        #endregion

        #region TextBox Events
        private void tbxSerialNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int textLength = tb.Text.Length;

            if (textLength == FWBase.FsysSectionData.Serial.Length)
            {
                if (EFIUtils.GetIsValidSerialChars(tb.Text))
                {
                    UpdateTextBoxColor(tb, Colours.clrGood);
                    Logger.WriteLogTextToRtb("Valid serial characters entered.", RtbLogPrefix.Info, rtbLog);
                    if (FWBase.FsysSectionData.Serial.Length == 11)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 3));
                    }
                    if (FWBase.FsysSectionData.Serial.Length == 12)
                    {
                        UpdateHwcTextBoxText(tb.Text.Substring(textLength - 4));
                    }
                    cmdBuild.Enabled = true;
                }
                else
                {
                    UpdateTextBoxColor(tb, Colours.clrError);
                    Logger.WriteLogTextToRtb("Invalid serial characters entered.", RtbLogPrefix.Error, rtbLog);
                    UpdateHwcTextBoxText(string.Empty);
                    cmdBuild.Enabled = false;
                }
            }
            else
            {
                UpdateTextBoxColor(tb, Color.White);
                UpdateHwcTextBoxText(string.Empty);
                cmdBuild.Enabled = true;
            }
        }
        #endregion

        #region Validation
        private bool ValidateNewFsysRegion(byte[] sourceBytes)
        {
            Logger.WriteLogTextToRtb("Validating donor Fsys region:", RtbLogPrefix.Info, rtbLog);

            if (sourceBytes.Length != FWBase.FSYS_RGN_SIZE)
            {
                Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h, expected 800h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            long lSigPos = BinaryUtils.GetOffset(sourceBytes, FWBase.FSYS_SIG);
            if (lSigPos == -1 || lSigPos != 0)
            {
                Logger.WriteLogTextToRtb(lSigPos == -1 ? "Fsys signature not found." : $"Fsys signature misaligned at {lSigPos:X2}h", RtbLogPrefix.Error, rtbLog);
                return false;
            }

            int lenSerial = FWBase.FsysSectionData.Serial.Length;
            string strHwc = lenSerial == 11 ? FWBase.FsysSectionData.Serial.Substring(FWBase.FsysSectionData.Serial.Length - 3).ToUpper() : lenSerial == 12 ? FWBase.FsysSectionData.Serial.Substring(FWBase.FsysSectionData.Serial.Length - 4).ToUpper() : string.Empty;

            Logger.WriteLogTextToRtb($"Filesize: {sourceBytes.Length:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Fsys signature found at {lSigPos:X2}h", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"Serial: {FWBase.FsysSectionData.Serial} ({lenSerial}char)", RtbLogPrefix.Info, rtbLog);
            Logger.WriteLogTextToRtb($"HWC: {strHwc}", RtbLogPrefix.Info, rtbLog);

            string strCrcInSourceBytes = FWBase.GetCrcStringFromFsys(sourceBytes);
            string strCrcCalculated = EFIUtils.GetUintFsysCrc32(sourceBytes).ToString("X8");

            Logger.WriteLogTextToRtb($"{strCrcInSourceBytes}h > {strCrcCalculated}h", RtbLogPrefix.Info, rtbLog);

            if (strCrcInSourceBytes != strCrcCalculated)
            {
                Logger.WriteLogTextToRtb("Donor Fsys CRC32 is invalid, 'Mask CRC32' flag set!", RtbLogPrefix.Warn, rtbLog);
                _maskCrc = true;
            }
            else
            {
                _maskCrc = false;
            }

            Logger.WriteLogTextToRtb("Validation completed", RtbLogPrefix.Good, rtbLog);

            return true;
        }
        #endregion

        #region Misc Events
        private void UpdateTextBoxColor(TextBox textBox, Color color)
        {
            textBox.ForeColor = color;
        }

        private void UpdateHwcTextBoxText(string text)
        {
            tbxHwc.Text = text;
        }

        private void SetLabelProperties(Label label, Font font, string text)
        {
            label.Font = font;
            label.Text = text;
            label.Visible = false;
        }

        private void SetButtonProperties()
        {
            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Program.closeChar;
            cmdOpenBuildsDir.Font = Program.FONT_MDL2_REG_12;
            cmdOpenBuildsDir.Text = "\xEC50";
        }

        private void ToggleControlEnable(bool enable)
        {
            tlpOptions.Enabled = enable;
            cmdBuild.Enabled = enable;
        }
        #endregion

        #region Logging
        private void LogFsysData()
        {
            if (FWBase.FsysSectionData.FsysOffset != 0)
            {
                Logger.WriteLogTextToRtb($"Fsys: Offset {FWBase.FsysSectionData.FsysOffset:X2}h, Size {FWBase.FSYS_RGN_SIZE:X2}h", RtbLogPrefix.Info, rtbLog);
            }
        }

        private void LogLoadedBinarySize()
        {
            if (!FileUtils.GetIsValidBinSize((int)FWBase.FileInfoData.FileLength))
            {
                Logger.WriteLogTextToRtb($"Loaded binary size {FWBase.FileInfoData.FileLength:X2}h is invalid and should not be used as a donor.", RtbLogPrefix.Error, rtbLog);
            }
            else
            {
                Logger.WriteLogTextToRtb($"Loaded binary size {FWBase.FileInfoData.FileLength:X2}h is valid", RtbLogPrefix.Info, rtbLog);
            }
        }
        #endregion

        #region Editing
        private void PatchFsys()
        {
            Logger.WriteLogTextToRtb("Writing new Fsys Region:", RtbLogPrefix.Info, rtbLog);

            // Mask Fsys CRC
            if (_maskCrc)
            {
                // Mask CRC32 was checked
                Logger.WriteLogTextToRtb("Masking Fsys CRC32", RtbLogPrefix.Info, rtbLog);

                // Calculate actual CRC32 from _bytesNewFsysRegion
                uint newCrc = EFIUtils.GetUintFsysCrc32(_bytesNewFsysRegion);

                // Get bytes from newCrc uint
                byte[] newCrcBytes = BitConverter.GetBytes(newCrc);

                // Write newCrcBytes to the donor Fsys region
                BinaryUtils.OverwriteBytesAtOffset(_bytesNewFsysRegion, 0x7FC, newCrcBytes);

                // Read CRC32 string from _bytesNewFsysRegion
                uint patchedCrcBytes = EFIUtils.GetUintFsysCrc32(_bytesNewFsysRegion);

                Logger.WriteLogTextToRtb($"{newCrc:X8}h > {patchedCrcBytes:X8}h", RtbLogPrefix.Info, rtbLog);

                // Convert newCrc to hex string to string and compare it to was was read.
                if (string.Equals(newCrc.ToString("X8"), patchedCrcBytes.ToString("X8")))
                {
                    Logger.WriteLogTextToRtb("CRC32 masking successful", RtbLogPrefix.Info, rtbLog);
                }
                else
                {
                    HandleBuildFailure("CRC32 masking failed.");
                    return;
                }
            }

            // Write new Fsys bytes to _bytesNewBinary
            BinaryUtils.OverwriteBytesAtOffset(_bytesNewBinary, FWBase.FsysSectionData.FsysOffset, _bytesNewFsysRegion);

            // Validate new Fsys was written
            FsysStoreSection fsysNew = FWBase.GetFsysStoreData(_bytesNewBinary);
            if (fsysNew.FsysBytes.SequenceEqual(_bytesNewFsysRegion))
            {
                Logger.WriteLogTextToRtb("Fsys comparison check passed", RtbLogPrefix.Info, rtbLog);
            }
            else
            {
                HandleBuildFailure("Fsys comparison check failed");
                return;
            }

            Logger.WriteLogTextToRtb("New Fsys region written successfully", RtbLogPrefix.Good, rtbLog);
        }

        private void HandleBuildFailure(string errorMessage)
        {
            Logger.WriteLogTextToRtb("BUILD FAILED:", RtbLogPrefix.Error, rtbLog);
            Logger.WriteLogTextToRtb(errorMessage, RtbLogPrefix.Error, rtbLog);
            _buildFailed = true;
        }

        #endregion

        private void ClearVssStores(bool clearBackup)
        {
            //byte[] vssPrimary = null;
            //long vssPrimBodyStart = _primaryVssPos + 0x10;
            //int vssPrimBodyEnd = _primarySvsLen - 0x10;

            //byte[] vssBackup = null;
            //long vssBackBodyStart = _primaryVssPos + 0x10;
            //int vssBackBodyEnd = _primarySvsLen - 0x10;

            //vssPrimary = BinaryUtils.GetBytesAtOffset(_bytesNewBinary, vssPrimBodyStart, vssPrimBodyEnd);

            //if (!BinaryUtils.IsByteBlockEmpty(vssPrimary))
            //{
            //    Logger.WriteLogTextToRtb("Overwriting primary VSS buffer (0xFF)", RtbLogPrefix.Info, rtbLog);
            //    BinaryUtils.FillByteArrayWithFF(vssPrimary);
            //} else
            //{
            //    Logger.WriteLogTextToRtb("Primary VSS is already empty (0xFF)", RtbLogPrefix.Info, rtbLog);
            //}

            //if (clearBackup)
            //{
            //    vssBackup = BinaryUtils.GetBytesAtOffset(_bytesNewBinary, vssBackBodyStart, vssBackBodyEnd);

            //    if (!BinaryUtils.IsByteBlockEmpty(vssBackup))
            //    {
            //        Logger.WriteLogTextToRtb("Overwriting backup VSS buffer (0xFF)", RtbLogPrefix.Info, rtbLog);
            //        BinaryUtils.FillByteArrayWithFF(vssBackup);
            //    }
            //    else
            //    {
            //        Logger.WriteLogTextToRtb("Backup VSS is already empty (0xFF)", RtbLogPrefix.Info, rtbLog);
            //    }
            //}
        }

    }
}