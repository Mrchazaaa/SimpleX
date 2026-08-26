using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleX
{
    public partial class Start : Form
    {
        public static bool displayFrac = true;
        public Start()
        {
            InitializeComponent();
        }

        private void newMenuStripClick(object sender, EventArgs e)//New problem button
        {
            UserInputWindow NewQuest = new UserInputWindow();
            NewQuest.MdiParent = this;
            NewQuest.Show();
        }

        private void exitMenuStripClick(object sender, EventArgs e)//Exit button
        {
            this.Close();
        }

        private void OnHelpClick(object sender, EventArgs e) //Help Button is clicked
        {
            MessageBox.Show("Program: SimpleX \rCreated by Charlie Howlett, 2015", "Help");
        }

        private void ToggledFrac(object sender, EventArgs e) //The selected display type is changed
        {
            //This code toggles the controls between fractions and decimals whenever either control is clicked

            if (fractionsToolStripMenuItem.Checked) 
            {
                decimalsToolStripMenuItem.CheckState = CheckState.Checked;
                fractionsToolStripMenuItem.CheckState = CheckState.Unchecked;
                displayFrac = false;
            }
            else
            {
                fractionsToolStripMenuItem.CheckState = CheckState.Checked;
                decimalsToolStripMenuItem.CheckState = CheckState.Unchecked;
                displayFrac = true;
            }
        }
    }
}
