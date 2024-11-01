using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop06 World!");
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Base class for all goals
    public abstract class Goal
    {
        // Properties common to all goals
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool IsComplete { get; set; }

        // Constructor
        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            IsComplete = false;
        }

        // Abstract method for completing the goal
        public abstract void Complete();

        // Method for displaying the goal
        public virtual void Display()
        {
            Console.WriteLine($"Goal: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Points: {Points}");
            Console.WriteLine($"Status: {(IsComplete ? "Complete" : "Incomplete")}");
        }
    }

    // Class for simple goals
    public class SimpleGoal : Goal
    {
        // Constructor
        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        // Method for completing the goal
        public override void Complete()
        {
            IsComplete = true;
        }
    }

    // Class for eternal goals
    public class EternalGoal : Goal
    {
        // Constructor
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        // Method for completing the goal
        public override void Complete()
        {
            // Eternal goals are never complete, so we just update the points
            Points += 100;
        }

        // Override the Display method to show the current points earned
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Current points: {Points}");
        }
    }

    // Class for checklist goals
    public class ChecklistGoal : Goal
    {
        // Property for the number of times the goal needs to be completed
        public int TargetCount { get; set; }
