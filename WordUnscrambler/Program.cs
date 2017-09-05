using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WordUnscrambler
{
    class Program
    {
        private const string wordListFileName = Constants.WordListFileName;
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;
            if (!File.Exists(Constants.WordListFileName)) {
                File.Create(Constants.WordListFileName);
                try
                {
                    File.WriteAllText(Constants.WordListFileName, "rome\r\n more\r\n cat");
                }
                catch (IOException exception)
                {
                    Console.WriteLine("Error writing to file " + exception.Message);
                }
                
            }
            do
            {
                Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                var option = Console.ReadLine() ?? string.Empty;
                switch (option)
                {
                    case "f":
                        Console.WriteLine(Constants.EnterScrambledWordsViaFile);
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "m":
                        Console.WriteLine(Constants.EnterScrambledWordsManually);
                        ExecuteScrambledWordsInManualScenario();
                        break;
                    default:
                        Console.WriteLine("Option was not recognized.");
                        break;
                }
                var continueWordUnscrambleDesicion = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue?y/n");
                    continueWordUnscrambleDesicion = (Console.ReadLine() ?? string.Empty);
                } while (!continueWordUnscrambleDesicion.Equals("y", StringComparison.OrdinalIgnoreCase) && !continueWordUnscrambleDesicion.Equals("n", StringComparison.OrdinalIgnoreCase));
                if (continueWordUnscrambleDesicion.Equals("y", StringComparison.OrdinalIgnoreCase)) {
                    continueWordUnscramble = true;
                }
                if (continueWordUnscrambleDesicion.Equals("n", StringComparison.OrdinalIgnoreCase)) {
                    continueWordUnscramble = false;
                    Console.ReadLine();
                }
            } while (continueWordUnscramble);
            
        }

        public static void ExecuteScrambledWordsInFileScenario() {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = fileReader.Read(fileName);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error loading words " + exception.Message);
            }
        }

        public static void ExecuteScrambledWordsInManualScenario() {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        public static void DisplayMatchedUnscrambledWords(string[] scrambledWords) {
            string[] wordList = fileReader.Read(wordListFileName);
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);
            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords) {
                    Console.WriteLine(string.Format("Match found for {0},{1}", matchedWord.ScrambledWord, matchedWord.Word));
                }
            }
            else {
                Console.WriteLine("No matches have been found.");
            }
        }

    }
}
