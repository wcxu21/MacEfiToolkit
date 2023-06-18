﻿
namespace Mac_EFI_Toolkit.WinForms
{
    partial class editorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editorWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
            this.lblNvramText = new System.Windows.Forms.Label();
            this.lblSerialText = new System.Windows.Forms.Label();
            this.tlpSerialA = new System.Windows.Forms.TableLayoutPanel();
            this.cbxReplaceSerial = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpFsysA = new System.Windows.Forms.TableLayoutPanel();
            this.cbxReplaceFsysRgn = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cmdFsysPath = new System.Windows.Forms.Button();
            this.lblFsysText = new System.Windows.Forms.Label();
            this.tlpSerialB = new System.Windows.Forms.TableLayoutPanel();
            this.lblHwcText = new System.Windows.Forms.Label();
            this.lblSsnText = new System.Windows.Forms.Label();
            this.tbxSerialNumber = new System.Windows.Forms.TextBox();
            this.tbxHwc = new System.Windows.Forms.TextBox();
            this.tlpNss = new System.Windows.Forms.TableLayoutPanel();
            this.lblNssChevRight = new System.Windows.Forms.Label();
            this.cbxClearNssStore = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearNssBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpSvs = new System.Windows.Forms.TableLayoutPanel();
            this.cbxClearSvsStore = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearSvsBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.lblSvsChevRight = new System.Windows.Forms.Label();
            this.tlpVss = new System.Windows.Forms.TableLayoutPanel();
            this.lblVssChevRight = new System.Windows.Forms.Label();
            this.cbxClearVssBackup = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.cbxClearVssStore = new Mac_EFI_Toolkit.UI.METCheckbox();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tlpOutput = new System.Windows.Forms.TableLayoutPanel();
            this.lblOutputText = new System.Windows.Forms.Label();
            this.cmdSaveLog = new System.Windows.Forms.Button();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdBuild = new System.Windows.Forms.Button();
            this.cmdOpenBuildsDir = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpOptions.SuspendLayout();
            this.tlpSerialA.SuspendLayout();
            this.tlpFsysA.SuspendLayout();
            this.tlpSerialB.SuspendLayout();
            this.tlpNss.SuspendLayout();
            this.tlpSvs.SuspendLayout();
            this.tlpVss.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.tlpOutput.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 43);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(948, 440);
            this.pnlMain.TabIndex = 95;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpOptions, 0, 0);
            this.tlpMain.Controls.Add(this.tlpLog, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(948, 440);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpOptions
            // 
            this.tlpOptions.ColumnCount = 1;
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Controls.Add(this.lblNvramText, 0, 9);
            this.tlpOptions.Controls.Add(this.lblSerialText, 0, 4);
            this.tlpOptions.Controls.Add(this.tlpSerialA, 0, 6);
            this.tlpOptions.Controls.Add(this.tlpFsysA, 0, 2);
            this.tlpOptions.Controls.Add(this.lblFsysText, 0, 0);
            this.tlpOptions.Controls.Add(this.tlpSerialB, 0, 7);
            this.tlpOptions.Controls.Add(this.tlpNss, 0, 15);
            this.tlpOptions.Controls.Add(this.tlpSvs, 0, 13);
            this.tlpOptions.Controls.Add(this.tlpVss, 0, 11);
            this.tlpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptions.Location = new System.Drawing.Point(0, 0);
            this.tlpOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOptions.Name = "tlpOptions";
            this.tlpOptions.RowCount = 17;
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOptions.Size = new System.Drawing.Size(400, 440);
            this.tlpOptions.TabIndex = 0;
            // 
            // lblNvramText
            // 
            this.lblNvramText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNvramText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNvramText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNvramText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblNvramText.Location = new System.Drawing.Point(0, 162);
            this.lblNvramText.Margin = new System.Windows.Forms.Padding(0);
            this.lblNvramText.Name = "lblNvramText";
            this.lblNvramText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblNvramText.Size = new System.Drawing.Size(400, 34);
            this.lblNvramText.TabIndex = 99;
            this.lblNvramText.Text = "NVRAM";
            this.lblNvramText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialText
            // 
            this.lblSerialText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSerialText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSerialText.Location = new System.Drawing.Point(0, 66);
            this.lblSerialText.Margin = new System.Windows.Forms.Padding(0);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblSerialText.Size = new System.Drawing.Size(400, 34);
            this.lblSerialText.TabIndex = 21;
            this.lblSerialText.Text = "Serial Number";
            this.lblSerialText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerialA
            // 
            this.tlpSerialA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpSerialA.ColumnCount = 1;
            this.tlpSerialA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSerialA.Controls.Add(this.cbxReplaceSerial, 0, 0);
            this.tlpSerialA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialA.Location = new System.Drawing.Point(0, 101);
            this.tlpSerialA.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialA.Name = "tlpSerialA";
            this.tlpSerialA.RowCount = 1;
            this.tlpSerialA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialA.Size = new System.Drawing.Size(400, 30);
            this.tlpSerialA.TabIndex = 1;
            // 
            // cbxReplaceSerial
            // 
            this.cbxReplaceSerial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxReplaceSerial.BackColor = System.Drawing.Color.Transparent;
            this.cbxReplaceSerial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxReplaceSerial.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxReplaceSerial.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxReplaceSerial.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxReplaceSerial.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxReplaceSerial.Enabled = false;
            this.cbxReplaceSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReplaceSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxReplaceSerial.Location = new System.Drawing.Point(11, 4);
            this.cbxReplaceSerial.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxReplaceSerial.Name = "cbxReplaceSerial";
            this.cbxReplaceSerial.Size = new System.Drawing.Size(192, 21);
            this.cbxReplaceSerial.TabIndex = 3;
            this.cbxReplaceSerial.Text = "Replace Serial Number";
            this.cbxReplaceSerial.CheckedChanged += new System.EventHandler(this.cmdReplaceSerial_CheckedChanged);
            // 
            // tlpFsysA
            // 
            this.tlpFsysA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpFsysA.ColumnCount = 2;
            this.tlpFsysA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsysA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tlpFsysA.Controls.Add(this.cbxReplaceFsysRgn, 0, 0);
            this.tlpFsysA.Controls.Add(this.cmdFsysPath, 1, 0);
            this.tlpFsysA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFsysA.Location = new System.Drawing.Point(0, 35);
            this.tlpFsysA.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFsysA.Name = "tlpFsysA";
            this.tlpFsysA.RowCount = 1;
            this.tlpFsysA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFsysA.Size = new System.Drawing.Size(400, 30);
            this.tlpFsysA.TabIndex = 0;
            // 
            // cbxReplaceFsysRgn
            // 
            this.cbxReplaceFsysRgn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxReplaceFsysRgn.BackColor = System.Drawing.Color.Transparent;
            this.cbxReplaceFsysRgn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxReplaceFsysRgn.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxReplaceFsysRgn.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxReplaceFsysRgn.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxReplaceFsysRgn.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxReplaceFsysRgn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxReplaceFsysRgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxReplaceFsysRgn.Location = new System.Drawing.Point(11, 4);
            this.cbxReplaceFsysRgn.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxReplaceFsysRgn.Name = "cbxReplaceFsysRgn";
            this.cbxReplaceFsysRgn.Size = new System.Drawing.Size(173, 21);
            this.cbxReplaceFsysRgn.TabIndex = 0;
            this.cbxReplaceFsysRgn.Text = "Replace Fsys Region";
            this.cbxReplaceFsysRgn.CheckedChanged += new System.EventHandler(this.cbxReplaceFsysRgn_CheckedChanged);
            // 
            // cmdFsysPath
            // 
            this.cmdFsysPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdFsysPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdFsysPath.Enabled = false;
            this.cmdFsysPath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdFsysPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFsysPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFsysPath.ForeColor = System.Drawing.Color.White;
            this.cmdFsysPath.Location = new System.Drawing.Point(293, 0);
            this.cmdFsysPath.Margin = new System.Windows.Forms.Padding(0);
            this.cmdFsysPath.Name = "cmdFsysPath";
            this.cmdFsysPath.Size = new System.Drawing.Size(107, 30);
            this.cmdFsysPath.TabIndex = 1;
            this.cmdFsysPath.Text = "Change File";
            this.cmdFsysPath.UseVisualStyleBackColor = false;
            this.cmdFsysPath.Click += new System.EventHandler(this.cmdFsysPath_Click);
            // 
            // lblFsysText
            // 
            this.lblFsysText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFsysText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFsysText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFsysText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblFsysText.Location = new System.Drawing.Point(0, 0);
            this.lblFsysText.Margin = new System.Windows.Forms.Padding(0);
            this.lblFsysText.Name = "lblFsysText";
            this.lblFsysText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFsysText.Size = new System.Drawing.Size(400, 34);
            this.lblFsysText.TabIndex = 99;
            this.lblFsysText.Text = "Fsys Region";
            this.lblFsysText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpSerialB
            // 
            this.tlpSerialB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpSerialB.ColumnCount = 4;
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpSerialB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialB.Controls.Add(this.lblHwcText, 2, 0);
            this.tlpSerialB.Controls.Add(this.lblSsnText, 0, 0);
            this.tlpSerialB.Controls.Add(this.tbxSerialNumber, 1, 0);
            this.tlpSerialB.Controls.Add(this.tbxHwc, 3, 0);
            this.tlpSerialB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSerialB.Enabled = false;
            this.tlpSerialB.Location = new System.Drawing.Point(0, 131);
            this.tlpSerialB.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSerialB.Name = "tlpSerialB";
            this.tlpSerialB.RowCount = 1;
            this.tlpSerialB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSerialB.Size = new System.Drawing.Size(400, 30);
            this.tlpSerialB.TabIndex = 2;
            // 
            // lblHwcText
            // 
            this.lblHwcText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHwcText.AutoSize = true;
            this.lblHwcText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHwcText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblHwcText.Location = new System.Drawing.Point(255, 5);
            this.lblHwcText.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblHwcText.Name = "lblHwcText";
            this.lblHwcText.Size = new System.Drawing.Size(47, 20);
            this.lblHwcText.TabIndex = 21;
            this.lblHwcText.Text = "HWC:";
            // 
            // lblSsnText
            // 
            this.lblSsnText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSsnText.AutoSize = true;
            this.lblSsnText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSsnText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblSsnText.Location = new System.Drawing.Point(9, 5);
            this.lblSsnText.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblSsnText.Name = "lblSsnText";
            this.lblSsnText.Size = new System.Drawing.Size(41, 20);
            this.lblSsnText.TabIndex = 18;
            this.lblSsnText.Text = "SSN:";
            // 
            // tbxSerialNumber
            // 
            this.tbxSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxSerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbxSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxSerialNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSerialNumber.ForeColor = System.Drawing.Color.White;
            this.tbxSerialNumber.Location = new System.Drawing.Point(55, 1);
            this.tbxSerialNumber.Margin = new System.Windows.Forms.Padding(0);
            this.tbxSerialNumber.MaxLength = 12;
            this.tbxSerialNumber.Name = "tbxSerialNumber";
            this.tbxSerialNumber.Size = new System.Drawing.Size(188, 27);
            this.tbxSerialNumber.TabIndex = 0;
            this.tbxSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSerialNumber.TextChanged += new System.EventHandler(this.tbxSerialNumber_TextChanged);
            // 
            // tbxHwc
            // 
            this.tbxHwc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxHwc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbxHwc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxHwc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHwc.ForeColor = System.Drawing.Color.White;
            this.tbxHwc.Location = new System.Drawing.Point(305, 1);
            this.tbxHwc.Margin = new System.Windows.Forms.Padding(0);
            this.tbxHwc.MaxLength = 4;
            this.tbxHwc.Name = "tbxHwc";
            this.tbxHwc.ReadOnly = true;
            this.tbxHwc.Size = new System.Drawing.Size(78, 27);
            this.tbxHwc.TabIndex = 1;
            this.tbxHwc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlpNss
            // 
            this.tlpNss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpNss.ColumnCount = 3;
            this.tlpNss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpNss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpNss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNss.Controls.Add(this.lblNssChevRight, 0, 0);
            this.tlpNss.Controls.Add(this.cbxClearNssStore, 0, 0);
            this.tlpNss.Controls.Add(this.cbxClearNssBackup, 2, 0);
            this.tlpNss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNss.Location = new System.Drawing.Point(0, 259);
            this.tlpNss.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNss.Name = "tlpNss";
            this.tlpNss.RowCount = 1;
            this.tlpNss.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNss.Size = new System.Drawing.Size(400, 30);
            this.tlpNss.TabIndex = 4;
            // 
            // lblNssChevRight
            // 
            this.lblNssChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNssChevRight.AutoSize = true;
            this.lblNssChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNssChevRight.ForeColor = System.Drawing.Color.White;
            this.lblNssChevRight.Location = new System.Drawing.Point(160, 3);
            this.lblNssChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblNssChevRight.Name = "lblNssChevRight";
            this.lblNssChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblNssChevRight.TabIndex = 28;
            this.lblNssChevRight.Text = ".";
            this.lblNssChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxClearNssStore
            // 
            this.cbxClearNssStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearNssStore.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearNssStore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearNssStore.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearNssStore.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearNssStore.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearNssStore.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearNssStore.Enabled = false;
            this.cbxClearNssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearNssStore.ForeColor = System.Drawing.Color.White;
            this.cbxClearNssStore.Location = new System.Drawing.Point(11, 4);
            this.cbxClearNssStore.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearNssStore.Name = "cbxClearNssStore";
            this.cbxClearNssStore.Size = new System.Drawing.Size(149, 21);
            this.cbxClearNssStore.TabIndex = 0;
            this.cbxClearNssStore.Text = "Clear NSS Store";
            this.cbxClearNssStore.CheckedChanged += new System.EventHandler(this.cbxClearNssRegion_CheckedChanged);
            // 
            // cbxClearNssBackup
            // 
            this.cbxClearNssBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearNssBackup.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearNssBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearNssBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearNssBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearNssBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearNssBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearNssBackup.Enabled = false;
            this.cbxClearNssBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearNssBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.cbxClearNssBackup.Location = new System.Drawing.Point(190, 4);
            this.cbxClearNssBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearNssBackup.Name = "cbxClearNssBackup";
            this.cbxClearNssBackup.Size = new System.Drawing.Size(210, 21);
            this.cbxClearNssBackup.TabIndex = 1;
            this.cbxClearNssBackup.Text = "Clear NSS Backup Store";
            // 
            // tlpSvs
            // 
            this.tlpSvs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpSvs.ColumnCount = 3;
            this.tlpSvs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpSvs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSvs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSvs.Controls.Add(this.cbxClearSvsStore, 0, 0);
            this.tlpSvs.Controls.Add(this.cbxClearSvsBackup, 2, 0);
            this.tlpSvs.Controls.Add(this.lblSvsChevRight, 1, 0);
            this.tlpSvs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSvs.Location = new System.Drawing.Point(0, 228);
            this.tlpSvs.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSvs.Name = "tlpSvs";
            this.tlpSvs.RowCount = 1;
            this.tlpSvs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSvs.Size = new System.Drawing.Size(400, 30);
            this.tlpSvs.TabIndex = 3;
            // 
            // cbxClearSvsStore
            // 
            this.cbxClearSvsStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearSvsStore.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearSvsStore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearSvsStore.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearSvsStore.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearSvsStore.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearSvsStore.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearSvsStore.Enabled = false;
            this.cbxClearSvsStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearSvsStore.ForeColor = System.Drawing.Color.White;
            this.cbxClearSvsStore.Location = new System.Drawing.Point(11, 4);
            this.cbxClearSvsStore.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearSvsStore.Name = "cbxClearSvsStore";
            this.cbxClearSvsStore.Size = new System.Drawing.Size(149, 21);
            this.cbxClearSvsStore.TabIndex = 0;
            this.cbxClearSvsStore.Text = "Clear SVS Store";
            this.cbxClearSvsStore.CheckedChanged += new System.EventHandler(this.cbxClearSvsRegion_CheckedChanged);
            // 
            // cbxClearSvsBackup
            // 
            this.cbxClearSvsBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearSvsBackup.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearSvsBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearSvsBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearSvsBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearSvsBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearSvsBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearSvsBackup.Enabled = false;
            this.cbxClearSvsBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearSvsBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.cbxClearSvsBackup.Location = new System.Drawing.Point(190, 4);
            this.cbxClearSvsBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearSvsBackup.Name = "cbxClearSvsBackup";
            this.cbxClearSvsBackup.Size = new System.Drawing.Size(210, 21);
            this.cbxClearSvsBackup.TabIndex = 1;
            this.cbxClearSvsBackup.Text = "Clear SVS Backup Store";
            // 
            // lblSvsChevRight
            // 
            this.lblSvsChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSvsChevRight.AutoSize = true;
            this.lblSvsChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSvsChevRight.ForeColor = System.Drawing.Color.White;
            this.lblSvsChevRight.Location = new System.Drawing.Point(160, 3);
            this.lblSvsChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblSvsChevRight.Name = "lblSvsChevRight";
            this.lblSvsChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblSvsChevRight.TabIndex = 27;
            this.lblSvsChevRight.Text = ".";
            this.lblSvsChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpVss
            // 
            this.tlpVss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlpVss.ColumnCount = 3;
            this.tlpVss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpVss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpVss.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVss.Controls.Add(this.lblVssChevRight, 0, 0);
            this.tlpVss.Controls.Add(this.cbxClearVssBackup, 2, 0);
            this.tlpVss.Controls.Add(this.cbxClearVssStore, 0, 0);
            this.tlpVss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVss.Location = new System.Drawing.Point(0, 197);
            this.tlpVss.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVss.Name = "tlpVss";
            this.tlpVss.RowCount = 1;
            this.tlpVss.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVss.Size = new System.Drawing.Size(400, 30);
            this.tlpVss.TabIndex = 2;
            // 
            // lblVssChevRight
            // 
            this.lblVssChevRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVssChevRight.AutoSize = true;
            this.lblVssChevRight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVssChevRight.ForeColor = System.Drawing.Color.White;
            this.lblVssChevRight.Location = new System.Drawing.Point(160, 3);
            this.lblVssChevRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblVssChevRight.Name = "lblVssChevRight";
            this.lblVssChevRight.Size = new System.Drawing.Size(14, 23);
            this.lblVssChevRight.TabIndex = 28;
            this.lblVssChevRight.Text = ".";
            this.lblVssChevRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxClearVssBackup
            // 
            this.cbxClearVssBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearVssBackup.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearVssBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearVssBackup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearVssBackup.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearVssBackup.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearVssBackup.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearVssBackup.Enabled = false;
            this.cbxClearVssBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearVssBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.cbxClearVssBackup.Location = new System.Drawing.Point(190, 4);
            this.cbxClearVssBackup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxClearVssBackup.Name = "cbxClearVssBackup";
            this.cbxClearVssBackup.Size = new System.Drawing.Size(210, 21);
            this.cbxClearVssBackup.TabIndex = 1;
            this.cbxClearVssBackup.Text = "Clear VSS Backup Store";
            // 
            // cbxClearVssStore
            // 
            this.cbxClearVssStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxClearVssStore.BackColor = System.Drawing.Color.Transparent;
            this.cbxClearVssStore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbxClearVssStore.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbxClearVssStore.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.cbxClearVssStore.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbxClearVssStore.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cbxClearVssStore.Enabled = false;
            this.cbxClearVssStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxClearVssStore.ForeColor = System.Drawing.Color.White;
            this.cbxClearVssStore.Location = new System.Drawing.Point(11, 4);
            this.cbxClearVssStore.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.cbxClearVssStore.Name = "cbxClearVssStore";
            this.cbxClearVssStore.Size = new System.Drawing.Size(149, 21);
            this.cbxClearVssStore.TabIndex = 0;
            this.cbxClearVssStore.Text = "Clear VSS Store";
            this.cbxClearVssStore.CheckedChanged += new System.EventHandler(this.cbxClearVssRegion_CheckedChanged);
            // 
            // tlpLog
            // 
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.Controls.Add(this.pnlLog, 0, 2);
            this.tlpLog.Controls.Add(this.tlpOutput, 0, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(401, 0);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 4;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpLog.Size = new System.Drawing.Size(547, 440);
            this.tlpLog.TabIndex = 1;
            // 
            // pnlLog
            // 
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlLog.Controls.Add(this.rtbLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(0, 35);
            this.pnlLog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Padding = new System.Windows.Forms.Padding(4);
            this.pnlLog.Size = new System.Drawing.Size(547, 404);
            this.pnlLog.TabIndex = 3;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.ForeColor = System.Drawing.Color.White;
            this.rtbLog.Location = new System.Drawing.Point(4, 4);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(539, 396);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.TabStop = false;
            this.rtbLog.Text = "";
            // 
            // tlpOutput
            // 
            this.tlpOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpOutput.ColumnCount = 3;
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpOutput.Controls.Add(this.lblOutputText, 0, 0);
            this.tlpOutput.Controls.Add(this.cmdSaveLog, 2, 0);
            this.tlpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOutput.Location = new System.Drawing.Point(0, 0);
            this.tlpOutput.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOutput.Name = "tlpOutput";
            this.tlpOutput.RowCount = 1;
            this.tlpOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOutput.Size = new System.Drawing.Size(547, 34);
            this.tlpOutput.TabIndex = 4;
            // 
            // lblOutputText
            // 
            this.lblOutputText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblOutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblOutputText.Location = new System.Drawing.Point(0, 0);
            this.lblOutputText.Margin = new System.Windows.Forms.Padding(0);
            this.lblOutputText.Name = "lblOutputText";
            this.lblOutputText.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblOutputText.Size = new System.Drawing.Size(466, 34);
            this.lblOutputText.TabIndex = 2;
            this.lblOutputText.Text = "Output";
            this.lblOutputText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdSaveLog
            // 
            this.cmdSaveLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdSaveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSaveLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdSaveLog.FlatAppearance.BorderSize = 0;
            this.cmdSaveLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaveLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveLog.ForeColor = System.Drawing.Color.White;
            this.cmdSaveLog.Location = new System.Drawing.Point(467, 0);
            this.cmdSaveLog.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSaveLog.Name = "cmdSaveLog";
            this.cmdSaveLog.Size = new System.Drawing.Size(80, 34);
            this.cmdSaveLog.TabIndex = 4;
            this.cmdSaveLog.Text = "Save Log";
            this.cmdSaveLog.UseVisualStyleBackColor = false;
            this.cmdSaveLog.Click += new System.EventHandler(this.cmdSaveLog_Click);
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::Mac_EFI_Toolkit.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 2;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 1, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(948, 40);
            this.tlpTitle.TabIndex = 99;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(908, 40);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "Firmware Editor (Experimental)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(908, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 3, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 99;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "X";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(235)))));
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeperator.Location = new System.Drawing.Point(1, 41);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(948, 2);
            this.pnlSeperator.TabIndex = 97;
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpButtons.Controls.Add(this.cmdBuild, 2, 0);
            this.tlpButtons.Controls.Add(this.cmdOpenBuildsDir, 1, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 483);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(948, 46);
            this.tlpButtons.TabIndex = 1;
            // 
            // cmdBuild
            // 
            this.cmdBuild.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdBuild.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBuild.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuild.ForeColor = System.Drawing.Color.White;
            this.cmdBuild.Location = new System.Drawing.Point(843, 6);
            this.cmdBuild.Margin = new System.Windows.Forms.Padding(0);
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(100, 34);
            this.cmdBuild.TabIndex = 1;
            this.cmdBuild.Text = "Build";
            this.cmdBuild.UseVisualStyleBackColor = false;
            this.cmdBuild.Click += new System.EventHandler(this.cmdBuild_Click);
            // 
            // cmdOpenBuildsDir
            // 
            this.cmdOpenBuildsDir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdOpenBuildsDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOpenBuildsDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.cmdOpenBuildsDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenBuildsDir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenBuildsDir.ForeColor = System.Drawing.Color.White;
            this.cmdOpenBuildsDir.Location = new System.Drawing.Point(804, 6);
            this.cmdOpenBuildsDir.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOpenBuildsDir.Name = "cmdOpenBuildsDir";
            this.cmdOpenBuildsDir.Size = new System.Drawing.Size(34, 34);
            this.cmdOpenBuildsDir.TabIndex = 0;
            this.cmdOpenBuildsDir.Text = "N";
            this.cmdOpenBuildsDir.UseVisualStyleBackColor = false;
            this.cmdOpenBuildsDir.Click += new System.EventHandler(this.cmdOpenBuildsDir_Click);
            // 
            // editorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(950, 530);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSeperator);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.tlpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 530);
            this.Name = "editorWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Firmware Editor";
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpOptions.ResumeLayout(false);
            this.tlpSerialA.ResumeLayout(false);
            this.tlpFsysA.ResumeLayout(false);
            this.tlpSerialB.ResumeLayout(false);
            this.tlpSerialB.PerformLayout();
            this.tlpNss.ResumeLayout(false);
            this.tlpNss.PerformLayout();
            this.tlpSvs.ResumeLayout(false);
            this.tlpSvs.PerformLayout();
            this.tlpVss.ResumeLayout(false);
            this.tlpVss.PerformLayout();
            this.tlpLog.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.tlpOutput.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.TextBox tbxHwc;
        private UI.METCheckbox cbxClearVssStore;
        private UI.METCheckbox cbxClearSvsStore;
        private System.Windows.Forms.TextBox tbxSerialNumber;
        private System.Windows.Forms.Button cmdFsysPath;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private UI.METCheckbox cbxClearVssBackup;
        private UI.METCheckbox cbxClearSvsBackup;
        private System.Windows.Forms.Label lblSsnText;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TableLayoutPanel tlpOptions;
        private System.Windows.Forms.Label lblFsysText;
        private System.Windows.Forms.TableLayoutPanel tlpFsysA;
        private System.Windows.Forms.TableLayoutPanel tlpSerialA;
        private System.Windows.Forms.TableLayoutPanel tlpSerialB;
        private System.Windows.Forms.Label lblHwcText;
        private System.Windows.Forms.Label lblSerialText;
        private System.Windows.Forms.Label lblNvramText;
        private System.Windows.Forms.TableLayoutPanel tlpVss;
        private System.Windows.Forms.TableLayoutPanel tlpSvs;
        private UI.METCheckbox cbxReplaceSerial;
        private UI.METCheckbox cbxReplaceFsysRgn;
        private System.Windows.Forms.Label lblSvsChevRight;
        private System.Windows.Forms.Label lblVssChevRight;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Label lblOutputText;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.TableLayoutPanel tlpOutput;
        private System.Windows.Forms.TableLayoutPanel tlpNss;
        private System.Windows.Forms.Label lblNssChevRight;
        private UI.METCheckbox cbxClearNssBackup;
        private UI.METCheckbox cbxClearNssStore;
        private System.Windows.Forms.Button cmdBuild;
        private System.Windows.Forms.Button cmdSaveLog;
        private System.Windows.Forms.Button cmdOpenBuildsDir;
    }
}