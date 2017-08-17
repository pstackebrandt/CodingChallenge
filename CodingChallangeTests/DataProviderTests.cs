using System.Linq;
using CodingChallenge;
using NUnit.Framework;

namespace CodingChallengeTests
{
    [TestFixture]
    public class DataProviderTests
    {
        [Test]
        public void Should_return_data_set()
        {
            var provider = new DataProvider();
            var dataSet = provider.GetDataSet(DataProvider.FirstDataSet).ToList();

            Assert.NotNull(dataSet);
            Assert.Less(0, dataSet.Count);
        }
    }
}