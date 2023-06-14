
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

            Dictionary<string, int> actual = wordCounter.GetWordsCount(lines);

            Assert.Equal(expected.Length, actual.Count);
            foreach (var word in expected)
            {
                Assert.Equal(1, actual[word]);
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

            Dictionary<string, int> actual = wordCounter.GetWordsCount(lines);

            Assert.Equal(expected.Length, actual.Count);
            int i = 1;
            foreach (string word in expected)
            {
                {
                    Assert.Equal(i, actual[word]);
                    i++;
                }
            }
        }

        [Fact]
        public void GetWordsCount_EmptyInput_ReturnsEmptyResult()
        {
            var lines = new string[] {
                " ", "", "    ",
            };

            Dictionary<string, int> actual = wordCounter.GetWordsCount(lines);
            
            Assert.Equal(0, actual.Count);
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

            Dictionary<string, int> actual = wordCounter.GetWordsCount(lines, trimChars);

            Assert.Equal(expected.Length, actual.Count);
            int i = 1;
            foreach (string word in expected)
            {
                {
                    Assert.Equal(i, actual[word]);
                    i++;
                }
            }
        }


    }
}