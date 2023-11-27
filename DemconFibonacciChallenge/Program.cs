using BenchmarkDotNet.Running;
using DemconFibonacciChallenge;

var summary = BenchmarkRunner.Run<FibonacciBenchmark>();