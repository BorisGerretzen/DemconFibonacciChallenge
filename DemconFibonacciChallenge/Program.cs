using BenchmarkDotNet.Running;
using DemconFibonacciChallenge;

if (args.FirstOrDefault() == "benchmark")
{
    _ = BenchmarkRunner.Run<FibonacciBenchmark>();
}
else
{
    var runner = new FibonacciBenchmark();

    var valueSimple = runner.Simple();
    var valueWithSkips = runner.WithSkips();
    var valueWithSkipsOptimized = runner.WithSkipsOptimized();

    Console.WriteLine($"{"Simple",-20}{valueSimple}");
    Console.WriteLine($"{"WithSkips",-20}{valueWithSkips}");
    Console.WriteLine($"{"WithSkipsOptimized",-20}{valueWithSkipsOptimized}");
}