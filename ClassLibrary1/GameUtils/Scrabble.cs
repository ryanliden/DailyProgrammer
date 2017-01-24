using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyansLibrary.GameUtils
{
    public class Scrabble
    {
        public string letters;

        const string file = @"C:\enable1.txt";

        const string characterSet = "abcdefghijklmnopqrstuvwxyz?";

        public Scrabble(string letters)
        {
            int len = 20;

            if (letters.Length > len)
            {
                throw new ScrabbleException("Must supply less than " + len + " letters");
            }

            this.letters = letters;
        }
        
        /// <summary>
        /// Calculate the score for the given word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int Score(string word)
        {
            Dictionary<char, int> scores = new Dictionary<char, int>
            {
                {'a', 1}, {'b', 3}, {'c', 3}, {'d', 2}, {'e', 1}, {'f', 4}, {'g', 2}, {'h', 4}, {'i', 1}, {'j', 8},
                {'k', 5}, {'l', 1}, {'m', 3}, {'n', 1}, {'o', 1}, {'p', 3}, {'q', 10}, {'r', 1}, {'s', 1}, {'t', 1},
                {'u', 1}, {'v', 4}, {'w', 4}, {'x', 8}, {'y', 4}, {'z', 10}
            };



            return 0;
        }


        public string HighestScore()
        {
            return string.Empty;
        }

        /// <summary>
        /// Returns the longest word from the enable1 word list that can be created with the provided set of letters
        /// </summary
        /// <returns></returns>
        public string LongestWord()
        {
            string longest = "";

            string[] words = System.IO.File.ReadAllLines(file);

            // Loop through the word list and check if the word can be made
            foreach (string word in words)
            {
                if (CanMakeWord(word) && word.Length > longest.Length)
                { 
                    longest = word;
                }
            }
            
            return longest;
        }

        /// <summary>
        /// Checks to see if the word can be made with the letters provided
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool CanMakeWord(string word)
        {
            string letters = this.letters;
            
            char[] wordArray = word.ToCharArray();

            for (int i = 0; i < wordArray.Length; i++)
            {
                if (letters.Contains(wordArray[i]))
                {
                    // remove the letter at position i in wordArray
                    int index = letters.IndexOf(wordArray[i]);

                    letters = (index < 0) ? letters : letters.Remove(index, 1);
                }
                else if (letters.Contains('?'))
                {
                    int index = letters.IndexOf('?');

                    letters = (index < 0) ? letters : letters.Remove(index, 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
