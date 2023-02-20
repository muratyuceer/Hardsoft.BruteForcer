using BenchmarkDotNet.Attributes;
using Hardsoft.BruteForcer.Algorithms;
using Hardsoft.BruteForcer.Chars;

namespace Hardsoft.BruteForcer.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 1, iterationCount: 1)]
    //[SimpleJob(RuntimeMoniker.Net60)]
    //[SimpleJob(RuntimeMoniker.Net70)]
    public class DefaultBruteForceAlgorithmBenchmarks
    {
        string pass = string.Empty;
        private BruteForcer bruteForcer = new BruteForcer(new DefaultBruteForceAlgorithm());

        //[Params(3, 6)]
        //public int N;

        [GlobalSetup]
        public void GlobalSetup()
        {
            pass = "184";
        }

        [Benchmark]
        public void DefaultBruteForceAlgorithmBenchmark()
        {
            var isMatched = bruteForcer.Start(
                pass.Length,
                CharGroup.Numberic | CharGroup.Alpha,
                (testPass) =>
                {
                    return testPass == pass;
                });
        }
    }
}