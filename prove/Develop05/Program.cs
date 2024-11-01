using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
    }
} 
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the menu system
            Menu menu = new Menu();
            menu.DisplayMenu();
        }
    }

    class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            // Get user input
            int choice = GetIntInput("Enter your choice: ");

            // Call the appropriate activity based on user choice
            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartActivity();
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartActivity();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartActivity();
                    break;
                case 4:
                    Console.WriteLine("Exiting the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    DisplayMenu();
                    break;
            }
        }

        // Helper method to get integer input from the user
        private int GetIntInput(string message)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write(message);
            }
            return input;
        }
    }

    // Base class for mindfulness activities
    abstract class MindfulnessActivity
    {
        protected string activityName;
        protected string description;
        protected int duration;
        protected List<string> prompts;

        // Abstract method to start the activity
        public abstract void StartActivity();

        // Helper method to display a standard starting message
        protected void DisplayStartingMessage
