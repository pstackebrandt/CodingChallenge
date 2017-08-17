using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using CodingChallenge;
using NUnit.Framework;

namespace CodingChallangeTests
{
    [TestFixture]
    public class CheckForFirstSumTests
    {
        [Test]
        [TestCase(DataProvider.FirstDataSet, 8, false, null, null)]
        [TestCase(DataProvider.SecondDataSet, 8, true, 2, 3)]
        public void ShouldFindFirstSum(string dataSetName, int sumToSearch, bool isFindExpected, int? expectedFirstFindPosition, int? expectedSecondFindPosition)
        {
            var provider = new DataProvider();
            var dataSet = provider.GetDataSet(dataSetName).ToList();

            var checker = new SumChecker();
            IList<int> positionOfFoundSum;
            int countOfChecks;

            var actualHasSum = checker.ContainsSum(dataSet, sumToSearch, out positionOfFoundSum, out countOfChecks);

            Assert.AreEqual(isFindExpected, actualHasSum);

            if (isFindExpected)
            {
                Assert.AreEqual(expectedFirstFindPosition, positionOfFoundSum[0]);
                Assert.AreEqual(expectedSecondFindPosition, positionOfFoundSum[1]);
            }
            else
            {
                Assert.IsEmpty(positionOfFoundSum);
            }
        }
    }
}