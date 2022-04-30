using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
namespace lab1.Classes

{
    public class TrapezCalculate : ICalculator
    {
        public double Calculate(int count, double upLim, double downLim, Func<double, double> integral, out double time)
        {
            time = 0;
            double h = (upLim - downLim) / count; if (count < 0) { throw new ArgumentException("count < 0"); }
            double sum = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                sum += integral(downLim + h * i); 
            }
            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;
            sum += (integral(downLim) + integral(upLim)) / 2;
            return h * sum;
        }
        public double ParallelCalculate(int count, double upLim, double downLim, Func<double, double> integral, out double time)
        {
            double h = (upLim - downLim) / count;
            double sum = 0;
            double[] vs = new double[count];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, count, (i) =>
            {
                vs[i] = integral(downLim + h * i);
            });
            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;
            sum = (integral(upLim) + integral(downLim)) / 2 + vs.Sum();
            return sum * h;

        }
    }
}
