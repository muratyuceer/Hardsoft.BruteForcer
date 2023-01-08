using BenchmarkDotNet.Attributes;
using Hardsoft.BruteForcer.Chars;

namespace Hardsoft.BruteForcer.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 1, iterationCount: 1)]
    //[SimpleJob(RuntimeMoniker.Net60)]
    //[SimpleJob(RuntimeMoniker.Net70)]
    public class Benchmarks
    {
        string pass = string.Empty;
        private BruteForcer bruteForcer = new BruteForcer();

        //[Params(3, 6)]
        //public int N;

        [GlobalSetup]
        public void GlobalSetup()
        {
            pass = "99184";
        }

        [Benchmark]
        public void MyFirstBenchmarkMethod()
        {
            var isMatched = bruteForcer.Start(
                3,
                6,
                CharGroup.All,
                (testPass) =>
                {
                    return testPass == pass;
                });
        }
    }
}