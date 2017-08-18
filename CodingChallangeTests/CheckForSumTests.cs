﻿using CodingChallenge;
using NUnit.Framework;

namespace CodingChallangeTests
{
    [TestFixture]
    public class CheckForSumTests
    {
        [Test]

        [TestCase(new int[2] { 1, 2 }, 3)]
        [TestCase(new int[2] { -1, -1 }, -2)]
        [TestCase(new int[3] { 1, 2, 3 }, 12)]
        [TestCase(new int[3] { -1, -2, -3 }, -12)]
        [TestCase(new int[4] { 1, 2, 3, 4 }, 30)]
        [TestCase(new int[3] { 1, 1, 1 }, 6)]
        [TestCase(new int[4] { 1, 1, 1, 1 }, 12)]
        [TestCase(new int[4] { 2, 2, 2, 2 }, 24)]
        public void ShouldReturnSum(int[] dataSet, int expectedSum)
        {
            var actualSum = new SumChecker().GetSumOfAllSums(dataSet);

            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}