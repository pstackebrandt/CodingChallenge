using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    public class DataProvider
    {
        /// <summary>
        /// Identifies a data set.
        /// </summary>
        public const string FirstDataSet = "first";

        /// <summary>
        /// Identifies a data set.
        /// </summary>
        public const string SecondDataSet = "second";

        public DataProvider()
        {
        }

        public IEnumerable<int> GetDataSet(string which)
        {
            var data = new List<int>();

            switch (which)
            {
                case DataProvider.FirstDataSet:
                    data.AddRange(new[] { 1, 2, 3, 9 });
                    break;

                case DataProvider.SecondDataSet:
                    data.AddRange(new[] { 1, 2, 4, 4 });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(which), "Unsupported data set");
            }

            return data;
        }
    }
}