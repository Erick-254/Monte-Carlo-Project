﻿using System;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] arg )
        {
            Console.WriteLine("Enter tasks in the following format: c1,c2,...."+ "\nwhere cx is cost " + "\nType END to finish entering tasks.");
            try
            {
                Operation operations = new Operation();
                int NumberOfTasks = 1;
                while (true)
                {
                    Console.Write($"Task #{NumberOfTasks}: ");
                    string Input = Console.ReadLine();

                    if (Input.ToLower() == "end") break;
                    else NumberOfTasks++;

                    operations.AddTask(new Input( Input ));
                }
                int[] EstimatedNumbers = operations.CalculateEstimated();
                int minimum = EstimatedNumbers[0], maximum = EstimatedNumbers[2];

                Bucket bucket = operations.Simulate();

                Console.WriteLine("After probing 10000 randoms plans, the results are: ");
                Console.WriteLine($"Minimum = {minimum} days");
                Console.WriteLine($"Average = {operations.AverageEstimation} days");
                Console.WriteLine($"Maximum = {maximum} days");

                Console.WriteLine("Probability of finishing the plan in: \n" + bucket);
                bucket.AccumulatedProbabilites();
                Console.WriteLine("Accumulate probability of finishing the plan in or before: " + bucket);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Try again");
            }
        }
    }
}
