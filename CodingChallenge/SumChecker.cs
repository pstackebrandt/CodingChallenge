using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    public class SumChecker
    {
        public int GetTotalSum(IList<int> dataSet)
        {
            int sum;

            switch (dataSet.Count)
            {
                case 2:
                    sum = GetSumOfAllSumsOf2NumbersManually(dataSet);
                    break;

                case 3:
                    sum = GetSumOfAllSumsOf3NumbersManually(dataSet);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return sum;
        }

        public int GetSumOfAllSumsOf2NumbersManually(IList<int> dataSet)
        {
            return dataSet[0] + dataSet[1];
        }

        public int GetSumOfAllSumsOf3NumbersManually(IList<int> set)
        {
            var sum01 = set[0] + set[1];
            var sum02 = set[0] + set[2];
            var sum12 = set[1] + set[2];

            return sum01 + sum02 + sum12;
        }

        public int GetSumOfAllSums(IList<int> set)
        {
            var sum = 0;
            var currentFirstSummandPos = 0;

            while (currentFirstSummandPos < set.Count)
            {
                for (var currentSecondSummand = currentFirstSummandPos + 1; currentSecondSummand < set.Count; currentSecondSummand++)
                {
                    var currentSum = set[currentFirstSummandPos] + set[currentSecondSummand];
                    sum = sum + currentSum;
                }

                currentFirstSummandPos++;
            }
            
            return sum;
        }

        public bool ContainsSum(IList<int> set, int expectedSum, out IList<int> positionOfFoundSum, out int countOfChecks)
        {
            var sum = 0;
            var currentFirstSummandPos = 0;
            countOfChecks = 0;

            while (currentFirstSummandPos < set.Count)
            {
                for (var currentSecondSummandPos = currentFirstSummandPos + 1; currentSecondSummandPos < set.Count; currentSecondSummandPos++)
                {
                    var currentSum = set[currentFirstSummandPos] + set[currentSecondSummandPos];
                    countOfChecks++;

                    if (currentSum == expectedSum)
                    {
                        positionOfFoundSum = new List<int> {currentFirstSummandPos, currentSecondSummandPos};
                        return true;
                    }

                    sum = sum + currentSum;
                }

                currentFirstSummandPos++;
            }

            positionOfFoundSum = new List<int>();
            return false;
        }
    }
}