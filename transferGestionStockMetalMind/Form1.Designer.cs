namespace transferGestionStockMetalMind
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MonthsComboBoxEnd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MonthsComboBoxStart = new System.Windows.Forms.ComboBox();
            this.TransferBtn = new System.Windows.Forms.Button();
            this.ChantierBtn = new System.Windows.Forms.Button();
            this.MMBtn = new System.Windows.Forms.Button();
            this.ChantierPathTxt = new System.Windows.Forms.TextBox();
            this.MMPathTxt = new System.Windows.Forms.TextBox();
            this.ConsoleListBox = new System.Windows.Forms.ListBox();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.MonthsListView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MonthsComboBoxEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.MonthsComboBoxStart);
            this.groupBox1.Controls.Add(this.TransferBtn);
            this.groupBox1.Controls.Add(this.ChantierBtn);
            this.groupBox1.Controls.Add(this.MMBtn);
            this.groupBox1.Controls.Add(this.ChantierPathTxt);
            this.groupBox1.Controls.Add(this.MMPathTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choisissez les dossiers MetalMind et Chantiers";
            // 
            // MonthsComboBoxEnd
            // 
            this.MonthsComboBoxEnd.FormattingEnabled = true;
            this.MonthsComboBoxEnd.Location = new System.Drawing.Point(354, 106);
            this.MonthsComboBoxEnd.Name = "MonthsComboBoxEnd";
            this.MonthsComboBoxEnd.Size = new System.Drawing.Size(134, 26);
            this.MonthsComboBoxEnd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "fin mois";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "debut mois";
            // 
            // MonthsComboBoxStart
            // 
            this.MonthsComboBoxStart.FormattingEnabled = true;
            this.MonthsComboBoxStart.Location = new System.Drawing.Point(102, 106);
            this.MonthsComboBoxStart.Name = "MonthsComboBoxStart";
            this.MonthsComboBoxStart.Size = new System.Drawing.Size(134, 26);
            this.MonthsComboBoxStart.TabIndex = 7;
            // 
            // TransferBtn
            // 
            this.TransferBtn.Location = new System.Drawing.Point(19, 146);
            this.TransferBtn.Name = "TransferBtn";
            this.TransferBtn.Size = new System.Drawing.Size(469, 29);
            this.TransferBtn.TabIndex = 6;
            this.TransferBtn.Text = "Transferer les donnees vers les chantiers";
            this.TransferBtn.UseVisualStyleBackColor = true;
            this.TransferBtn.Click += new System.EventHandler(this.TransferBtn_Click);
            // 
            // ChantierBtn
            // 
            this.ChantierBtn.Location = new System.Drawing.Point(316, 71);
            this.ChantierBtn.Name = "ChantierBtn";
            this.ChantierBtn.Size = new System.Drawing.Size(172, 26);
            this.ChantierBtn.TabIndex = 4;
            this.ChantierBtn.Text = "Dossier chantiers";
            this.ChantierBtn.UseVisualStyleBackColor = true;
            this.ChantierBtn.Click += new System.EventHandler(this.ChantierBtn_Click);
            // 
            // MMBtn
            // 
            this.MMBtn.Location = new System.Drawing.Point(316, 25);
            this.MMBtn.Name = "MMBtn";
            this.MMBtn.Size = new System.Drawing.Size(172, 26);
            this.MMBtn.TabIndex = 3;
            this.MMBtn.Text = "Dossier MetalMind";
            this.MMBtn.UseVisualStyleBackColor = true;
            this.MMBtn.Click += new System.EventHandler(this.MMBtn_Click);
            // 
            // ChantierPathTxt
            // 
            this.ChantierPathTxt.Location = new System.Drawing.Point(19, 71);
            this.ChantierPathTxt.Name = "ChantierPathTxt";
            this.ChantierPathTxt.ReadOnly = true;
            this.ChantierPathTxt.Size = new System.Drawing.Size(291, 26);
            this.ChantierPathTxt.TabIndex = 1;
            // 
            // MMPathTxt
            // 
            this.MMPathTxt.Location = new System.Drawing.Point(19, 25);
            this.MMPathTxt.Name = "MMPathTxt";
            this.MMPathTxt.ReadOnly = true;
            this.MMPathTxt.Size = new System.Drawing.Size(291, 26);
            this.MMPathTxt.TabIndex = 0;
            // 
            // ConsoleListBox
            // 
            this.ConsoleListBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ConsoleListBox.FormattingEnabled = true;
            this.ConsoleListBox.ItemHeight = 18;
            this.ConsoleListBox.Location = new System.Drawing.Point(12, 209);
            this.ConsoleListBox.Name = "ConsoleListBox";
            this.ConsoleListBox.Size = new System.Drawing.Size(495, 130);
            this.ConsoleListBox.TabIndex = 9;
            // 
            // BGWorker
            // 
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resetBtn);
            this.groupBox2.Controls.Add(this.MonthsListView);
            this.groupBox2.Location = new System.Drawing.Point(513, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 327);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mois finis";
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(6, 284);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(95, 37);
            this.resetBtn.TabIndex = 12;
            this.resetBtn.Text = "Reinitialiser";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // MonthsListView
            // 
            this.MonthsListView.Font = new System.Drawing.Font("Tahoma", 10F);
            this.MonthsListView.Location = new System.Drawing.Point(6, 25);
            this.MonthsListView.MultiSelect = false;
            this.MonthsListView.Name = "MonthsListView";
            this.MonthsListView.Size = new System.Drawing.Size(95, 226);
            this.MonthsListView.TabIndex = 11;
            this.MonthsListView.UseCompatibleStateImageBehavior = false;
            this.MonthsListView.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 348);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ConsoleListBox);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer gestion de stock Metal Mind";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MonthsComboBoxStart;
        private System.Windows.Forms.Button TransferBtn;
        private System.Windows.Forms.Button ChantierBtn;
        private System.Windows.Forms.Button MMBtn;
        private System.Windows.Forms.TextBox ChantierPathTxt;
        private System.Windows.Forms.TextBox MMPathTxt;
        private System.Windows.Forms.ListBox ConsoleListBox;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView MonthsListView;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.ComboBox MonthsComboBoxEnd;
        private System.Windows.Forms.Label label2;
    }
}

