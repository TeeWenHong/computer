using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace homework4._1
{ 
    public class N<T>
    {
        public N<T> Next { 
            get; 
            set; 
        }
        public T Data { 
            get; 
            set; 
        }
        public N(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class List<T>
    {
        private N<T> head;
        private N<T> tail;
        public List() //the list is null
        {
            tail = head = null;
        }
        public N<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            N<T> n = new N<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> act)
        {
            if (act == null)
            {
                throw new ArgumentNullException(nameof(act));
            }

            N<T> head = Head;
            while (head != null)
            {
                act(head.Data);
                head = head.Next;
                if (head == null)
                {
                    break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int max = -100;
            int min = 100;
            int sum = 0;
            List<int> list = new List<int>();
            Console.WriteLine("[1,3,5,2,4,6]");
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list.Add(2);
            list.Add(4);
            list.Add(6);

            list.ForEach((x) =>{if (x > max) { max = x;}if (x < min) { min = x; }sum += x;});
            Console.WriteLine("Max:" + max);
            Console.WriteLine("Min:" + min);
            Console.WriteLine("Sum:" + sum);
        }
    }
}