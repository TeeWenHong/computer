using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3._1
{
    class Rectangle
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
    class Square
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
    class Triangle
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
    class Client
    {
        public static void Main(String[] args)
        {
            Rectangle r = new Rectangle(8, 9);
            Square s = new Square(4);
            Triangle t = new Triangle(7, 5, 6);
            r.Display();
            s.Display();
            t.Display();
        }
    }
}