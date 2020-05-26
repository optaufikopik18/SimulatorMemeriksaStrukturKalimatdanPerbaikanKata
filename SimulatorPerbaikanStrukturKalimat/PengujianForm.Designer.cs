namespace SimulatorPerbaikanStrukturKalimat
{
    partial class PengujianForm
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
            this.pgjUploadFile = new System.Windows.Forms.Button();
            this.pgjCheck = new System.Windows.Forms.Button();
            this.pgjOutput = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgjUploadFile
            // 
            this.pgjUploadFile.Location = new System.Drawing.Point(12, 12);
            this.pgjUploadFile.Name = "pgjUploadFile";
            this.pgjUploadFile.Size = new System.Drawing.Size(101, 23);
            this.pgjUploadFile.TabIndex = 0;
            this.pgjUploadFile.Text = "Unggah File";
            this.pgjUploadFile.UseVisualStyleBackColor = true;
            // 
            // pgjCheck
            // 
            this.pgjCheck.Location = new System.Drawing.Point(119, 12);
            this.pgjCheck.Name = "pgjCheck";
            this.pgjCheck.Size = new System.Drawing.Size(101, 23);
            this.pgjCheck.TabIndex = 1;
            this.pgjCheck.Text = "Cek";
            this.pgjCheck.UseVisualStyleBackColor = true;
            // 
            // pgjOutput
            // 
            this.pgjOutput.Location = new System.Drawing.Point(6, 19);
            this.pgjOutput.Name = "pgjOutput";
            this.pgjOutput.Size = new System.Drawing.Size(513, 209);
            this.pgjOutput.TabIndex = 2;
            this.pgjOutput.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgjOutput);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 238);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hasil Pengujian";
            // 
            // PengujianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 289);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pgjCheck);
            this.Controls.Add(this.pgjUploadFile);
            this.Name = "PengujianForm";
            this.Text = "PengujianForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button pgjUploadFile;
        public System.Windows.Forms.Button pgjCheck;
        public System.Windows.Forms.RichTextBox pgjOutput;
    }
}