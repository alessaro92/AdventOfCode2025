using System.Diagnostics;
using AdventOfCode2025;

Console.WriteLine("Input file path:");
string inputFilePath = Console.ReadLine();

var stopWatch = new Stopwatch();
stopWatch.Start();

var output = Day02.Part2(inputFilePath);

stopWatch.Stop();

Console.WriteLine(output);

Console.WriteLine("Time: " + stopWatch.ElapsedMilliseconds);