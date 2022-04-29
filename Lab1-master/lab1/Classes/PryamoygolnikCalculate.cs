
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Windows;
namespace lab1.Classes
{
    public class PryamoygolnikCalculate : ICalculator
    {
        public double Calculate(int count, double upLim, double downLim, Func<double, double> integral, out double time)
        {
            double h = (upLim - downLim) / count;
            double sum = 0.0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i <= count; i++)
            {
                sum += integral(downLim + h * i - 0.5 * h);
            }

            time = sw.Elapsed.TotalMilliseconds;
            MessageBox.Show("Time (ms): " + Convert.ToString(time), "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            return h * sum;
        }
            public double ParallelCalculate(int count, double upLim, double downLim, Func<double, double> integral, out double time)
            {
                if (count <= 0)
                {
                    throw new ArgumentException();
                }
            double h = (upLim - downLim) / count;
            double sum = 0;
            double[] vs = new double[count+1];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(1, count+1, (i) =>
            {
                vs[i] = integral(downLim + h * i - 0.5 * h);
            });
            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;
            MessageBox.Show("Time (ms): " + Convert.ToString(time), "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            sum =vs.Sum();
            return sum * h;
        }
    }
}
