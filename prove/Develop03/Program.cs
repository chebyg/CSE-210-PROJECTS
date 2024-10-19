using System;
using System.Collections.Generic;

namespace W03_Scripture_Reference
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Scripture object
            Scripture scripture = new Scripture("Genesis", 1, 1, "In the beginning God created the heavens and the earth.");

            // Display the Scripture
            Console.WriteLine(scripture.Display());

            // Hide the first word of the Scripture
            scripture.HideWord(0);

            // Display the Scripture again
            Console.WriteLine(scripture.Display());

            // Keep asking the user for words to hide until they enter "quit"
            while (true)
            {
                Console.WriteLine("Enter a word to hide (or type 'quit' to exit):");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }

                // Try to hide the word
                if (scripture.HideWord(input))
                {
                    Console.WriteLine(scripture.Display());
                }
                else
                {
                    Console.WriteLine("Word not found.");
                }
            }
        }
    }

    /// <summary>
    /// Represents a Scripture reference.
    /// </summary>
    public class Scripture
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private string _text;
        private List<string> _hiddenWords = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Scripture"/> class.
        /// </summary>
        /// <param name="book">The book of the Scripture.</param>
        /// <param name="chapter">The chapter of the Scripture.</param>
        /// <param name="verse">The verse of the Scripture.</param>
        /// <param name="text">The text of the Scripture.</param>
        public Scripture(string book, int chapter, int verse, string text)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _text = text;
        }

        /// <summary>
        /// Displays the Scripture reference and text.
