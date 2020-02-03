using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonteCarlo
{
    class Input
    {
        public int MaxTestCase { get; set; }
        public int MinTestCase { get; set; }
        public int AvgTestCase { get; set; }
        public int[] Tasks { get; set; }

        public Input(string Input)
        {
            setArray(Input);
        }
 
        public void setArray(string Input)
        {
            Input = Input.Trim();
            string[] Estimations = Input.Split(',');

            if (Estimations.Length < 2) throw new InvalidOperationException("You must declare c1,c2,...,cn. Separated with ,");

            this.Tasks = new int[Estimations.Length];

            for (int i = 0; i < Estimations.Length; i++)
            {
                if (!int.TryParse(Estimations[i], out Tasks[i])) Console.WriteLine("Wrong input");
            }
            this.MaxTestCase = Tasks.Min();
            this.MinTestCase = Tasks.Max();
            this.AvgTestCase = (int)Tasks.Average();
        }
    }
}
