using System.Collections.Generic;

namespace CodingChallenge
{
    public class DataProvider
    {
        /// <summary>
        /// Identifies a data set.
        /// </summary>
        internal const string FirstDataSet = "first";

        /// <summary>
        /// Identifies a data set.
        /// </summary>
        internal const string SecondDataSet = "second";


        public DataProvider()
        {
        }

        private IEnumerable<int> GetDataSet(string which)
        {
            var data = new List<int>();

            switch (which)
            {
                case nameof(DataProvider.FirstDataSet):
                    data.AddRange(new[] { 1, 2, 3, 9 });
                    break;

                case nameof(DataProvider.SecondDataSet):
                    data.AddRange(new[] { 1, 2, 4, 4 });
                    break;
            }
            
            return data;
        }
    }
}