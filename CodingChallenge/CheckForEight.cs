using System;

namespace CodingChallenge
{
    public class CheckForEight
    {
        private readonly DataProvider _dataProvider;

        public CheckForEight()
        {
            Console.WriteLine($"{nameof(CheckForEight)} wird erstellt");
            _dataProvider = new DataProvider();
        }

        public DataProvider DataProvider
        {
            get { return _dataProvider; }
        }

        public void Run()
        {
            Console.WriteLine($"{nameof(CheckForEight)}.{nameof(CheckForEight.Run)}()");

            var data = new DataProvider().GetDataSet(DataProvider.FirstDataSet);
        }
    }
}
