using BenchmarkDotNet.Running;
using DemconFibonacciChallenge;

if (args.Length > 0 && args[0] == "benchmark")
{
    _ = BenchmarkRunner.Run<FibonacciBenchmark>();
}
else
{
    var runner = new FibonacciBenchmark();

    var valueSimple = runner.Simple();
    var valueWithSkips = runner.WithSkips();
    var valueWithSkipsOptimized = runner.WithSkipsOptimized();

    Console.WriteLine($"{"Simple",-20}{valueSimple,10}");
    Console.WriteLine($"{"WithSkips",-20}{valueWithSkips,10}");
    Console.WriteLine($"{"WithSkipsOptimized",-20}{valueWithSkipsOptimized,10}");
}