# Demcon challenge
This is my entry for the Demcon fibonacci challenge.

## How to run
1. Make sure you have the .NET 8.0 SDK installed.
2. Clone the repository.
3. Open a terminal and navigate to the root of the repository, so the folder containing the `DemconFibonacciChallenge.sln` file.
4. Run the following command to view the calculated results:\
```dotnet run -c Release --project .\DemconFibonacciChallenge\DemconFibonacciChallenge.csproj```
5. Run the following command to compare the performance of different implementations:\
```dotnet run -c Release --project .\DemconFibonacciChallenge\DemconFibonacciChallenge.csproj -- benchmark```
   - Do not touch your computer for a while (2-3 min), it runs the various implementations many times to get a good average.

## Implementation
I have implemented three different methods to calculate the final result.

### Simple
```csharp
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
```
This is the most straightforward implementation, it just calculates the regular fibonacci sequence and for each number checks if it is even.
If the number is even it is added to the sum.

### WithSkips
```csharp
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
```
This is a slightly smarter approach because it uses a pattern in the fibonacci sequence to skip numbers.
The pattern is that every third number is even, so instead of checking every number we can just add every third number to the sum.
This means we don't have to check if a number is even anymore, which saves us a lot of time.

### WithSkipsOptimized
```csharp
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
```
This is the same as `WithSkips`, but it is optimized to use less intermediate variables and calculations.

## Results
These are the results on my machine, the exact values will probably differ for you but the general trend should be the same.

| Method             | Mean      | Error     | StdDev    |
|------------------- |----------:|----------:|----------:|
| Simple             | 20.227 ns | 0.3749 ns | 0.3507 ns |
| WithSkips          |  6.568 ns | 0.0632 ns | 0.0591 ns |
| WithSkipsOptimized |  3.001 ns | 0.0154 ns | 0.0144 ns |