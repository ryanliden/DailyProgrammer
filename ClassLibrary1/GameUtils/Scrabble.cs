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

            string letters = this.letters;

            int score = 0;

            if (CanMakeWord(word))
            {
                // First, loop through the list
                // If the letter is in the rack, remove it from the rack
                // Otherwise, because the word can be made, we can assume it is a wildcard and can be removed from the word
                foreach (char letter in word)
                {
                    if (letters.Contains(letter))
                    {
                        letters = RemoveLetter(letters, letter);
                    }
                    else
                    {
                        word = RemoveLetter(word, letter);
                    }
                }

                // Then loop through the remaining letters in the word and tally the score for each letter
                foreach (char letter in word)
                {
                    score += scores[letter];
                }

                return score;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Removes the first instance of the given letter from the rack
        /// </summary>
        /// <param name="letter">The letter to be removed</param>
        /// <param name="rack">The rack to  remove the letters from</param>
        public string RemoveLetter(string rack, char letter)
        {
            int index = rack.IndexOf(letter);

            rack = (index < 0) ? rack : rack.Remove(index, 1);

            return rack;
        }

        string[] GetWords()
        {
            string[] words = System.IO.File.ReadAllLines(file);

            return words;
        }

        /// <summary>
        /// Return the highest scoring word in the enable1 word list that can be created from the provided set of letters
        /// </summary>
        /// <returns></returns>
        public string HighestScore()
        {
            int highestScore = 0;
            string highestWord = "";

            string[] words = GetWords();

            foreach (string word in words)
            {
                if (Score(word) > highestScore)
                {
                    highestScore = Score(word);
                    highestWord = word;
                }
            }

            return highestWord;
        }

        /// <summary>
        /// Returns the longest word from the enable1 word list that can be created with the provided set of letters
        /// </summary
        /// <returns></returns>
        public string LongestWord()
        {
            string longest = "";

            string[] words = GetWords();

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
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool CanMakeWord(string word)
        {
            string letters = this.letters;
            
            char[] wordArray = word.ToCharArray();

            foreach (char letter in wordArray)
            {
                if (letters.Contains(letter))
                {
                    letters = RemoveLetter(letters, letter);
                }
                else if (letters.Contains('?'))
                {
                    letters = RemoveLetter(letters, '?');
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
