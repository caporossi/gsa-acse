namespace gsa_acse.caporossi.net
{
    partial class FormCatturaIMG
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
            this.comboCam = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureCamIMG = new System.Windows.Forms.PictureBox();
            this.btnCattura = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnTaglia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamIMG)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCam
            // 
            this.comboCam.FormattingEnabled = true;
            this.comboCam.Location = new System.Drawing.Point(12, 426);
            this.comboCam.Name = "comboCam";
            this.comboCam.Size = new System.Drawing.Size(567, 24);
            this.comboCam.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 456);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(135, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureCamIMG
            // 
            this.pictureCamIMG.Location = new System.Drawing.Point(12, 12);
            this.pictureCamIMG.Name = "pictureCamIMG";
            this.pictureCamIMG.Size = new System.Drawing.Size(567, 408);
            this.pictureCamIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCamIMG.TabIndex = 0;
            this.pictureCamIMG.TabStop = false;
            this.pictureCamIMG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            this.pictureCamIMG.MouseEnter += new System.EventHandler(this.picBox_MouseEnter);
            this.pictureCamIMG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
            this.pictureCamIMG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseUp);
            // 
            // btnCattura
            // 
            this.btnCattura.Enabled = false;
            this.btnCattura.Location = new System.Drawing.Point(294, 456);
            this.btnCattura.Name = "btnCattura";
            this.btnCattura.Size = new System.Drawing.Size(135, 31);
            this.btnCattura.TabIndex = 3;
            this.btnCattura.Text = "Cattura";
            this.btnCattura.UseVisualStyleBackColor = true;
            this.btnCattura.Click += new System.EventHandler(this.btnCattura_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Location = new System.Drawing.Point(435, 456);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(135, 31);
            this.btnChiudi.TabIndex = 4;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnTaglia
            // 
            this.btnTaglia.Enabled = false;
            this.btnTaglia.Location = new System.Drawing.Point(153, 456);
            this.btnTaglia.Name = "btnTaglia";
            this.btnTaglia.Size = new System.Drawing.Size(135, 31);
            this.btnTaglia.TabIndex = 5;
            this.btnTaglia.Text = "Seleziona";
            this.btnTaglia.UseVisualStyleBackColor = true;
            this.btnTaglia.Click += new System.EventHandler(this.btnSeleziona_Click);
            // 
            // FormCatturaIMG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 499);
            this.ControlBox = false;
            this.Controls.Add(this.btnTaglia);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnCattura);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.comboCam);
            this.Controls.Add(this.pictureCamIMG);
            this.DoubleBuffered = true;
            this.Name = "FormCatturaIMG";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCatturaIMG";
            this.Load += new System.EventHandler(this.FormCatturaIMG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamIMG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCamIMG;
        private System.Windows.Forms.ComboBox comboCam;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCattura;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Button btnTaglia;
    }
}