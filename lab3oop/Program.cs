using System;

namespace InfiniteSeriesCalculator
{
    class Program
    {
        delegate double SeriesTerm(int n);

        
        static double CalculateSeries(SeriesTerm termFormula, double precision)
        {
            double sum = 0.0;
            double termValue = 0.0;
            int n = 1;

            do
            {
                termValue = termFormula(n);
                sum += termValue;
                n++;
            } while (Math.Abs(termValue) >= precision);

            return sum;
        }
        static double Series1Term(int n)
        {
            return 1.0 / Math.Pow(2, n - 1);
        }

        static double Series2Term(int n)
        {
            double factorial = 1.0;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return 1.0 / factorial;
        }

        static double Series3Term(int n)
        {
            return Math.Pow(-1, n - 1) / Math.Pow(2, n - 1);
        }

        static void Main(string[] args)
        {
            double sum1 = CalculateSeries(Series1Term, 0.0001);
            Console.WriteLine("Sum: 1 + 1/2 + 1/4 + 1/8 + 1/16 + ...: " + sum1);
            double sum2 = CalculateSeries(Series2Term, 0.0001);
            Console.WriteLine("Sum: 1 + 1/2! + 1/3! + 1/4! + 1/5! + ...: " + sum2);
            double sum3 = CalculateSeries(Series3Term, 0.000001);
            Console.WriteLine("Sum: -1 + 1/2 - 1/4 + 1/8 - 1/16 + ...: " + sum3);

            Console.ReadLine();
        }
    }
}
