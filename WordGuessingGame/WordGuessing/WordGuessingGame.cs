using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordGuessing
{
    public class WordGuessingGame
    {

        #region MainGame
        public static void Main(string[] args)
        {
            // Game Initialization
            List<string> wordList =
                new List<string>(new string[] { "Detective", "Sherlock", "RoboCop", "GiantBomb", "Garrulous",
                                                "Holiday", "Distribution", "Mystery", "Embargos", "Podcast",
                                                "Interviews", "Deception", "Revelations", "Games", "Hearse",
                                                "Bond", "Women", "Nemesis", "Puzzle", "Victory", "Loss", "Charm"});
            Random rnd = new Random();
            int r = rnd.Next(wordList.Count());

            // Pick a word from the wordlist at random.
            string gameword = wordList[r];

            string progress = InitializeLetters(gameword);
            int guessCount = 0;
            int allowedGuesses = 6;
            bool win = (progress.ToLower() == gameword.ToLower());


            Console.WriteLine("Welcome, please type in a guess");
            Console.WriteLine("--------------------------------------------------"+ 
                              "\n * Only the first letter inputted is counted"+
                              "\n * Numbers & Symbols are allowed but discouraged!"+
                              "\n--------------------------------------------------");


            // Game Loop
            while (guessCount < allowedGuesses && !win)
            {
                var playerInput = Console.ReadLine();
                var guess = playerInput.First();
                var foundIndexes = EvaluateGuess(gameword, guess);

                if (foundIndexes.Count() > 0)
                {
                    Console.WriteLine("There is a {0}!", guess);
                    progress = UpdateProgress(progress, guess, foundIndexes);
                }
                else
                {
                    guessCount++;
                    Console.WriteLine("Sorry no {0} {1} guesses left!", guess, allowedGuesses - guessCount);

                }
                Console.WriteLine(progress.ToString());
                win = (progress.ToLower() == gameword.ToLower());
            }

            // End Game
            var endMessage = win ? "You Win" : "Game Over";
            Console.WriteLine("\n {0}!", endMessage);
            Console.ReadLine();
        } 
        #endregion

        #region InitializeLetters
        private static string InitializeLetters(string gameword)
        {
            var initial = new char[gameword.Length];

            for (int i = 0; i < initial.Count(); i++)
            {
                initial[i] = '_';
            }

            string progress = new string(initial);
            return progress;
        } 
        #endregion

        #region EvaluateGuess 
        public static List<int> EvaluateGuess(string gameword,char guess) {

            var foundIndexes = new List<int>();

            for (int i = 0; i < gameword.Length; i++)
            {
                if (gameword.ToLower()[i] == guess || gameword.ToUpper()[i] == guess)
                {
                    foundIndexes.Add(i);
                }
            }

            return foundIndexes;
        }
        #endregion

        #region UpdateProgress
        public static String UpdateProgress(string progress, char guess, List<int> foundIndexes)
        {
            StringBuilder sb = new StringBuilder(progress);

            foreach (int index in foundIndexes)
            {
                sb[index] = guess;
            }

            progress = sb.ToString();

            return progress;
        }
        #endregion

    }

}
