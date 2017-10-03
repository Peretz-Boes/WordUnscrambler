using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Please enter the option f for file m for manual.";
        public const string OptionsOnContinuingTheProgram = "Do you want to continue?y/n";
        public const string EnterScrambledWordsViaFile = "Enter scrambled words file name with full path";
        public const string EnterScrambledWordsManually = "Enter word(s) manually(separated by commas if multiple).";
        public const string EnterScrambledWordsOptionNotRecognized = "The option was not recognized.";
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because an error occured.";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated.";
        public const string MatchFound = "Match found for{0} {1}:";
        public const string MatchNotFound = "No matches found.";
        public const string Yes = "y";
        public const string No = "n";
        public const string File = "f";
        public const string Manual = "m";
        public const string WordListFileName = "wordlist.txt";
    }
}
