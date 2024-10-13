using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            // Main menu loop
            while (true)
            {
                Console.WriteLine("\nJournal Program Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        journal.WriteEntry();
                        break;
                    case 2:
                        journal.DisplayJournal();
                        break;
                    case 3:
                        journal.SaveJournalToFile();
                        break;
                    case 4:
                        journal.LoadJournalFromFile();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class Journal
    {
        private List<Entry> entries;
        private string separator = "|"; // Separator for CSV file

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void WriteEntry()
        {
            // Get a random prompt
            string prompt = GetRandomPrompt();

            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("Enter your response: ");
            string response = Console.ReadLine();

            // Create a new entry and add it to the journal
            Entry entry = new Entry(DateTime.Now, prompt, response);
            entries.Add(entry);

            Console.WriteLine("Entry saved successfully!");
        }

        public void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is empty.");
                return;
            }

            Console.WriteLine("\nJournal Entries:");
