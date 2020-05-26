namespace SimulatorPerbaikanStrukturKalimat
{
    partial class MainApp
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
            this.textOutput = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.formStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.exitSimulator = new System.Windows.Forms.ToolStripMenuItem();
            this.checkMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.checkWords = new System.Windows.Forms.ToolStripMenuItem();
            this.checkStructure = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listLog = new System.Windows.Forms.RichTextBox();
            this.perbaikanKataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perbaikanPolaKalimatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDocument = new System.Windows.Forms.Panel();
            this.panelTest = new System.Windows.Forms.Panel();
            this.finalResult = new System.Windows.Forms.RichTextBox();
            this.panelWords = new System.Windows.Forms.Panel();
            this.listFixedWords = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listMistakenWords = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectWord = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDocument.SuspendLayout();
            this.panelTest.SuspendLayout();
            this.panelWords.SuspendLayout();
            this.SuspendLayout();
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(12, 13);
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(449, 351);
            this.textOutput.TabIndex = 0;
            this.textOutput.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 604);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(952, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // formStatusLabel
            // 
            this.formStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formStatusLabel.Name = "formStatusLabel";
            this.formStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.formStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.formStatusLabel.Text = "Ready";
            this.formStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.checkMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadDocument,
            this.exitSimulator});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            this.fileMenu.Click += new System.EventHandler(this.fileMenu_Click);
            // 
            // uploadDocument
            // 
            this.uploadDocument.Name = "uploadDocument";
            this.uploadDocument.Size = new System.Drawing.Size(171, 22);
            this.uploadDocument.Text = "Unggah Dokumen";
            this.uploadDocument.Click += new System.EventHandler(this.uploadDocument_Click);
            // 
            // exitSimulator
            // 
            this.exitSimulator.Name = "exitSimulator";
            this.exitSimulator.Size = new System.Drawing.Size(171, 22);
            this.exitSimulator.Text = "Keluar";
            this.exitSimulator.Click += new System.EventHandler(this.exitSimulator_Click);
            // 
            // checkMenu
            // 
            this.checkMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkWords,
            this.checkStructure});
            this.checkMenu.Name = "checkMenu";
            this.checkMenu.Size = new System.Drawing.Size(86, 20);
            this.checkMenu.Text = "Pemeriksaan";
            this.checkMenu.Click += new System.EventHandler(this.checkMenu_Click);
            // 
            // checkWords
            // 
            this.checkWords.Name = "checkWords";
            this.checkWords.Size = new System.Drawing.Size(180, 22);
            this.checkWords.Text = "Periksa Kata";
            this.checkWords.Click += new System.EventHandler(this.checkWords_Click);
            // 
            // checkStructure
            // 
            this.checkStructure.Name = "checkStructure";
            this.checkStructure.Size = new System.Drawing.Size(180, 22);
            this.checkStructure.Text = "Periksa Pola Kalimat";
            this.checkStructure.Click += new System.EventHandler(this.checkStructure_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 412);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(923, 182);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // listLog
            // 
            this.listLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLog.Location = new System.Drawing.Point(10, 18);
            this.listLog.Name = "listLog";
            this.listLog.ReadOnly = true;
            this.listLog.Size = new System.Drawing.Size(907, 154);
            this.listLog.TabIndex = 0;
            this.listLog.Text = "";
            // 
            // perbaikanKataToolStripMenuItem
            // 
            this.perbaikanKataToolStripMenuItem.Name = "perbaikanKataToolStripMenuItem";
            this.perbaikanKataToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.perbaikanKataToolStripMenuItem.Text = "Perbaikan Kata";
            // 
            // perbaikanPolaKalimatToolStripMenuItem
            // 
            this.perbaikanPolaKalimatToolStripMenuItem.Name = "perbaikanPolaKalimatToolStripMenuItem";
            this.perbaikanPolaKalimatToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.perbaikanPolaKalimatToolStripMenuItem.Text = "Perbaikan Pola Kalimat";
            // 
            // panelDocument
            // 
            this.panelDocument.Controls.Add(this.textOutput);
            this.panelDocument.Location = new System.Drawing.Point(12, 27);
            this.panelDocument.Name = "panelDocument";
            this.panelDocument.Size = new System.Drawing.Size(472, 379);
            this.panelDocument.TabIndex = 10;
            // 
            // panelTest
            // 
            this.panelTest.Controls.Add(this.finalResult);
            this.panelTest.Location = new System.Drawing.Point(490, 27);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(445, 379);
            this.panelTest.TabIndex = 12;
            // 
            // finalResult
            // 
            this.finalResult.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalResult.Location = new System.Drawing.Point(15, 13);
            this.finalResult.Name = "finalResult";
            this.finalResult.ReadOnly = true;
            this.finalResult.Size = new System.Drawing.Size(414, 351);
            this.finalResult.TabIndex = 0;
            this.finalResult.Text = "";
            // 
            // panelWords
            // 
            this.panelWords.Controls.Add(this.listFixedWords);
            this.panelWords.Controls.Add(this.label3);
            this.panelWords.Controls.Add(this.listMistakenWords);
            this.panelWords.Controls.Add(this.label2);
            this.panelWords.Controls.Add(this.selectWord);
            this.panelWords.Location = new System.Drawing.Point(490, 27);
            this.panelWords.Name = "panelWords";
            this.panelWords.Size = new System.Drawing.Size(445, 379);
            this.panelWords.TabIndex = 11;
            // 
            // listFixedWords
            // 
            this.listFixedWords.Enabled = false;
            this.listFixedWords.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFixedWords.FormattingEnabled = true;
            this.listFixedWords.Location = new System.Drawing.Point(230, 42);
            this.listFixedWords.Name = "listFixedWords";
            this.listFixedWords.Size = new System.Drawing.Size(200, 290);
            this.listFixedWords.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saran perbaikan kata:";
            // 
            // listMistakenWords
            // 
            this.listMistakenWords.Enabled = false;
            this.listMistakenWords.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMistakenWords.FormattingEnabled = true;
            this.listMistakenWords.Location = new System.Drawing.Point(12, 42);
            this.listMistakenWords.Name = "listMistakenWords";
            this.listMistakenWords.Size = new System.Drawing.Size(200, 290);
            this.listMistakenWords.TabIndex = 0;
            this.listMistakenWords.SelectedIndexChanged += new System.EventHandler(this.listMistakenWords_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kata yang keliru:";
            // 
            // selectWord
            // 
            this.selectWord.Enabled = false;
            this.selectWord.Location = new System.Drawing.Point(12, 341);
            this.selectWord.Name = "selectWord";
            this.selectWord.Size = new System.Drawing.Size(75, 23);
            this.selectWord.TabIndex = 6;
            this.selectWord.Text = "Pilih Kata";
            this.selectWord.UseVisualStyleBackColor = true;
            this.selectWord.Click += new System.EventHandler(this.selectWord_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 626);
            this.Controls.Add(this.panelTest);
            this.Controls.Add(this.panelWords);
            this.Controls.Add(this.panelDocument);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainApp";
            this.Text = "Simulator Perbaikan Struktur Kalimat";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelDocument.ResumeLayout(false);
            this.panelTest.ResumeLayout(false);
            this.panelWords.ResumeLayout(false);
            this.panelWords.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel formStatusLabel;
        private System.Windows.Forms.RichTextBox textOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem checkMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem perbaikanKataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perbaikanPolaKalimatToolStripMenuItem;
        private System.Windows.Forms.RichTextBox listLog;
        private System.Windows.Forms.Panel panelDocument;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.RichTextBox finalResult;
        private System.Windows.Forms.ToolStripMenuItem uploadDocument;
        private System.Windows.Forms.ToolStripMenuItem exitSimulator;
        private System.Windows.Forms.ToolStripMenuItem checkWords;
        private System.Windows.Forms.ToolStripMenuItem checkStructure;
        private System.Windows.Forms.Panel panelWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listMistakenWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectWord;
        private System.Windows.Forms.ListBox listFixedWords;
    }
}

