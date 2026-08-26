namespace SimpleX
{
    partial class UserInputWindow
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.variableUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.inputTableau = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rowUpDown = new System.Windows.Forms.NumericUpDown();
            this.slackUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.artificialUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.variableUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTableau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slackUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artificialUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(124, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Single Stage SimpleX";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.changetableau);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(116, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Two Stage SimpleX";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.changetableau);
            // 
            // variableUpDown
            // 
            this.variableUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.variableUpDown.Location = new System.Drawing.Point(12, 72);
            this.variableUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.variableUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.variableUpDown.Name = "variableUpDown";
            this.variableUpDown.ReadOnly = true;
            this.variableUpDown.Size = new System.Drawing.Size(118, 20);
            this.variableUpDown.TabIndex = 5;
            this.variableUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.variableUpDown.ValueChanged += new System.EventHandler(this.changetableau);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number Of Variables:";
            // 
            // inputTableau
            // 
            this.inputTableau.AllowUserToAddRows = false;
            this.inputTableau.AllowUserToResizeColumns = false;
            this.inputTableau.AllowUserToResizeRows = false;
            this.inputTableau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inputTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputTableau.Dock = System.Windows.Forms.DockStyle.Right;
            this.inputTableau.Location = new System.Drawing.Point(158, 0);
            this.inputTableau.Name = "inputTableau";
            this.inputTableau.RowHeadersVisible = false;
            this.inputTableau.Size = new System.Drawing.Size(530, 298);
            this.inputTableau.TabIndex = 7;
            this.inputTableau.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridAddRows);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.acceptClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.exitButtonClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Number Of Rows:";
            // 
            // rowUpDown
            // 
            this.rowUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rowUpDown.Location = new System.Drawing.Point(12, 110);
            this.rowUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.rowUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.rowUpDown.Name = "rowUpDown";
            this.rowUpDown.ReadOnly = true;
            this.rowUpDown.Size = new System.Drawing.Size(118, 20);
            this.rowUpDown.TabIndex = 10;
            this.rowUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.rowUpDown.ValueChanged += new System.EventHandler(this.changetableau);
            // 
            // slackUpDown
            // 
            this.slackUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.slackUpDown.Location = new System.Drawing.Point(12, 149);
            this.slackUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.slackUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slackUpDown.Name = "slackUpDown";
            this.slackUpDown.ReadOnly = true;
            this.slackUpDown.Size = new System.Drawing.Size(118, 20);
            this.slackUpDown.TabIndex = 12;
            this.slackUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.slackUpDown.ValueChanged += new System.EventHandler(this.changetableau);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Number Of Slack Variables:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Number Of Artificial Variables:";
            // 
            // artificialUpDown
            // 
            this.artificialUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.artificialUpDown.Location = new System.Drawing.Point(11, 187);
            this.artificialUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.artificialUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.artificialUpDown.Name = "artificialUpDown";
            this.artificialUpDown.ReadOnly = true;
            this.artificialUpDown.Size = new System.Drawing.Size(118, 20);
            this.artificialUpDown.TabIndex = 15;
            this.artificialUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.artificialUpDown.ValueChanged += new System.EventHandler(this.changetableau);
            // 
            // UserInputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 298);
            this.Controls.Add(this.artificialUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.slackUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rowUpDown);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputTableau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.variableUpDown);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserInputWindow";
            this.Text = "New Problem";
            ((System.ComponentModel.ISupportInitialize)(this.variableUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTableau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slackUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artificialUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.NumericUpDown variableUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown rowUpDown;
        public System.Windows.Forms.DataGridView inputTableau;
        private System.Windows.Forms.NumericUpDown slackUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown artificialUpDown;
    }
}