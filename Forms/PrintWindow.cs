using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleX
{
    public partial class PrintWindow : Form
    {
        List<DataTable> Iterations = new List<DataTable>(); //Stores tableaus of working
        List<Bitmap> IterationsGraph = new List<Bitmap>(); //Stores graphs representing tableaus (if applicable)
        public int usedSpace; //Keeps track of where the next item should be printed on the page so that they do not overlap vertically
        private bool newPage; //Set to true if data must be printed over multiple pages

        public PrintWindow(List<DataTable> Iteration, List<Bitmap> IterationGraph, List<int> PivotRows, List<int> PivotColumns) //Initialize controls and set variables
        {
            InitializeComponent();
            Iterations = Iteration;
            IterationsGraph = IterationGraph;
            comboBox1.Text = "Filled Tableaus"; 
            comboBox2.Text = "Draw Graphs";
        }

        private void closeClick(object sender, EventArgs e) //Form is closed
        {
            this.Close();
        }

        private void okClick(object sender, EventArgs e) //Draw on print document
        {
            PrintPreviewDialog pdg = new PrintPreviewDialog();
            pdg.Document = printDocument;

            pdg.ShowIcon = false;

            if (pdg.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
            z = 0;
        }

        int z = 0; //Variable used to count number of pages

        private void printPage_1(object sender, PrintPageEventArgs e)
        {
            if (newPage)
            {
                z--;
            }

            newPage = false;

            int padding = 50;
            usedSpace = padding;
            DataGridView printDGV = new DataGridView();
            this.Controls.Add(printDGV);
            printDGV.Hide();
            printDGV.ReadOnly = true;
            printDGV.RowHeadersVisible = false;
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;
            printDGV.Width = Convert.ToInt32(pageWidth - (2 * padding));
            printDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            printDGV.AllowUserToAddRows = false;
            printDGV.DefaultCellStyle.SelectionBackColor = printDGV.DefaultCellStyle.BackColor;
            printDGV.DefaultCellStyle.SelectionForeColor = printDGV.DefaultCellStyle.ForeColor;

            for (z = z; z < Iterations.Count && !newPage; z++) //Foreach tableau of working
            {
                if (comboBox1.Text == "Filled Tableaus" && !newPage) //Draw a tableau to the print document
                {
                    printDGV.Columns.Clear();
                    for (int x = 0; x < printDGV.Columns.Count; x++)
                    {
                        printDGV.Columns[x].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    printDGV.DataSource = Iterations[z];

                    int height = 0;
                    foreach (DataGridViewRow row in printDGV.Rows)
                    {
                        height += row.Height;
                    }
                    height += printDGV.ColumnHeadersHeight;

                    printDGV.Height = height + 2;

                    printDGV.ClearSelection();

                    Bitmap BM = new Bitmap(printDGV.Width, printDGV.Height);
                    printDGV.DrawToBitmap(BM, new Rectangle(0, 0, BM.Width, BM.Height));


                    if (usedSpace + padding + BM.Height < 1065) //If the tableau to be drawn does not exceed the page being drawn on, draw it to the page. Else, draw it on a new page.
                    {
                        e.HasMorePages = false;
                        e.Graphics.DrawImage(BM, padding, usedSpace);
                        usedSpace += padding + BM.Height;
                    }
                    else
                    {
                        e.HasMorePages = true;
                        newPage = true;
                    }
                }
                else if (comboBox1.Text == "Empty Tableaus" && !newPage) //If the user has selected "Empty Tableaus" copy the dimensions of the tableau and draw a blank version to the print document 
                {
                    DataTable emptyTable = Iterations[z].Copy();
                    for (int y = 0; y < Iterations[z].Rows.Count; y++)
                    {
                        for (int x = 0; x < Iterations[z].Columns.Count; x++)
                        {
                            emptyTable.Rows[y][x] = " ";
                        }
                    }
                    printDGV.Columns.Clear();
                    for (int x = 0; x < printDGV.Columns.Count; x++)
                    {
                        printDGV.Columns[x].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    printDGV.DataSource = emptyTable;


                    int height = 0;
                    foreach (DataGridViewRow row in printDGV.Rows)
                    {
                        height += row.Height;
                    }
                    height += printDGV.ColumnHeadersHeight;

                    printDGV.Height = height + 2;

                    Bitmap BM = new Bitmap(printDGV.Width, printDGV.Height);

                    printDGV.ClearSelection();

                    if (usedSpace + padding + BM.Height < 1065) //If the tableau to be drawn does not exceed the page being drawn on, draw it to the page. Else, draw it on a new page.
                    {
                        printDGV.DrawToBitmap(BM, new Rectangle(0, 0, BM.Width, BM.Height));
                        e.Graphics.DrawImage(BM, padding, usedSpace);
                        usedSpace += padding + BM.Height;
                        e.HasMorePages = false;
                    }
                    else
                    {
                        e.HasMorePages = true;
                        newPage = true;
                    }
                }
                if ((comboBox2.Text == "Draw Graphs") && !Iterations[0].Columns.Contains("z") && !newPage) //If the user has chosen to print graphs
                {
                    if (usedSpace + padding + IterationsGraph[z].Height < 1065) //If the tableau to be drawn does not exceed the page being drawn on, draw it to the page. Else, draw it on a new page.
                    {
                        e.Graphics.DrawImage(IterationsGraph[z], padding, usedSpace);
                        usedSpace += padding + IterationsGraph[z].Height;
                        e.HasMorePages = false;
                    }
                    else
                    {
                        e.HasMorePages = true;
                        newPage = true;
                    }
                }
            }
        }

    }
}
