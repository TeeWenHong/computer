using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[101];
            for (int i=2; i<=100; i++) {
                if (a[i] == 1){
                    continue;
                }
                for (int x=i+1;x<=100;x++) {
                    if (x % i == 0) {
                        a[x] = 1;
                    }
                }
                Console.WriteLine(i);
            }          
        }
    }
}
