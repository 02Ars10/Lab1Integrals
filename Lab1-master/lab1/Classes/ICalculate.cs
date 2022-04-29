using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Classes
{
    interface ICalculator
    {
        public double Calculate(int count, double upLim, double downLim, Func<double, double> integral, out double time);
        public double ParallelCalculate(int count, double upLim, double downLim, Func<double, double> integral, out double time);
    }

}
