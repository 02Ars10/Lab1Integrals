using System;
using Xunit;
using lab1.Classes;


namespace lab1.Tests
{
    public class MathTests
    {
        [Fact]
        public void Integral_X_X_Pryam_Success()
        {
            //Arrange
            double upLim = 100.0;
            double downLim = 0.0;
            Func<double, double> integral = x => x * x;
            int count = 100000;
            double time;
            double expected = 333333.3333;
            //Act
            PryamoygolnikCalculate pryamoygolnikCalculate = new PryamoygolnikCalculate();
            double result = pryamoygolnikCalculate.Calculate(count, upLim, downLim, integral, out time);

            //Assert
            Assert.Equal(expected, result,4);
        }

        [Fact]
        public void Integral_X_X_StepNegative()
        {
            //Arrange
            double upLim = 100.0;
            double downLim = 0.0;
            Func<double, double> func = x => x * x;
            int count = -10000;
            double time;
            //Act
            TrapezCalculate trap = new TrapezCalculate();
            

            //Assert
            Assert.Throws<ArgumentException>(()=> trap.Calculate(count, upLim, downLim, func, out time));
        }
        [Fact]
        public void Integral_X_X_Trap_Success()
        {
            //Arrange
            double upLim = 100.0;
            double downLim = 0.0;
            Func<double, double> integral = x => x * x;
            int count = 100000;
            double time;
            double expected = 333333.3333;
            //Act
            TrapezCalculate trapez = new TrapezCalculate();
            double result = trapez.Calculate(count, upLim, downLim, integral, out time);

            //Assert
            Assert.Equal(expected, result, 4);
        }
        [Fact]
        public void Integral_X_X_Gives_0()
        {
            //Arrange
            double downLim = 0.0;
            double upLim = downLim;
            Func<double, double> integral = x => x * x;
            int count = 100000;
            double time;
            double expected = 0.0;
            //Act
            PryamoygolnikCalculate pryam = new PryamoygolnikCalculate();
            double result = pryam.Calculate(count, upLim, downLim, integral, out time);

            //Assert
            Assert.Equal(expected, result, (int)0.0001);
        }
    }
}
