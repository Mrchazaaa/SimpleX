using System;
using System.Data;
using NUnit.Framework;
using NUnitLite;

namespace SimpleX.Tests
{
    [TestFixture]
    public class SimpleXTests
    {
        [Test]
        public void ReportsOptimalWhenNoPivotColumnExists()
        {
            DataTable tableau = CreateTableau("x", "y");
            tableau.Rows.Add("0", "0", "0", "0", "1");

            Tuple<bool, int> result = SimpleX.FindPivotColumn(tableau, false);

            Assert.That(result.Item1, Is.True);
        }

        [Test]
        public void ChoosesMostNegativeEnteringColumn()
        {
            DataTable tableau = CreateTableau("x", "y");
            tableau.Rows.Add("0", "-3", "-7", "0", "1");

            Tuple<bool, int> result = SimpleX.FindPivotColumn(tableau, false);

            Assert.That(result.Item1, Is.False);
            Assert.That(result.Item2, Is.EqualTo(tableau.Columns["y"].Ordinal));
        }

        [Test]
        public void PhaseOneIgnoresArtificialColumns()
        {
            DataTable tableau = CreateTableau("x", "a1", "A");
            tableau.Rows.Add("0", "4", "99", "100", "0", "1");

            Tuple<bool, int> result = SimpleX.FindPivotColumn(tableau, true);

            Assert.That(result.Item1, Is.False);
            Assert.That(result.Item2, Is.EqualTo(tableau.Columns["x"].Ordinal));
        }

        [Test]
        public void ChoosesMinimumEligibleRatio()
        {
            DataTable tableau = CreateTableau("x");
            tableau.Rows.Add("0", "-1", "0", "1");
            tableau.Rows.Add("10", "2", "0", "2");
            tableau.Rows.Add("9", "3", "0", "3");
            tableau.Rows.Add("1", "5", "1", "4");

            int row = SimpleX.FindPivotRow(tableau, tableau.Columns["x"].Ordinal, false);

            Assert.That(row, Is.EqualTo(2));
        }

        [Test]
        public void ReportsNoPivotRowForUnboundedDirection()
        {
            DataTable tableau = CreateTableau("x");
            tableau.Rows.Add("0", "-1", "0", "1");
            tableau.Rows.Add("5", "0", "0", "2");
            tableau.Rows.Add("3", "-2", "0", "3");

            int row = SimpleX.FindPivotRow(tableau, tableau.Columns["x"].Ordinal, false);

            Assert.That(row, Is.EqualTo(-1));
        }

        private static DataTable CreateTableau(params string[] variableColumns)
        {
            DataTable tableau = new DataTable();
            tableau.Columns.Add("RHS");
            foreach (string variableColumn in variableColumns)
            {
                tableau.Columns.Add(variableColumn);
            }
            tableau.Columns.Add("P");
            tableau.Columns.Add("Num");
            return tableau;
        }
    }

    public static class Program
    {
        public static int Main(string[] args)
        {
            return new AutoRun().Execute(args);
        }
    }
}
