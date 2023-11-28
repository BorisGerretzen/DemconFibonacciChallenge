using BenchmarkDotNet.Attributes;

namespace DemconFibonacciChallenge;

[ReturnValueValidator(true)] // Make sure all benchmarks return the same value
public class FibonacciBenchmark
{
    private const int MaxValue = 4_000_000;

    /// <summary>
    ///     A naive implementation.
    ///     We generate all Fibonacci numbers up to MaxValue, we check for each number if it's even, and if so add it to the
    ///     sum.
    /// </summary>
    [Benchmark]
    public int Simple()
    {
        var a = 1;
        var b = 2;
        var sum = 0;

        while (b <= MaxValue)
        {
            if (b % 2 == 0) sum += b;

            var next = a + b;
            a = b;
            b = next;
        }

        return sum;
    }

    /// <summary>
    ///     A more optimized implementation.
    ///     If we start the sequence with 1 and 2, we can see that every third number is even (after 2).
    ///     2 (even), 3 (odd), 5 (odd), 8 (even), 13 (odd), 21 (odd), 34 (even), 55 (odd), 89 (odd), 144 (even), ...
    ///     Because of this we can skip the odd numbers, and only add the even numbers to the sum.
    ///     We don't even need to check if the number is even.
    /// </summary>
    [Benchmark]
    public int WithSkips()
    {
        var a = 1;
        var b = 2;
        var sum = 0;

        while (b <= MaxValue)
        {
            sum += b;

            var skip1 = a + b;
            var skip2 = skip1 + b;
            var next = skip1 + skip2;

            a = skip2;
            b = next;
        }

        return sum;
    }

    /// <summary>
    ///     The same idea as in <see cref="WithSkips" />, but skips the intermediate variables and reduces the number of
    ///     calculations.
    /// </summary>
    [Benchmark]
    public int WithSkipsOptimized()
    {
        var a = 1;
        var b = 2;
        var sum = 0;

        while (b <= MaxValue)
        {
            sum += b;
            (a, b) = (
                a + 2 * b,
                2 * a + 3 * b
            );
        }

        return sum;
    }
}