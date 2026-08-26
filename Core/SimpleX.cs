using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace SimpleX
{
    static class SimpleX
    {
        public static Tuple<bool, int> FindPivotColumn(DataTable iterations, bool twoStage)
        {
            int PivotColumn = 0;
            float pivotcolumnvalue = 0;

            foreach (DataColumn dc in iterations.Columns) //find pivot column
            {
                if (((dc.ColumnName != "Num") && (dc.ColumnName != "RHS") && (dc.ColumnName != "P")) && !(dc.ColumnName.Contains('a')) && (dc.ColumnName != "A") && ((Tools.toAfloat(iterations.Rows[0][dc]) < pivotcolumnvalue && !twoStage) || (Tools.toAfloat(iterations.Rows[0][dc]) > pivotcolumnvalue && twoStage)))
                {
                    pivotcolumnvalue = Tools.toAfloat(iterations.Rows[0][dc]);
                    PivotColumn = dc.Ordinal;
                }
            }
            
            return pivotcolumnvalue == 0 ? Tuple.Create(true, PivotColumn) : Tuple.Create(false, PivotColumn); //If no pivot column can be found then return that simplex is complete
        }

        public static int FindPivotRow(DataTable iterations, int pivotColumn, bool twoStage)
        {
            Dictionary<int, float> OrdinalValue = new Dictionary<int, float>();

            for (int rowIndex = 0; rowIndex < iterations.Rows.Count; rowIndex++) //find a pivot row
            {
                if (!twoStage)
                {
                    if ((Tools.toAfloat(iterations.Rows[rowIndex]["RHS"]) > 0) && (Tools.toAfloat(iterations.Rows[rowIndex][pivotColumn]) > 0) && Tools.toAfloat(iterations.Rows[rowIndex]["P"]) == 0)
                    {
                        OrdinalValue.Add(rowIndex, (Tools.toAfloat(iterations.Rows[rowIndex]["RHS"])) / (Tools.toAfloat(iterations.Rows[rowIndex][pivotColumn])));
                    }
                }
                else
                {
                    if ((Tools.toAfloat(iterations.Rows[rowIndex]["RHS"]) > 0) && (Tools.toAfloat(iterations.Rows[rowIndex][pivotColumn]) > 0) && Tools.toAfloat(iterations.Rows[rowIndex]["P"]) == 0 && Tools.toAfloat(iterations.Rows[rowIndex]["A"]) == 0)
                    {
                        OrdinalValue.Add(rowIndex, (Tools.toAfloat(iterations.Rows[rowIndex]["RHS"])) / (Tools.toAfloat(iterations.Rows[rowIndex][pivotColumn])));
                    }
                }
            }
            if (OrdinalValue.Count == 0) //Only zeros or negative numbers in the list
            {
                return -1;
            }

            float minValue = OrdinalValue.Values.Min();
            int pivotRow = OrdinalValue.FirstOrDefault(x => x.Value == minValue).Key;
            return pivotRow;
        }
    }
}
