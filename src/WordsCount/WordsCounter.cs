using System.Collections.Generic;

public class WordCounter
{
    public class Pair{
        public string Word = "";
        public int Count = 0;
    }

    public Dictionary<string, Pair> GetWordsCount(IEnumerable<string> lines, char[]? trimChars = null)
    {
        var wordCounts = new Dictionary<string, Pair>();

        foreach (string line in lines)
        {
            string[] words = line.Split(' ');

            foreach (string word in words)
            {
                string trimmedWord = word.Trim(trimChars);
                string key = trimmedWord.ToLower();
                if (String.IsNullOrEmpty(trimmedWord)) continue;

                if (wordCounts.ContainsKey(key))
                {
                    wordCounts[key].Count++;
                }
                else
                {
                    wordCounts.Add(key , new Pair() {Word = trimmedWord, Count = 1});
                }
            }
        }
        return wordCounts;
    }
}
