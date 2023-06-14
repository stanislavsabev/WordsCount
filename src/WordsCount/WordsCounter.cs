using System.Collections.Generic;

public class WordCounter
{

    public Dictionary<string, int> GetWordsCount(IEnumerable<string> lines, char[]? trimChars = null)
    {
        var wordCounts = new Dictionary<string, int>();

        foreach (string line in lines)
        {
            string[] words = line.Split(' ');

            foreach (string word in words)
            {
                string trimmedWord = word.Trim(trimChars).ToLower();
                if (wordCounts.ContainsKey(trimmedWord))
                {
                    wordCounts[trimmedWord]++;
                }
                else
                {
                    wordCounts.Add(trimmedWord, 1);
                }
            }

        }
        return wordCounts;
    }
}

