using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarlo
{
    class ProjectTests
    {
   
       public void TestBucket()
       {
          Operation operations = new Operation();
          int[] Estimation = operations.CalculateEstimated();
            int min = Estimation[0];
            int max = Estimation[2];
            var bucket = new Bucket(10, 40, 160);
 
       }

    }
}
