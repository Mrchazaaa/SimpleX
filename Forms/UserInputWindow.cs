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
    public partial class UserInputWindow : Form
    {
        public bool WarningBoxHasntBeenAnswered;

        public UserInputWindow()
        {
            InitializeComponent();

            artificialUpDown.Enabled = false;

            inputTableau.DataSource = CreateTable(2, 3, 1, 4);

            foreach (DataGridViewColumn dgvc in inputTableau.Columns) //Make columns not sortable
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            inputTableau.Columns["Num"].ReadOnly = true;
        }

        private void changetableau(object sender, EventArgs e) //Called when radio buttons are changed or the numericupdown values change
        {
            artificialUpDown.Enabled = radioButton1.Checked ? false : true;
            inputTableau.Columns.Clear();
            inputTableau.DataSource = CreateTable(Convert.ToInt32(variableUpDown.Value), Convert.ToInt32(slackUpDown.Value), Convert.ToInt32(artificialUpDown.Value), Convert.ToInt32(rowUpDown.Value)); //Creates new table
            inputTableau.Columns["Num"].ReadOnly = true;
            foreach (DataGridViewColumn dgvc in inputTableau.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable CreateTable(int variables, int Svariables, int Avariables, int rows)
        {
            DataTable dt = new DataTable();

            if (radioButton1.Checked) //Single Stage
            {
                dt.Columns.Clear();
                dt.Columns.Add("P");

                for (int i = 1; i <= variables; i++) //Adds Variable columns
                {
                    switch (i)
                    {
                        case 1:
                            dt.Columns.Add("x").SetOrdinal(i);
                            break;

                        case 2:
                            dt.Columns.Add("y").SetOrdinal(i);
                            break;

                        case 3:
                            dt.Columns.Add("z").SetOrdinal(i);
                            break;

                        case 4:
                            dt.Columns.Add("w").SetOrdinal(i);
                            break;
                    }
                }

                int preSlackVariables = variables + dt.Columns["x"].Ordinal - 1;

                for (int i = 1; i <= Svariables; i++)
                {
                    switch (i)
                    {
                        case 1:
                            dt.Columns.Add("S1").SetOrdinal(preSlackVariables + 1);
                            break;

                        case 2:
                            dt.Columns.Add("S2").SetOrdinal(preSlackVariables + 2);
                            break;

                        case 3:
                            dt.Columns.Add("S3").SetOrdinal(preSlackVariables + 3);
                            break;

                        case 4:
                            dt.Columns.Add("S4").SetOrdinal(preSlackVariables + 4);
                            break;
                    }
                }


            }

            if (radioButton2.Checked) //Two Stage
            {
                dt.Columns.Clear();
                dt.Columns.Add("A");
                dt.Columns.Add("P");

                for (int i = 1; i <= variables; i++)
                {
                    switch (i)
                    {
                        case 1:
                            dt.Columns.Add("x").SetOrdinal(i + 1);
                            break;

                        case 2:
                            dt.Columns.Add("y").SetOrdinal(i + 1);
                            break;

                        case 3:
                            dt.Columns.Add("z").SetOrdinal(i + 1);
                            break;

                        case 4:
                            dt.Columns.Add("w").SetOrdinal(i + 1);
                            break;
                    }
                }

                int preSlackVariables = variables + dt.Columns["x"].Ordinal - 1;

                for (int i = 1; i <= Svariables; i++)
                {
                    switch (i)
                    {
                        case 1:
                            dt.Columns.Add("S1").SetOrdinal(preSlackVariables + 1);
                            break;

                        case 2:
                            dt.Columns.Add("S2").SetOrdinal(preSlackVariables + 2);
                            break;

                        case 3:
                            dt.Columns.Add("S3").SetOrdinal(preSlackVariables + 3);
                            break;

                        case 4:
                            dt.Columns.Add("S4").SetOrdinal(preSlackVariables + 4);
                            break;
                    }
                }

                int preArtificialVariables = Svariables + dt.Columns["S1"].Ordinal - 1;

                for (int i = 1; i <= Avariables; i++)
                {
                    switch (i)
                    {
                        case 1:
                            dt.Columns.Add("a1").SetOrdinal(preArtificialVariables + 1);
                            break;

                        case 2:
                            dt.Columns.Add("a2").SetOrdinal(preArtificialVariables + 2);
                            break;

                        case 3:
                            dt.Columns.Add("a3").SetOrdinal(preArtificialVariables + 3);
                            break;

                        case 4:
                            dt.Columns.Add("a4").SetOrdinal(preArtificialVariables + 4);
                            break;
                    }
                }
            }

            dt.Columns.Add("Num");
            dt.Columns.Add("RHS");

            for (int i = 1; i < rows + 1; i++) //adds rows
            {
                dt.Rows.Add(); //Adds the rows
                dt.Rows[i - 1][ dt.Columns["Num"].Ordinal ] = i; //Numbers the rows in the column "Num"
            }

            foreach (DataGridViewColumn dgvc in inputTableau.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            return dt;
        }

        private void exitButtonClick(object sender, EventArgs e) //Exit Button
        {
            this.Close();
        }

        private void dataGridAddRows(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (inputTableau.Rows.Count > 8)
            {
                try
                {
                    inputTableau.Rows.Remove(inputTableau.Rows[inputTableau.Rows.Count]);
                }
                catch 
                {
                    return;
                }
            }
        }

        private void acceptClick(object sender, EventArgs e)
        {
            WarningBoxHasntBeenAnswered = true;
            List<Point> invalidInput = new List<Point>();
            DataTable passDT = CreateTable(Convert.ToInt32(variableUpDown.Value), Convert.ToInt32(slackUpDown.Value), Convert.ToInt32(artificialUpDown.Value),  Convert.ToInt32(rowUpDown.Value));

            for (int j = 0; j <= inputTableau.Columns.Count - 1; j++)
            {
                for (int i = 0; i <= inputTableau.Rows.Count - 1; i++)
                {
                    if (inputTableau.Columns["Num"].Index != j)
                    {
                        passDT.Rows[i][j] = Tools.simplify(Convert.ToString(inputTableau[j, i].Value));
                    }
                }
            }

            //Validate

            for (int x = 0; x < passDT.Columns.Count; x++)
            {
                for (int y = 0; y < passDT.Rows.Count; y++)
                {
                    if (Convert.ToString(passDT.Rows[y][x]) == "")
                    {
                        invalidInput.Add(new Point(x, y));
                    }

                    //Checks to see if each character is a number, with the exception of "-", "." and "/"
                    for (int Ch = 0; Ch < Convert.ToString(passDT.Rows[y][x]).Length; Ch++)
                    {
                        if (!Char.IsNumber(Convert.ToString(passDT.Rows[y][x])[Ch]))
                        {
                            float uselessFloat; //Used in tryParsing
                            switch (Convert.ToString(passDT.Rows[y][x])[Ch])
                            {
                                case '/':
                                    if (!float.TryParse(Convert.ToString(passDT.Rows[y][x]).Split('/')[0], out uselessFloat) || !float.TryParse(Convert.ToString(passDT.Rows[y][x]).Split('/')[1], out uselessFloat) || Convert.ToString(passDT.Rows[y][x]).Count(z => z == '/') > 1)
                                    {
                                        Ch = Convert.ToString(passDT.Rows[y][x]).Length;
                                        invalidInput.Add(new Point(x, y));
                                    }
                                    if (Convert.ToString(passDT.Rows[y][x]).Length > Ch + 1)
                                    {
                                        if (Convert.ToString(passDT.Rows[y][x])[Ch + 1] == '0')
                                        {
                                            invalidInput.Add(new Point(x, y));
                                        }
                                    }
                                    
                                    break;

                                case '.':
                                    if (Convert.ToString(passDT.Rows[y][x]).Contains('/'))
                                    {
                                        if (!float.TryParse(Convert.ToString(passDT.Rows[y][x]).Split('/')[0], out uselessFloat) || !float.TryParse(Convert.ToString(passDT.Rows[y][x]).Split('/')[1], out uselessFloat))
                                        {
                                            invalidInput.Add(new Point(x, y));
                                            Ch++;
                                        }
                                    }
                                    else if (!Convert.ToString(passDT.Rows[y][x]).Contains('/') && Convert.ToString(passDT.Rows[y][x]).Count(z => z == '.') == 1)
                                    {
                                        if (!float.TryParse(Convert.ToString(passDT.Rows[y][x]), out uselessFloat))
                                        {
                                            invalidInput.Add(new Point(x, y));
                                            Ch++;
                                        }
                                    }
                                    else
                                    {
                                        invalidInput.Add(new Point(x, y));
                                        Ch++;
                                    }
                                    break;

                                case '-':
                                    if (1 > Convert.ToString(passDT.Rows[y][x]).Count(z => z == '-') || 2 < Convert.ToString(passDT.Rows[y][x]).Count(z => z == '-') || Ch != 0)
                                    {
                                        if (!Convert.ToString(passDT.Rows[y][x]).Contains('/'))
                                        {
                                            Ch = Convert.ToString(passDT.Rows[y][x]).Length;
                                            invalidInput.Add(new Point(x, y));
                                        }
                                        else if (Ch != Convert.ToString(passDT.Rows[y][x]).IndexOf('/') + 1)
                                        {
                                            Ch = Convert.ToString(passDT.Rows[y][x]).Length;
                                            invalidInput.Add(new Point(x, y));
                                        }
                                    }
                                    break;

                                default:
                                    invalidInput.Add(new Point(x, y));
                                    Ch = Convert.ToString(passDT.Rows[y][x]).Length;
                                    break;
                            }
                        }
                    }
                }
            }

            DialogResult dialogResult = MessageBox.Show("If you select 'OK' all the cells in the tableau that you have left blank, or that do not contain numerical data, will be replaced with 0's", "Warning", MessageBoxButtons.OKCancel);
            switch (dialogResult)
            {
                case DialogResult.OK:
                    for (int z = 0; z < invalidInput.Count; z++)
                    {
                        passDT.Rows[int.Parse(Convert.ToString(invalidInput[z].Y))][int.Parse(Convert.ToString(invalidInput[z].X))] = "0";
                    }
                    break;
                case DialogResult.Cancel:
                    return;
            }

            for (int i = 0; i < passDT.Columns.Count; i++)
            {
                for (int y = 0; y < passDT.Rows.Count; y++)
                {
                    passDT.Rows[y][i] = Tools.simplify(Convert.ToString(passDT.Rows[y][i]));
                }
            }

            SolutionWindow answer = new SolutionWindow(passDT, radioButton1.Checked ? true : false);

            if (answer.numError)
            {
                MessageBox.Show("Too large of a value was calculated during application of simplex. Please use smaller numbers.");
                answer.Close();
            }
            else
            {
                answer.MdiParent = this.MdiParent;

                answer.Show();
            }
            this.Close();
        }
    }
}
