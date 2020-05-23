using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace homework2._1
{
    class Program
    {
        public static String getResult(long num)
        {
            StringBuilder count = new StringBuilder();
           
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
               
                while (true)
                {
                    
                    if (num % i == 0)
                    {
                        count.Append(i);
                        count.Append(" ");
                        num /= i;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            if (num != 1)
            {
                count.Append(num);
                count.Append(" ");
            }
            return count.ToString();
        }
        public static void Main(String[] args)
        {
            Console.WriteLine("input the number");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("answer");
            Console.WriteLine(getResult(num));
        }
    }
}