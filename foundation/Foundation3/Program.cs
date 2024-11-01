using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation3 World!");
    }
}
using System;

// Base class for all activities
public abstract class Activity
{
    // Shared attributes
    protected DateTime Date { get; set; }
    protected int Minutes { get; set; }

    // Constructor
    public Activity(DateTime date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    // Abstract methods for derived classes to override
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Method to get a summary of the activity
    public virtual string GetSummary()
    {
        return $"Date: {Date:dd MMM yyyy}, Duration: {Minutes} min, Distance: {GetDistance():0.00} km, Speed: {GetSpeed():0.00} kph, Pace: {GetPace():0.00} min per km";
    }
}

// Derived class for running activity
public class Running : Activity
{
    private double _distance;

    // Constructor
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    // Override abstract methods
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / _distance;
    }
}

// Derived class for cycling activity
public class Cycling : Activity
{
    private double _speed;

    // Constructor
    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    // Override abstract methods
    public override double GetDistance()
    {
        return (_speed / 60) * Minutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// Derived class for swimming activity
public class Swimming : Activity
{
    private int _laps;
    private double _lapDistance; // Distance per lap in km

    // Constructor
    public Swimming(DateTime date, int minutes, int laps, double lapDistance) : base(date, minutes)
    {
        _laps = laps;
        _lapDistance = lapDistance;
    }

    // Override abstract methods
    public override double GetDistance()
    {
        return _laps * _lapDistance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // Speed in km/h
    }

    public override double GetPace()
    {
        return Minutes / GetDistance(); // Pace in min/km
    }
}

// Main program to demonstrate functionality
public class Program
{
    public static void Main(string[] args)
    {
        // Creating activities
        var running = new Running(DateTime.Now, 30, 5.0); // 5 km run
        var cycling = new Cycling(DateTime.Now, 45, 20.0); // 20 kph cycling
        var swimming = new Swimming(DateTime.Now, 30, 20, 0.025); // 20 laps of 25m

        // Output summaries
        Console.WriteLine(running.GetSummary());
        Console.WriteLine(cycling.GetSummary());
        Console.WriteLine(swimming.GetSummary());
    }
}


