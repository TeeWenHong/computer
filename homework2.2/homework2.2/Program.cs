using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._2
{
    class Program
    {
         static void Main(string[] args)
         {                
            int[] array1 = new int[7] { 12, 23, 34, 45, 56,67,78 };

            Console.WriteLine("Max:" + array1.Max());
            Console.WriteLine("Min:" + array1.Min());
            Console.WriteLine("Average:" + array1.Average());
            Console.WriteLine("Sum:" + array1.Sum());
         }

    }
}
