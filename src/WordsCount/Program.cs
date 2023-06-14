using System;
using System.Collections.Generic;
using System.IO;

public class Program
{

    private const string TRIM_CHARS = ".,;:!?";
    private const string USAGE = "usage: WordsCount <file-path>";
    private const string EMPTY_FILE = "File {0} is empty!";
    private const string RESULT_LINE = "{0}: {1}";

    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.Write(USAGE);
            return;
        }

        string filePath = args[0];
        IEnumerable<string> lines;
        try
        {
            lines = File.ReadLines(filePath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message); ;
            return;
        }


        WordCounter wordCounter = new WordCounter();
        Dictionary<string, int> result = wordCounter.GetWordsCount(
            lines, TRIM_CHARS.ToCharArray());

        if (result.Count == 0)
        {
            Console.WriteLine(
                String.Format(EMPTY_FILE, filePath));
            return;
        }

        foreach (string key in result.Keys)
        {
            Console.WriteLine(
                String.Format(RESULT_LINE, result[key], key));
        }
    }
}