// See https://aka.ms/new-console-template for more information
using Hardsoft.BruteForcer;
using Hardsoft.BruteForcer.Algorithms;
using Hardsoft.BruteForcer.Chars;

Console.WriteLine("Hello, World!");

var pass = "mM184";

var defaultBruteForceAlgorithm = new BruteForcer(new DefaultBruteForceAlgorithm());

var isMatched = defaultBruteForceAlgorithm.Start(
    5,
    5,
    CharGroup.Numberic | CharGroup.Alpha,
    (testPass) =>
    {
        return testPass == pass;
    });

if (isMatched)
    Console.WriteLine("OK");
else
    Console.WriteLine("NOT FOUND");