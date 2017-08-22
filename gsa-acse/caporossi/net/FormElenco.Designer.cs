namespace gsa_acse.caporossi.net
{
    partial class FormElenco
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRicercaNome = new System.Windows.Forms.TextBox();
            this.txtRicercaCognome = new System.Windows.Forms.TextBox();
            this.btnRicercaNome = new System.Windows.Forms.Button();
            this.btnRicercaCognome = new System.Windows.Forms.Button();
            this.txtInsertTessera = new System.Windows.Forms.TextBox();
            this.btnTessera = new System.Windows.Forms.Button();
            this.btnTutti = new System.Windows.Forms.Button();
            this.lblpage = new System.Windows.Forms.Label();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnNxtPage = new System.Windows.Forms.Button();
            this.btnFirstPAge = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroTessera = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.rbM = new System.Windows.Forms.RadioButton();
            this.rbF = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLuogoNascita = new System.Windows.Forms.TextBox();
            this.txtDataNascita = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNazione = new System.Windows.Forms.TextBox();
            this.btnScheda = new System.Windows.Forms.Button();
            this.pictureFoto = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNuovaScheda = new System.Windows.Forms.Button();
            this.btnAssegnaPacco = new System.Windows.Forms.Button();
            this.txtFamigliaOggi = new System.Windows.Forms.TextBox();
            this.txtSingoliOggi = new System.Windows.Forms.TextBox();
            this.txtTotaliOggi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTesseraRitiroPacco = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.closeToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 274);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(911, 249);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRicercaNome);
            this.panel1.Controls.Add(this.txtRicercaCognome);
            this.panel1.Controls.Add(this.btnRicercaNome);
            this.panel1.Controls.Add(this.btnRicercaCognome);
            this.panel1.Controls.Add(this.txtInsertTessera);
            this.panel1.Controls.Add(this.btnTessera);
            this.panel1.Controls.Add(this.btnTutti);
            this.panel1.Controls.Add(this.lblpage);
            this.panel1.Controls.Add(this.btnPrevPage);
            this.panel1.Controls.Add(this.btnLastPage);
            this.panel1.Controls.Add(this.btnNxtPage);
            this.panel1.Controls.Add(this.btnFirstPAge);
            this.panel1.Location = new System.Drawing.Point(10, 529);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 86);
            this.panel1.TabIndex = 20;
            // 
            // txtRicercaNome
            // 
            this.txtRicercaNome.Location = new System.Drawing.Point(583, 63);
            this.txtRicercaNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtRicercaNome.Name = "txtRicercaNome";
            this.txtRicercaNome.Size = new System.Drawing.Size(164, 20);
            this.txtRicercaNome.TabIndex = 22;
            // 
            // txtRicercaCognome
            // 
            this.txtRicercaCognome.Location = new System.Drawing.Point(583, 37);
            this.txtRicercaCognome.Margin = new System.Windows.Forms.Padding(2);
            this.txtRicercaCognome.Name = "txtRicercaCognome";
            this.txtRicercaCognome.Size = new System.Drawing.Size(164, 20);
            this.txtRicercaCognome.TabIndex = 21;
            // 
            // btnRicercaNome
            // 
            this.btnRicercaNome.Location = new System.Drawing.Point(506, 59);
            this.btnRicercaNome.Margin = new System.Windows.Forms.Padding(2);
            this.btnRicercaNome.Name = "btnRicercaNome";
            this.btnRicercaNome.Size = new System.Drawing.Size(72, 23);
            this.btnRicercaNome.TabIndex = 20;
            this.btnRicercaNome.Text = "Nome";
            this.btnRicercaNome.UseVisualStyleBackColor = true;
            this.btnRicercaNome.Click += new System.EventHandler(this.btnRicercaNome_Click);
            // 
            // btnRicercaCognome
            // 
            this.btnRicercaCognome.Location = new System.Drawing.Point(506, 32);
            this.btnRicercaCognome.Margin = new System.Windows.Forms.Padding(2);
            this.btnRicercaCognome.Name = "btnRicercaCognome";
            this.btnRicercaCognome.Size = new System.Drawing.Size(72, 23);
            this.btnRicercaCognome.TabIndex = 19;
            this.btnRicercaCognome.Text = "Cognome";
            this.btnRicercaCognome.UseVisualStyleBackColor = true;
            this.btnRicercaCognome.Click += new System.EventHandler(this.btnRicercaCognome_Click);
            // 
            // txtInsertTessera
            // 
            this.txtInsertTessera.Location = new System.Drawing.Point(583, 6);
            this.txtInsertTessera.Margin = new System.Windows.Forms.Padding(2);
            this.txtInsertTessera.Name = "txtInsertTessera";
            this.txtInsertTessera.Size = new System.Drawing.Size(164, 20);
            this.txtInsertTessera.TabIndex = 18;
            // 
            // btnTessera
            // 
            this.btnTessera.Location = new System.Drawing.Point(506, 4);
            this.btnTessera.Margin = new System.Windows.Forms.Padding(2);
            this.btnTessera.Name = "btnTessera";
            this.btnTessera.Size = new System.Drawing.Size(72, 23);
            this.btnTessera.TabIndex = 17;
            this.btnTessera.Text = "Tessera N°";
            this.btnTessera.UseVisualStyleBackColor = true;
            this.btnTessera.Click += new System.EventHandler(this.btnTessera_Click);
            // 
            // btnTutti
            // 
            this.btnTutti.Location = new System.Drawing.Point(430, 4);
            this.btnTutti.Margin = new System.Windows.Forms.Padding(2);
            this.btnTutti.Name = "btnTutti";
            this.btnTutti.Size = new System.Drawing.Size(72, 23);
            this.btnTutti.TabIndex = 16;
            this.btnTutti.Text = "Tutti";
            this.btnTutti.UseVisualStyleBackColor = true;
            this.btnTutti.Click += new System.EventHandler(this.btnTutti_Click);
            // 
            // lblpage
            // 
            this.lblpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblpage.AutoSize = true;
            this.lblpage.Location = new System.Drawing.Point(190, 14);
            this.lblpage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(35, 13);
            this.lblpage.TabIndex = 15;
            this.lblpage.Text = "label1";
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrevPage.Location = new System.Drawing.Point(98, 5);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(75, 23);
            this.btnPrevPage.TabIndex = 13;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLastPage.Location = new System.Drawing.Point(325, 5);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(75, 23);
            this.btnLastPage.TabIndex = 14;
            this.btnLastPage.Text = "Ultima Pagina";
            this.btnLastPage.UseVisualStyleBackColor = false;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnNxtPage
            // 
            this.btnNxtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNxtPage.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNxtPage.Location = new System.Drawing.Point(244, 5);
            this.btnNxtPage.Name = "btnNxtPage";
            this.btnNxtPage.Size = new System.Drawing.Size(75, 23);
            this.btnNxtPage.TabIndex = 11;
            this.btnNxtPage.Text = ">";
            this.btnNxtPage.UseVisualStyleBackColor = false;
            this.btnNxtPage.Click += new System.EventHandler(this.btnNxtPage_Click);
            // 
            // btnFirstPAge
            // 
            this.btnFirstPAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPAge.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFirstPAge.Location = new System.Drawing.Point(17, 5);
            this.btnFirstPAge.Name = "btnFirstPAge";
            this.btnFirstPAge.Size = new System.Drawing.Size(75, 23);
            this.btnFirstPAge.TabIndex = 12;
            this.btnFirstPAge.Text = "Prima Pagina";
            this.btnFirstPAge.UseVisualStyleBackColor = false;
            this.btnFirstPAge.Click += new System.EventHandler(this.btnFirstPAge_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gsa_acse.Properties.Resources.acse;
            this.pictureBox1.Location = new System.Drawing.Point(10, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "Numero Tessera:";
            // 
            // txtNumeroTessera
            // 
            this.txtNumeroTessera.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumeroTessera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroTessera.Enabled = false;
            this.txtNumeroTessera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroTessera.Location = new System.Drawing.Point(398, 24);
            this.txtNumeroTessera.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroTessera.MaxLength = 5;
            this.txtNumeroTessera.Name = "txtNumeroTessera";
            this.txtNumeroTessera.Size = new System.Drawing.Size(172, 26);
            this.txtNumeroTessera.TabIndex = 23;
            this.txtNumeroTessera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Cognome:";
            // 
            // txtCognome
            // 
            this.txtCognome.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCognome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCognome.Enabled = false;
            this.txtCognome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCognome.Location = new System.Drawing.Point(398, 58);
            this.txtCognome.Margin = new System.Windows.Forms.Padding(2);
            this.txtCognome.MaxLength = 50;
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(172, 26);
            this.txtCognome.TabIndex = 25;
            this.txtCognome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(243, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(398, 92);
            this.txtNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(172, 26);
            this.txtNome.TabIndex = 27;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbM
            // 
            this.rbM.AutoSize = true;
            this.rbM.BackColor = System.Drawing.SystemColors.Window;
            this.rbM.Enabled = false;
            this.rbM.Location = new System.Drawing.Point(42, 13);
            this.rbM.Margin = new System.Windows.Forms.Padding(2);
            this.rbM.Name = "rbM";
            this.rbM.Size = new System.Drawing.Size(34, 17);
            this.rbM.TabIndex = 28;
            this.rbM.TabStop = true;
            this.rbM.Text = "M";
            this.rbM.UseVisualStyleBackColor = false;
            // 
            // rbF
            // 
            this.rbF.AutoSize = true;
            this.rbF.BackColor = System.Drawing.SystemColors.Window;
            this.rbF.Enabled = false;
            this.rbF.Location = new System.Drawing.Point(100, 13);
            this.rbF.Margin = new System.Windows.Forms.Padding(2);
            this.rbF.Name = "rbF";
            this.rbF.Size = new System.Drawing.Size(31, 17);
            this.rbF.TabIndex = 29;
            this.rbF.TabStop = true;
            this.rbF.Text = "F";
            this.rbF.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbM);
            this.groupBox1.Controls.Add(this.rbF);
            this.groupBox1.Location = new System.Drawing.Point(398, 119);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(171, 37);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 31;
            this.label4.Text = "Sesso:";
            // 
            // txtLuogoNascita
            // 
            this.txtLuogoNascita.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLuogoNascita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLuogoNascita.Enabled = false;
            this.txtLuogoNascita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuogoNascita.Location = new System.Drawing.Point(398, 164);
            this.txtLuogoNascita.Margin = new System.Windows.Forms.Padding(2);
            this.txtLuogoNascita.MaxLength = 50;
            this.txtLuogoNascita.Name = "txtLuogoNascita";
            this.txtLuogoNascita.Size = new System.Drawing.Size(172, 26);
            this.txtLuogoNascita.TabIndex = 32;
            this.txtLuogoNascita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDataNascita
            // 
            this.txtDataNascita.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDataNascita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataNascita.Enabled = false;
            this.txtDataNascita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataNascita.Location = new System.Drawing.Point(578, 164);
            this.txtDataNascita.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataNascita.MaxLength = 50;
            this.txtDataNascita.Name = "txtDataNascita";
            this.txtDataNascita.Size = new System.Drawing.Size(172, 26);
            this.txtDataNascita.TabIndex = 33;
            this.txtDataNascita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(243, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 34;
            this.label5.Text = "Nazionalità:";
            // 
            // txtNazione
            // 
            this.txtNazione.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNazione.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNazione.Enabled = false;
            this.txtNazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNazione.Location = new System.Drawing.Point(398, 204);
            this.txtNazione.Margin = new System.Windows.Forms.Padding(2);
            this.txtNazione.MaxLength = 50;
            this.txtNazione.Name = "txtNazione";
            this.txtNazione.Size = new System.Drawing.Size(172, 26);
            this.txtNazione.TabIndex = 35;
            this.txtNazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnScheda
            // 
            this.btnScheda.Location = new System.Drawing.Point(581, 25);
            this.btnScheda.Margin = new System.Windows.Forms.Padding(2);
            this.btnScheda.Name = "btnScheda";
            this.btnScheda.Size = new System.Drawing.Size(167, 24);
            this.btnScheda.TabIndex = 36;
            this.btnScheda.Text = "Scheda Completa";
            this.btnScheda.UseVisualStyleBackColor = true;
            this.btnScheda.Click += new System.EventHandler(this.btnScheda_Click);
            // 
            // pictureFoto
            // 
            this.pictureFoto.BackColor = System.Drawing.SystemColors.Window;
            this.pictureFoto.Location = new System.Drawing.Point(768, 25);
            this.pictureFoto.Margin = new System.Windows.Forms.Padding(2);
            this.pictureFoto.Name = "pictureFoto";
            this.pictureFoto.Size = new System.Drawing.Size(153, 210);
            this.pictureFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFoto.TabIndex = 37;
            this.pictureFoto.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(244, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 24);
            this.label6.TabIndex = 38;
            this.label6.Text = "Nato:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnNuovaScheda
            // 
            this.btnNuovaScheda.Location = new System.Drawing.Point(581, 58);
            this.btnNuovaScheda.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuovaScheda.Name = "btnNuovaScheda";
            this.btnNuovaScheda.Size = new System.Drawing.Size(167, 24);
            this.btnNuovaScheda.TabIndex = 39;
            this.btnNuovaScheda.Text = "Nuova Scheda";
            this.btnNuovaScheda.UseVisualStyleBackColor = true;
            this.btnNuovaScheda.Click += new System.EventHandler(this.btnNuovaScheda_Click);
            // 
            // btnAssegnaPacco
            // 
            this.btnAssegnaPacco.Location = new System.Drawing.Point(581, 204);
            this.btnAssegnaPacco.Margin = new System.Windows.Forms.Padding(2);
            this.btnAssegnaPacco.Name = "btnAssegnaPacco";
            this.btnAssegnaPacco.Size = new System.Drawing.Size(167, 24);
            this.btnAssegnaPacco.TabIndex = 40;
            this.btnAssegnaPacco.Text = "Pacco Assegnato";
            this.btnAssegnaPacco.UseVisualStyleBackColor = true;
            this.btnAssegnaPacco.Click += new System.EventHandler(this.btnAssegnaPacco_Click);
            // 
            // txtFamigliaOggi
            // 
            this.txtFamigliaOggi.BackColor = System.Drawing.SystemColors.Window;
            this.txtFamigliaOggi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFamigliaOggi.Enabled = false;
            this.txtFamigliaOggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFamigliaOggi.Location = new System.Drawing.Point(21, 39);
            this.txtFamigliaOggi.Margin = new System.Windows.Forms.Padding(2);
            this.txtFamigliaOggi.Name = "txtFamigliaOggi";
            this.txtFamigliaOggi.Size = new System.Drawing.Size(54, 19);
            this.txtFamigliaOggi.TabIndex = 41;
            this.txtFamigliaOggi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSingoliOggi
            // 
            this.txtSingoliOggi.BackColor = System.Drawing.SystemColors.Window;
            this.txtSingoliOggi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSingoliOggi.Enabled = false;
            this.txtSingoliOggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSingoliOggi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSingoliOggi.Location = new System.Drawing.Point(79, 39);
            this.txtSingoliOggi.Margin = new System.Windows.Forms.Padding(2);
            this.txtSingoliOggi.Name = "txtSingoliOggi";
            this.txtSingoliOggi.Size = new System.Drawing.Size(54, 19);
            this.txtSingoliOggi.TabIndex = 42;
            this.txtSingoliOggi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaliOggi
            // 
            this.txtTotaliOggi.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotaliOggi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotaliOggi.Enabled = false;
            this.txtTotaliOggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotaliOggi.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotaliOggi.Location = new System.Drawing.Point(21, 90);
            this.txtTotaliOggi.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotaliOggi.Name = "txtTotaliOggi";
            this.txtTotaliOggi.Size = new System.Drawing.Size(112, 19);
            this.txtTotaliOggi.TabIndex = 43;
            this.txtTotaliOggi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 24);
            this.label7.TabIndex = 44;
            this.label7.Text = "Fam.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 24);
            this.label8.TabIndex = 45;
            this.label8.Text = "Sing.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 24);
            this.label9.TabIndex = 46;
            this.label9.Text = "Totali";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.txtFamigliaOggi);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtSingoliOggi);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtTotaliOggi);
            this.panel2.Controls.Add(this.label7);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(12, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 124);
            this.panel2.TabIndex = 47;
            // 
            // txtTesseraRitiroPacco
            // 
            this.txtTesseraRitiroPacco.BackColor = System.Drawing.SystemColors.Window;
            this.txtTesseraRitiroPacco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTesseraRitiroPacco.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTesseraRitiroPacco.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTesseraRitiroPacco.Location = new System.Drawing.Point(642, 243);
            this.txtTesseraRitiroPacco.Margin = new System.Windows.Forms.Padding(2);
            this.txtTesseraRitiroPacco.Name = "txtTesseraRitiroPacco";
            this.txtTesseraRitiroPacco.Size = new System.Drawing.Size(106, 19);
            this.txtTesseraRitiroPacco.TabIndex = 47;
            this.txtTesseraRitiroPacco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTesseraRitiroPacco.TextChanged += new System.EventHandler(this.txtTesseraRitiroPacco_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(401, 238);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 24);
            this.label10.TabIndex = 48;
            this.label10.Text = "Numero Tessera che ritira";
            // 
            // FormElenco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 622);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTesseraRitiroPacco);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAssegnaPacco);
            this.Controls.Add(this.btnNuovaScheda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureFoto);
            this.Controls.Add(this.btnScheda);
            this.Controls.Add(this.txtNazione);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataNascita);
            this.Controls.Add(this.txtLuogoNascita);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCognome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumeroTessera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormElenco";
            this.Text = "Elenco";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormElenco_FormClosed);
            this.Load += new System.EventHandler(this.FormElenco_Load);
            this.Shown += new System.EventHandler(this.FormElenco_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNxtPage;
        private System.Windows.Forms.Button btnFirstPAge;
        private System.Windows.Forms.Label lblpage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroTessera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.RadioButton rbM;
        private System.Windows.Forms.RadioButton rbF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLuogoNascita;
        private System.Windows.Forms.TextBox txtDataNascita;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNazione;
        private System.Windows.Forms.Button btnScheda;
        private System.Windows.Forms.PictureBox pictureFoto;
        private System.Windows.Forms.TextBox txtInsertTessera;
        private System.Windows.Forms.Button btnTessera;
        private System.Windows.Forms.Button btnTutti;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNuovaScheda;
        private System.Windows.Forms.Button btnAssegnaPacco;
        private System.Windows.Forms.TextBox txtFamigliaOggi;
        private System.Windows.Forms.TextBox txtSingoliOggi;
        private System.Windows.Forms.TextBox txtTotaliOggi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRicercaCognome;
        private System.Windows.Forms.TextBox txtRicercaNome;
        private System.Windows.Forms.TextBox txtRicercaCognome;
        private System.Windows.Forms.Button btnRicercaNome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTesseraRitiroPacco;
        private System.Windows.Forms.Label label10;
    }
}