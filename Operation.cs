using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarlo
{
    class Operation
    {
        public List<Input> Tasks = new List<Input>();
        public int AverageEstimation { get; private set; }

        Random randNum = new Random();

        public void AddTask(Input task)
        {
            Tasks.Add(task);
        }

        public int[] CalculateEstimated()
        {
            int min = 0, avg = 0, max = 0;

            foreach (Input task in Tasks)
            {
                min += task.MaxTestCase;
                max += task.MinTestCase;
                avg += task.AvgTestCase;
            }
            if (max < min) throw new InvalidOperationException("Max case scenerio must be longer than min");

            int[] TimeCases = new int[] { min, avg, max };
            return TimeCases;
        }

        public int GenerateRandomEstimate()
        {
            int sum = 0;

            foreach (Input task in Tasks)
            {
                int whichCase = randNum.Next(3);
                if (whichCase == 0)
                    sum += task.MaxTestCase;
                if (whichCase == 1)
                    sum += task.MinTestCase;
                if (whichCase == 2)
                    sum += task.AvgTestCase;

            }
            return sum;
        }

        //Monte carlo algorithm, more iterations more accurate estimation with costs of performance
        public Bucket Simulate()
        {
            int totalCostOfRandomPlans = 0;
            int iterations = 10000;
            int[] Estimation = CalculateEstimated();
            int min = Estimation[0], max = Estimation[2];
            //int HowManyBuckets = max - min;
            Bucket bucket = new Bucket(10, min, max);


            for (int i = 0; i < iterations; i++)
            {
                int randomPlanCost = GenerateRandomEstimate();

                bucket.addValueToBucket(randomPlanCost);

                totalCostOfRandomPlans += randomPlanCost;
            }
            this.AverageEstimation = totalCostOfRandomPlans / (iterations);

            return bucket;
        }
    }
}