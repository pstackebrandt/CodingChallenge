using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class CheckForEight
    {
        public CheckForEight()
        {
            Console.WriteLine($"{nameof(CheckForEight)} wird erstellt");
            DataProvider = new DataProvider();
        }

        public DataProvider DataProvider { get; }

        public void Run()
        {
            Run(DataProvider.FirstDataSet);
            Run(DataProvider.SecondDataSet);
        }

        private void Run(string dataSetName)
        {
            Console.WriteLine($"{nameof(CheckForEight)}.{nameof(CheckForEight.Run)}()");

            var data = new DataProvider().GetDataSet(dataSetName).ToList();
            var checker = new SumChecker();
            IList<int> positionOfFoundSum;
            int countOfChecks;
            var expectedSum = 8;
            var containsSumResult = checker.ContainsSum(data, expectedSum, positionOfFoundSum: out positionOfFoundSum,
                countOfChecks: out countOfChecks);

            var formattedPositionOfFoundSum = "";
            if (positionOfFoundSum != null && positionOfFoundSum.Count == 2)
            {
                formattedPositionOfFoundSum = $"at position ({positionOfFoundSum[0]}, {positionOfFoundSum[1]})";
            }

            Console.WriteLine(
                $"Sum {expectedSum} found: {containsSumResult} {formattedPositionOfFoundSum} using {countOfChecks} checks.");
        }
    }
}