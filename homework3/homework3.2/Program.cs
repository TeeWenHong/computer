using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework3._2
{
    class Product
    {
        public void MethodSame() { }
        public void MethodDiff() { }
        public double GetArea() { return 0; }
    }
    class Rectangle:Product
    {
        public double width;
        public double height;
        public Rectangle(double H, double W)
        {
            height = H;
            width = W;
        }
        public double GetArea()
        {
            if (Islegal())
            {
                return height * width;
            }
            return -1;
        }
        public Boolean Islegal()
        {
            return height > 0 && width > 0;
        }
        public double Display()
        {
            if (Islegal())
            {
                Console.WriteLine("Area:" + GetArea());
            }
            else
            {
                Console.WriteLine("Error！");
            }
            return -1;
        }
    }
    class Square:Product
    {
        public double S;
        public Square(double val)
        {
            S = val;
        }
        public double GetArea()
        {
            if (Islegal())
            {
                return S * S;
            }
            return -1;
        }
        public Boolean Islegal()
        {
            return S > 0;
        }
        public double Display()
        {
            if (Islegal())
            {
                Console.WriteLine("Area:" + GetArea());
            }
            else
            {
                Console.WriteLine("Error！");
            }
            return -1;
        }
    }
    class Triangle:Product
    {
        public double A;
        public double B;
        public double C;
        public Triangle(double a, double b, double c)  // 参数化构造函数
        {
            A = a;
            B = b;
            C = c;
        }
        public double GetArea()
        {
            if (Islegal())
            {
                double p = (A + B + C) / 2;
                double s = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
                return s;
            }
            return -1;
        }
        public Boolean Islegal()
        {
            return A + B > C && A + C > B && B + C > A && A > 0 && B > 0 && C > 0;
        }
        public double Display()
        {
            if (Islegal())
            {
                Console.WriteLine("Area:" + GetArea());
            }
            else
            {
                Console.WriteLine("Error！");
            }
            return -1;
        }
    }
    class Factory
    {
        
        public static Product GetProduct(String arg)
        {
            Product product = null;
            if (arg == "A")
            {
                Random y1 = new Random();
                int n = y1.Next(100);
                Random y2 = new Random();
                int m = y2.Next(100);
                product = new Rectangle(n, m);
               
            }
            else if (arg == "B")
            {
                Random z1 = new Random();
                int n = z1.Next(100);
                product = new Square(n);
                
            }
            else if (arg == "C")
            {
                Random x1 = new Random();
                int n = x1.Next(100);
                Random x2 = new Random();
                int m = x2.Next(100);
                Random x3 = new Random();
                int l = x3.Next(100);
                product = new Triangle(n, m, l);
               
            }
            return product;
        }
    }
    class Client
    {
        public static void Main(String[] args)
        {
            double area = 0;
            for (int i = 0; i < 10; i++)
            {
                Random x = new Random();
                int n = x.Next(100);
                Thread.Sleep(12);
                if (n % 3 == 0)
                {
                    Rectangle product;
                    product = (Rectangle)Factory.GetProduct("A");
                    Console.WriteLine("Rectangle , Area:" + product.GetArea());
                    area += product.GetArea();
                }
                if (n % 3 == 1)
                {
                    Square product;
                    product = (Square)Factory.GetProduct("B");
                    Console.WriteLine("Square , Area:" + product.GetArea());
                    area += product.GetArea();
                }
                if (n % 3 == 2)
                {
                    Triangle product;
                    product = (Triangle)Factory.GetProduct("C");
                    Console.WriteLine("Triangle , Area:" + product.GetArea());
                    area += product.GetArea();
                }
            }
        }
    }
}
