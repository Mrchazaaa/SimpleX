namespace SimpleX
{
    partial class SolutionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionWindow));
            this.MaindataGridView = new System.Windows.Forms.DataGridView();
            this.tablePage1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckingPointBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.YUnitsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.XUnitsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.iterationIndex = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MaindataGridView)).BeginInit();
            this.tablePage1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUnitsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUnitsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // MaindataGridView
            // 
            this.MaindataGridView.AllowUserToAddRows = false;
            this.MaindataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MaindataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MaindataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaindataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaindataGridView.Location = new System.Drawing.Point(3, 3);
            this.MaindataGridView.Name = "MaindataGridView";
            this.MaindataGridView.ReadOnly = true;
            this.MaindataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.MaindataGridView.RowHeadersVisible = false;
            this.MaindataGridView.Size = new System.Drawing.Size(719, 430);
            this.MaindataGridView.TabIndex = 0;
            this.MaindataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.tableauColumnAdded);
            // 
            // tablePage1
            // 
            this.tablePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePage1.Controls.Add(this.tabPage1);
            this.tablePage1.Controls.Add(this.tabPage2);
            this.tablePage1.Location = new System.Drawing.Point(0, 0);
            this.tablePage1.Name = "tablePage1";
            this.tablePage1.SelectedIndex = 0;
            this.tablePage1.Size = new System.Drawing.Size(733, 462);
            this.tablePage1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MaindataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.CheckingPointBox);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.YUnitsUpDown);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.XUnitsUpDown);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(725, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Checking Point:";
            // 
            // CheckingPointBox
            // 
            this.CheckingPointBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckingPointBox.Location = new System.Drawing.Point(187, 274);
            this.CheckingPointBox.Name = "CheckingPointBox";
            this.CheckingPointBox.Size = new System.Drawing.Size(142, 20);
            this.CheckingPointBox.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(8, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(682, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.redrawGraph);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y-Units:";
            // 
            // YUnitsUpDown
            // 
            this.YUnitsUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.YUnitsUpDown.Location = new System.Drawing.Point(384, 272);
            this.YUnitsUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YUnitsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.YUnitsUpDown.Name = "YUnitsUpDown";
            this.YUnitsUpDown.Size = new System.Drawing.Size(120, 20);
            this.YUnitsUpDown.TabIndex = 3;
            this.YUnitsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.YUnitsUpDown.ValueChanged += new System.EventHandler(this.redrawGraph);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "X-Units:";
            // 
            // XUnitsUpDown
            // 
            this.XUnitsUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.XUnitsUpDown.Location = new System.Drawing.Point(560, 272);
            this.XUnitsUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XUnitsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.XUnitsUpDown.Name = "XUnitsUpDown";
            this.XUnitsUpDown.Size = new System.Drawing.Size(120, 20);
            this.XUnitsUpDown.TabIndex = 1;
            this.XUnitsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.XUnitsUpDown.ValueChanged += new System.EventHandler(this.redrawGraph);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Iteration:";
            // 
            // iterationIndex
            // 
            this.iterationIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iterationIndex.Location = new System.Drawing.Point(657, 486);
            this.iterationIndex.Name = "iterationIndex";
            this.iterationIndex.Size = new System.Drawing.Size(45, 20);
            this.iterationIndex.TabIndex = 2;
            this.iterationIndex.ValueChanged += new System.EventHandler(this.iterationValueChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(503, 470);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 50);
            this.button3.TabIndex = 5;
            this.button3.Text = "Print...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.printButtonClick);
            // 
            // SolutionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 532);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iterationIndex);
            this.Controls.Add(this.tablePage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(612, 570);
            this.Name = "SolutionWindow";
            this.Text = "SimpleX";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            ((System.ComponentModel.ISupportInitialize)(this.MaindataGridView)).EndInit();
            this.tablePage1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUnitsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUnitsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tablePage1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown iterationIndex;
        public System.Windows.Forms.DataGridView MaindataGridView;
        private System.Windows.Forms.NumericUpDown XUnitsUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown YUnitsUpDown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CheckingPointBox;
    }
}

