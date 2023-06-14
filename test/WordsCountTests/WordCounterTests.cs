
namespace WordsCountTests
{

    public class WordCounterTests
    {
        private readonly WordCounter wordCounter;

        public WordCounterTests()
        {
            wordCounter = new WordCounter();
        }


        [Fact]
        public void GetWordsCount_NoDuplicates_ReturnsCorrectWordCounts()
        {
            var lines = new string[]
            {
                "one",
                "two three",
                "",
            };
            string[] expected = new string[] { "one", "two", "three" };

            Dictionary<string, WordCounter.Pair> actual = wordCounter.GetWordsCount(lines);

            Assert.Equal(expected.Length, actual.Count);
            foreach (var word in expected)
            {
                string key = word.ToLower();
                Assert.Equal(word, actual[key].Word);
                Assert.Equal(1, actual[key].Count);
            }
        }

        [Fact]
        public void GetWordsCount_WithDuplicates_ReturnsCorrectWordCounts()
        {
            var lines = new string[]
            {
                "one",
                "two two",
                "three three three",
                "four four four four",
            };
            string[] expected = new string[] { "one", "two", "three", "four" };

            Dictionary<string, WordCounter.Pair> actual = wordCounter.GetWordsCount(lines);

            Assert.Equal(expected.Length, actual.Count);
            int i = 1;
            foreach (string word in expected)
            {
                string key = word.ToLower();
                Assert.Equal(word, actual[key].Word);
                Assert.Equal(i, actual[key].Count);
                i++;
            }
        }

        [Fact]
        public void GetWordsCount_EmptyInput_ReturnsEmptyResult()
        {
            var lines = new string[] {
                " ", "", "    ",
            };

            Dictionary<string, WordCounter.Pair> actual = wordCounter.GetWordsCount(lines);
            
            Assert.Equal(0, actual.Count);
        }


        [Fact]
        public void GetWordsCount_PreservesFirstWordCasing_ReturnsCorrectCase()
        {
            var lines = new string[]
            {
                "One Two TWO THREE three Three",
                "four Four FOUR four",
            };
            string[] expected = new string[] { "One", "Two", "THREE", "four"};

            Dictionary<string, WordCounter.Pair> actual = wordCounter.GetWordsCount(lines);

            Assert.Equal(expected.Length, actual.Count);
            int i = 1;
            foreach (string word in expected)
            {
                string key = word.ToLower();
                Assert.Equal(word, actual[key].Word);
                Assert.Equal(i, actual[key].Count);
                i++;
            }
        }

        [Fact]
        public void GetWordsCount_TrimChars_ReturnsCorrectWordCounts()
        {
            var lines = new string[]
            {
                "one ",
                "two, two!",
                " three, three; three ",
                "  four four. four! ?four ",
                ".,;:!?",
                "",
            };
            string[] expected = new string[] { "one", "two", "three", "four"};
            char[] trimChars = ".,;:!?".ToCharArray();

            Dictionary<string, WordCounter.Pair> actual = wordCounter.GetWordsCount(lines, trimChars);

            Assert.Equal(expected.Length, actual.Count);
            int i = 1;
            foreach (string word in expected)
            {
                string key = word.ToLower();
                Assert.Equal(word, actual[key].Word);
                Assert.Equal(i, actual[key].Count);
                i++;
            }
        }


    }
}