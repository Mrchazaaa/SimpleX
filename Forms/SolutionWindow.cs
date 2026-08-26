using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace SimpleX
{
    public partial class SolutionWindow : Form
    {
        private List<DataTable> Iterations = new List<DataTable>(); //may need to be changed back to public
        private List<Bitmap> IterationsGraph = new List<Bitmap>(); //Stores all graphs to be used in printed document
        public List<int> PivotColumns = new List<int>(); //Stores the index of each pivotColumn
        public List<int> PivotRows = new List<int>(); //Stores the index of each pivotRow
        private int IterationLimit; //The number of tableaus that has been used in applying simplex
        private bool firstTimeSetScale = true; //Stores whether or not it is the first time a graph has been viewed. If it is, then appropriate axis scales will be automatically set
        private PrintWindow SolutionsPW; //So that each solutionwindows' print window can be accessed
        public bool numError; //Stores whether or not a number related error has occured

        public SolutionWindow(DataTable passDT, bool single)
        {
            InitializeComponent();

            Tools.parentWindow = this;

            numError = false;

            Iterations.Add(passDT);

            //Sets initial form controls up
            iterationIndex.Maximum = 0;
            MaindataGridView.Columns.Clear();
            MaindataGridView.DataSource = Iterations[0];

            tabPage1.Text = "Tableau"; //Names Tabs
            tabPage2.Text = "Graphical Solution";

            iterationIndex.Maximum = 0; //Sets iteration counter to 0 at start of run time
            iterationIndex.Minimum = 0;

            try
            {
                if (single)
                {
                    PerformSimpleX(); //If single stage simplex is to be applied then apply single stage simplex
                }
                else
                {
                    twoStageWrapper(); //If single stage simplex is not to be applied then apply two stage simplex
                }
            }
            catch (System.IndexOutOfRangeException ) //Catches errors that occure during simplex application that mean simplex application cannot continue
            {
                MessageBox.Show("SimpleX could not be applied to this tableau, are you sure the entered information is correct?");
                this.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("SimpleX could not be applied to this tableau, are you sure the entered information is correct?");
                this.Close();
            }

            if (!Iterations[0].Columns.Contains("z")) //If the initial tableau contains only 2 variables, draw graphs of appropriate dimensions that can later be used in printing
            {
                iterationIndex.Value = 0;

                for (int j = 0; j < Iterations.Count(); j++)
                {
                    iterationIndex.Value = j;
                    IterationsGraph.Add(panel1_Paint());
                }
                pictureBox1.Image = IterationsGraph[IterationsGraph.Count - 1];
            }
            
        }

        public void twoStageWrapper() //The two stage simplex method. First two stage simplex is applied and then single stage simplex is applied
        {
            bool SimpleXIsComplete = false;
            IterationLimit = 0;
            int bigAindex = -1;
            for (int z = 0; z < Iterations[0].Rows.Count; z++)
            {
                if (Tools.toAfloat(Iterations[0].Rows[z]["A"]) != 0)
                {
                    bigAindex = z;
                    break;
                }
            }
            if (bigAindex == -1) //There is no row to apply 
            {
                return;
            }
            while (SimpleXIsComplete == false && IterationLimit < 99) //Keep applying simplex whilst it is not complete and no more than 99 tableaus of working have been used
            {
                float[] Arow = new float[Iterations[0].Columns.Count];
                for (int z = 0; z < Iterations[0].Columns.Count; z++)
                {
                    if (Iterations[IterationLimit].Columns[z].ColumnName != "A" && !Iterations[IterationLimit].Columns[z].ColumnName.Contains('a') && Iterations[IterationLimit].Columns[z].ColumnName != "RHS" && Iterations[IterationLimit].Columns[z].ColumnName != "Num")
                    {
                        Arow[z] = Tools.toAfloat(Iterations[IterationLimit].Rows[bigAindex][z]);
                    }
                    else
                    {
                        Arow[z] = 0;
                    }
                }
                if (Arow.Max() == 0 && Arow.Min() == 0) //If two stage is finished being applied, prepare the table for single stage simplex and apply single stage simplex
                {
                    DataTable completeTwoStage = Iterations[IterationLimit].Copy();
                    completeTwoStage.Columns.Remove("A");
                    for (int z = 0; z < completeTwoStage.Columns.Count; z++)
                    {
                        if (completeTwoStage.Columns[z].ColumnName.Contains('a'))
                        {
                            completeTwoStage.Columns.Remove(completeTwoStage.Columns[z].ColumnName);
                            z--;
                        }
                    }
                    completeTwoStage.Rows.RemoveAt(bigAindex);
                    Iterations.Add(completeTwoStage);
                    PivotColumns.Add(0);
                    PivotRows.Add(0);
                    IterationLimit++;
                    SimpleXIsComplete = true;
                }
                else //If two stage simplex is not finished being applied
                {
                    PivotColumns.Add(SimpleX.FindPivotColumn(Iterations[IterationLimit], true).Item2);
                    PivotRows.Add(2);
                    Iterations.Add(Iterations[IterationLimit].Copy());

                    PivotRows[IterationLimit] = SimpleX.FindPivotRow(Iterations[IterationLimit], PivotColumns[IterationLimit], true); //Find a pivot row

                    //At this point, if a suitable value is not found for the pivotrowvalue, the pivotrow is left at 1

                    for (int y = 0; y < Iterations[IterationLimit].Columns.Count; y++) //The pivot row
                    {
                        if (y != Iterations[IterationLimit].Columns["Num"].Ordinal) //So that simplex is not applied to the "Num Column"
                        {
                            Iterations[IterationLimit + 1].Rows[PivotRows[IterationLimit]][y] = Tools.simplify(Tools.Division(Iterations[IterationLimit].Rows[PivotRows[IterationLimit]][y], Iterations[IterationLimit].Rows[PivotRows[IterationLimit]][PivotColumns[IterationLimit]])); //sets the pivot row (not that the fact that the for loop is inside a for loop does not affect the action as the second for loop is placed in an if statement, and so will only run on 1 instance of the first for loop)
                        }
                    }

                    for (int x = 0; x < Iterations[IterationLimit].Rows.Count; x++) //Sets cell values of next tableau
                    {
                        if (!(Tools.toAfloat(Iterations[IterationLimit].Rows[x][PivotColumns[IterationLimit]]) == 0) && !(x == PivotRows[IterationLimit])) //This assures that simplex is not applied to unnecesary rows
                        {
                            for (int g = 0; g < Iterations[IterationLimit].Columns.Count; g++)
                            {
                                if (g != Iterations[IterationLimit].Columns["Num"].Ordinal) //So that simplex is not applied to the "Num Column"
                                {
                                    Iterations[IterationLimit + 1].Rows[x][g] = Tools.simplify(Tools.Subtraction(Iterations[IterationLimit].Rows[x][g], Tools.Multiplication(Iterations[IterationLimit + 1].Rows[PivotRows[IterationLimit]][g], (Iterations[IterationLimit].Rows[x][PivotColumns[IterationLimit]])))); //Check this, trust noone, not even yourself
                                                                                                                                                                                                                                                                                                                       //Iterations[IterationLimit + 1].Rows[x][g] = Tools.Subtraction(Iterations[IterationLimit].Rows[x][g], Tools.Multiplication(,));
                                }
                            }
                        }
                        Iterations[IterationLimit + 1].Rows[x][Iterations[IterationLimit].Columns["Num"].Ordinal] = Tools.toAfloat(Iterations[IterationLimit + 1].Rows[x][Iterations[IterationLimit].Columns["Num"].Ordinal]) + Convert.ToInt32(Iterations[IterationLimit].Rows.Count); //Sets number column of next tableau
                    }

                    IterationLimit++; //Used to cycle through iterations (tableau list)
                }
            }
            PerformSimpleX(); //apply single stage simplex when two stage simplex is finished being applied
        }

        public void PerformSimpleX()
        {
            bool SimpleXIsComplete = false; //Needed to end the while loop
            //IterationLimit = Iterations.Count - 1;

            while (SimpleXIsComplete == false && Iterations.Count < 99) //As only 100 datatables were created
            {
                //--------------------------------------------------------------------------------PivotColumn-------------------------------------------------------------------------

                Tuple<bool, int> isSimpleXCompleteandPivotColumn = SimpleX.FindPivotColumn(Iterations[IterationLimit], false); //Returns a tuple that contains the pivot column and if the simplex is complete (I.E: If no pivot column can be determined)

                if (!isSimpleXCompleteandPivotColumn.Item1) //Iff simplex isn't complete
                {
                    PivotColumns.Add(isSimpleXCompleteandPivotColumn.Item2);
                    PivotRows.Add(2); //A value is set for the pivot row here so that if a suitable value is not found it does not pivot on the constraint row
                    Iterations.Add(Iterations[IterationLimit].Copy());

                    PivotRows[IterationLimit] = SimpleX.FindPivotRow(Iterations[IterationLimit], PivotColumns[IterationLimit], false);

                    //At this point, if a suitable value is not found for the pivotrowvalue, the pivotrow is left at 2

                    for (int y = 0; y < Iterations[IterationLimit].Columns.Count; y++) //The pivot row
                    {
                        if (y != Iterations[IterationLimit].Columns["Num"].Ordinal) //So that simplex is not applied to the "Num Column"
                        {
                            Iterations[IterationLimit + 1].Rows[PivotRows[IterationLimit]][y] = Tools.simplify(Tools.Division(Iterations[IterationLimit].Rows[PivotRows[IterationLimit]][y], Iterations[IterationLimit].Rows[PivotRows[IterationLimit]][PivotColumns[IterationLimit]])); //sets the pivot row (not that the fact that the for loop is inside a for loop does not affect the action as the second for loop is placed in an if statement, and so will only run on 1 instance of the first for loop)
                        }
                    }

                    for (int x = 0; x < Iterations[IterationLimit].Rows.Count; x++) //Sets cell values of next tableau
                    {
                        if (!(Tools.toAfloat(Iterations[IterationLimit].Rows[x][PivotColumns[IterationLimit]]) == 0) && !(x == PivotRows[IterationLimit])) //To assure that simplex is not applied uneccesarily to rows that do not need to be altered
                        {
                            for (int g = 0; g < Iterations[IterationLimit].Columns.Count; g++)
                            {
                                if (g != Iterations[IterationLimit].Columns["Num"].Ordinal) //So that simplex is not applied to the "Num Column"
                                {
                                    Iterations[IterationLimit + 1].Rows[x][g] = Tools.simplify(Tools.Subtraction(Iterations[IterationLimit].Rows[x][g], Tools.Multiplication(Iterations[IterationLimit + 1].Rows[PivotRows[IterationLimit]][g], (Iterations[IterationLimit].Rows[x][PivotColumns[IterationLimit]])))); //Check this, trust noone, not even yourself
                                }
                            }
                        }
                        Iterations[IterationLimit + 1].Rows[x][Iterations[IterationLimit].Columns["Num"].Ordinal] = Tools.toAfloat(Iterations[IterationLimit + 1].Rows[x][Iterations[IterationLimit].Columns["Num"].Ordinal]) + Convert.ToInt32(Iterations[IterationLimit].Rows.Count); //Sets number column of next tableau
                    }

                    IterationLimit++; //Cycles through iterations (datatable list)
                }
                else
                {
                    SimpleXIsComplete = true;
                }
            }

            iterationIndex.Maximum = IterationLimit; //Sets the maximum value that the iterations updown can go to, dependant on the number of datatables required to complete the simplex
            iterationIndex.Value = IterationLimit; //Sets the tableau that the user is viewing the the last tableau (The solution tableau)
        }

        private void iterationValueChanged(object sender, EventArgs e) //Switch tableau being viewed
        {
            MaindataGridView.Columns.Clear();

            MaindataGridView.DataSource = Iterations[Convert.ToInt32(iterationIndex.Value)];
            
            if (iterationIndex.Value != iterationIndex.Maximum)
            {
                MaindataGridView.Columns[Convert.ToInt32(PivotColumns[(int)iterationIndex.Value])].DefaultCellStyle.BackColor = Color.Green; //Sets color of pivotcolumn
                MaindataGridView.Rows[Convert.ToInt32(PivotRows[(int)iterationIndex.Value])].DefaultCellStyle.BackColor = Color.Orange;//Sets color of pivotrow
            }

            if (!Iterations[0].Columns.Contains("z")) //If the tableau in question only has 2 variables draw a graph corresponding to the tableau being viewed
            {
                pictureBox1.Image = panel1_Paint();
            }
        }

        private void redrawGraph(object sender, EventArgs e) //Called when scales are changed or size is changed
        {
            if (!Iterations[0].Columns.Contains("z")) //If tableau only contains 2 variables redraw graph
            {
                pictureBox1.Refresh();
                pictureBox1.Image = panel1_Paint();
            }
        }

        private Bitmap panel1_Paint()
        {
            Bitmap graph1 = new Bitmap(pictureBox1.Width, pictureBox1.Height); //New canvas for graph
            int XAxisLength = Convert.ToInt32((pictureBox1.Width * 0.9)); //The length in pixels of the x axis
            int YAxisLength = Convert.ToInt32(pictureBox1.Height * 0.8); //The length in pixels of the y axis
            int XpixelsPerMark = Convert.ToInt32(XAxisLength / 10); //How many pixels inbetween notches on the x axis
            int YpixelsPerMark = Convert.ToInt32(YAxisLength / 10); //How many pixels inbetween notches on the y axis
            float XpixelsPerUnit = Tools.toAfloat(XpixelsPerMark / XUnitsUpDown.Value); //How many pixels represent one unit of the x axis
            float YpixelsPerUnit = Tools.toAfloat(YpixelsPerMark / YUnitsUpDown.Value); //How many pixels represent one unit of the y axis
            List<float> verticeValues = new List<float>();
            Graphics graphGraphics = Graphics.FromImage(graph1);
            Point Origin = new Point(Convert.ToInt32(pictureBox1.Width * 0.05), pictureBox1.Height - Convert.ToInt32(pictureBox1.Height * 0.10));
            graphGraphics.DrawLine(new Pen(Color.Black), Origin.X, Origin.Y, Origin.X + XAxisLength, Origin.Y); //Draw the X Axis
            graphGraphics.DrawLine(new Pen(Color.Black), Origin.X, Origin.Y, Origin.X, Origin.Y - YAxisLength); //Draw Y Axis

            for (int x = 0; x <= 10; x++)
            {
                graphGraphics.DrawLine(new Pen(Color.Black), 
                    Origin.X + (x * XpixelsPerMark), 
                    Origin.Y + 4, 
                    Origin.X + (x * XpixelsPerMark), 
                    Origin.Y - 4); // Draws marks on X axis

                graphGraphics.DrawString(Convert.ToString(x * XUnitsUpDown.Value), 
                    new Font("Cambria Math", pictureBox1.Height > 475 ? Convert.ToInt32(pictureBox1.Height * 0.018) : 9), 
                    new SolidBrush(Color.Black), 
                    Origin.X + (x * XpixelsPerMark), 
                    pictureBox1.Height - 50); //Writes units on X axis

                graphGraphics.DrawLine(new Pen(Color.Black), 
                    Origin.X + 4, 
                    Origin.Y - (x * YpixelsPerMark), 
                    Origin.X - 4, 
                    Origin.Y - (x * YpixelsPerMark)); // Draws marks on Y axis


                graphGraphics.DrawString(Convert.ToString(x * YUnitsUpDown.Value), 
                    new Font("Cambria Math", pictureBox1.Height > 475 ? Convert.ToInt32(pictureBox1.Height * 0.018) : 9), 
                    new SolidBrush(Color.Black), 
                    Origin.X - 16 - (Convert.ToString(x * YUnitsUpDown.Value).Length * Convert.ToInt32(pictureBox1.Height * 0.01)), 
                    Origin.Y - ((x + 1) * YpixelsPerMark)); // Writes units on Y axis 
            }

            for (int z = 0; z < Iterations[0].Rows.Count; z++) //Cycles through each constrint row in the simplex problem
            {
                if (Tools.toAfloat(Iterations[0].Rows[z]["P"]) == 0) //Do not draw the objective row
                {
                    float[] line = new float[4];
                    if (Tools.toAfloat(Iterations[0].Rows[z]["x"]) != 0 && Tools.toAfloat(Iterations[0].Rows[z]["y"]) == 0) //If the line is of the form y = something
                    {
                        line[0] = Origin.X + (Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["x"])) * XpixelsPerUnit ); //Xcoordinate
                        line[1] = Origin.Y;
                        line[2] = Origin.X + (Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["x"])) * XpixelsPerUnit); //Xcoordinate
                        line[3] = Origin.Y - YAxisLength;
                        verticeValues.Add(Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["x"]))); //Add line to list of lines to be drawn
                    }
                    else if (Tools.toAfloat(Iterations[0].Rows[z]["y"]) != 0 && Tools.toAfloat(Iterations[0].Rows[z]["x"]) == 0) //If the line is of the form x = something
                    {
                        line[0] = Origin.X;
                        line[1] = Origin.Y - Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["y"])) * YpixelsPerUnit; //Ycoordinate
                        line[2] = Origin.X + XAxisLength;
                        line[3] = Origin.Y - Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["y"])) * YpixelsPerUnit; //Ycoordinate
                        verticeValues.Add(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["y"])); //Add line to list of lines to be drawn
                    }
                    else if (Tools.toAfloat(Iterations[0].Rows[z]["y"]) == 0 && Tools.toAfloat(Iterations[0].Rows[z]["x"]) == 0) //If line is non-existent
                    {
                        line[0] = Origin.X;
                        line[1] = Origin.Y;
                        line[2] = Origin.X;
                        line[3] = Origin.Y;
                        verticeValues.Add(0); //Add line to list of lines to be drawn
                    }
                    else //If line is not paralell to either axis
                    {
                        line[0] = Origin.X + Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["x"])) * XpixelsPerUnit; //Xcoordinate
                        line[1] = Origin.Y;
                        line[2] = Origin.X;
                        line[3] = Origin.Y - Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["y"]) * YpixelsPerUnit); //Ycoordinate
                        verticeValues.Add(Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["x"])) 
                                       > Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["y"]))
                                       ?
                                       Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["x"])) :
                                       Tools.toAfloat(Tools.toAfloat(Iterations[0].Rows[z]["RHS"]) / Tools.toAfloat(Iterations[0].Rows[z]["y"])
                                       ));
                    }

                    graphGraphics.DrawLine(new Pen(Color.Blue) ,line[0], line[1], line[2], line[3]);
                }
            }
            float CheckingPointX = 0; //Represents xcoordinate of checking point mark on graph
            float CheckingPointY = 0;//Represents ycoordinate of checking point mark on graph
            string CheckingPointxStr = "0";//Represents text displayed to user of xcoordinate of checking point mark on graph
            string CheckingPointyStr = "0";//Represents text displayed to user of ycoordinate of checking point mark on graph
            Dictionary<int, float> XindexValue = new Dictionary<int, float>();
            Dictionary<int, float> YindexValue = new Dictionary<int, float>();

            for (int z = 0; z < Iterations[(int)iterationIndex.Value].Rows.Count; z++)
            {
                XindexValue.Add(z, Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[z]["x"]));
                YindexValue.Add(z, Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[z]["y"]));
            }

            if (XindexValue.Count(x => x.Value != 0) == 1) //Find xcoordinate of checking point
            {
                if (Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[XindexValue.FirstOrDefault(x => x.Value != 0 ).Key]["P"]) != 0)
                {
                    CheckingPointX = 0;
                    CheckingPointxStr = "0";
                }
                else
                {
                    CheckingPointX = Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[XindexValue.FirstOrDefault(x => x.Value != 0).Key]["RHS"]) / Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[XindexValue.FirstOrDefault(x => x.Value != 0).Key]["x"]);
                    CheckingPointxStr = Convert.ToString(Tools.Division(Iterations[(int)iterationIndex.Value].Rows[XindexValue.FirstOrDefault(x => x.Value != 0).Key]["RHS"], Iterations[(int)iterationIndex.Value].Rows[XindexValue.FirstOrDefault(x => x.Value != 0).Key]["x"]));
                }
            }
            else
            {
                CheckingPointX = 0;
                CheckingPointxStr = "0";
            }

            if (YindexValue.Count(x => x.Value != 0) == 1) //Find ycoordinate of checking point
            {
                if (Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[YindexValue.FirstOrDefault(x => x.Value != 0).Key]["P"]) != 0)
                {
                    CheckingPointY = 0;
                    CheckingPointyStr = "0";
                }
                else
                {
                    CheckingPointY = Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[YindexValue.FirstOrDefault(x => x.Value != 0).Key]["RHS"]) / Tools.toAfloat(Iterations[(int)iterationIndex.Value].Rows[YindexValue.FirstOrDefault(x => x.Value != 0).Key]["y"]);
                    CheckingPointyStr = Convert.ToString(Tools.Division(Iterations[(int)iterationIndex.Value].Rows[YindexValue.FirstOrDefault(x => x.Value != 0).Key]["RHS"], Iterations[(int)iterationIndex.Value].Rows[YindexValue.FirstOrDefault(x => x.Value != 0).Key]["y"]));
                }
            }
            else
            {
                CheckingPointY = 0;
                CheckingPointyStr = "0";
            }

            CheckingPointX *= XpixelsPerUnit;
            CheckingPointY *= YpixelsPerUnit;

            graphGraphics.DrawLine(new Pen(Color.Red), Origin.X + (CheckingPointX - Tools.toAfloat(pictureBox1.Height * 0.02)), Origin.Y - (CheckingPointY - Tools.toAfloat(pictureBox1.Height * 0.02)), Origin.X + (CheckingPointX + Tools.toAfloat(pictureBox1.Height * 0.02)), Origin.Y - (CheckingPointY + Tools.toAfloat(pictureBox1.Height * 0.02)));
            graphGraphics.DrawLine(new Pen(Color.Red), Origin.X + (CheckingPointX + Tools.toAfloat(pictureBox1.Height * 0.02)), Origin.Y - (CheckingPointY - Tools.toAfloat(pictureBox1.Height * 0.02)), Origin.X + (CheckingPointX - Tools.toAfloat(pictureBox1.Height * 0.02)), Origin.Y - (CheckingPointY + Tools.toAfloat(pictureBox1.Height * 0.02)));
            CheckingPointBox.Text = CheckingPointxStr + ", " + CheckingPointyStr;

            if (firstTimeSetScale) //So that the first time the user views the graph an appropriate scale is used
            {
                firstTimeSetScale = false;
                XUnitsUpDown.Value = (int)Math.Ceiling(verticeValues.Max() / 9) <= 1000 && (int)Math.Ceiling(verticeValues.Max() / 9) > 0 ? (int)Math.Ceiling(verticeValues.Max() / 9) : 1000;
                YUnitsUpDown.Value = (int)Math.Ceiling(verticeValues.Max() / 9) <= 1000 && (int)Math.Ceiling(verticeValues.Max() / 9) > 0 ? (int)Math.Ceiling(verticeValues.Max() / 9) : 1000;
            }

            return graph1;
        }

        private void printButtonClick(object sender, EventArgs e) //Print button click
        {
            PrintWindow pw = new PrintWindow(Iterations, IterationsGraph, PivotRows, PivotColumns); //Open a new printwindow form
            SolutionsPW = pw;
            pw.Show();
        }

        private void tableauColumnAdded(object sender, DataGridViewColumnEventArgs e) //This function is used to stop any columns that are added being sortable
        {
          foreach (DataGridViewColumn dgvc in MaindataGridView.Columns)
          {
              dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
           }
        }

        private void formClosed(object sender, FormClosedEventArgs e) //This function closes the printwindow form that belongs to this solutionwindow if there exists one
        {
            if (SolutionsPW != null)
            {
                SolutionsPW.Close();
            }
        }
    }
}
