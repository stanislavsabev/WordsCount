using System;
using System.Collections.Generic;
using System.IO;

class Program
{

    static void Main(string[] args)
    {
        if (args.Length != 1){
            Console.Write("usage: WordsCount <file-path>");
            return;
        }

        string filePath = args[0];
        IEnumerable<string> lines = File.ReadLines(filePath);

        WordCounter counter = new WordCounter();
        Dictionary<string, int> wordCounts = counter.GetWordsCount(
            lines, new char[] { '.', ',', ';', ':', '!', '?' });

        foreach (string key in wordCounts.Keys)
        {
            Console.WriteLine(key + ": " + wordCounts[key]);
        }
    }
}