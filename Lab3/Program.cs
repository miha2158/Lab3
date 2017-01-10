using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static double fx(double x)
        {
            return -Math.Log(1 - 2 * x * Math.Cos(Math.PI / 3) + Math.Pow(x, 2)) / 2;
        }

        static double S(int count, double x)
        {
            return Math.Pow(x, count) * Math.Cos(count * Math.PI / 3) / count;
        }

        static double SN(int count, double x, int n)
        {
            if (count < n)
                return S(count, x) + SN(count + 1, x, n);
            else return 0;
        }

        static double SE(int count, double x, double e, double sum)
        {
            if (Math.Abs(S(count, x) - S(count + 1, x)) > e)
                return SE(count + 1, x, e, sum + S(count, x));
            else return sum + S(count + 1, x);

        }

        static void Main(string[] args)
        {
            int k = 10, n = 35;
            double a = 0.1, b = 0.8, e = .0001;

            double step = (b - a) / k;
            

            for (double x = a; x <= b + step; x += step) 
            {
                Console.Write("X = {0:0.0000}    ", x);
                Console.Write("SN = {0:0.0000}    ", SN(1, x, n));
                Console.Write("SE = {0:0.0000}    ", SE(1,x,e,0));
                Console.Write("Y = {0:0.0000}    ", fx(x));
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }
    }
}
