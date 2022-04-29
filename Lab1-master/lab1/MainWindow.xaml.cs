using lab1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;


namespace lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }
        private void btCalculateParallel_Click(object sender, RoutedEventArgs e)
        {  
            CalculateParallel();
        }
        private void CalculateParallel()
        {
            int count = Convert.ToInt32(tbN.Text);
            int upLim = Convert.ToInt32(tbVerx.Text);
            int downLim = Convert.ToInt32(tbNiz.Text);
            double time = 0;
            ICalculator calcult = GetCalculator();
            double result = calcult.ParallelCalculate(count, upLim, downLim, x => (12 * x) - Math.Log(11 * x) - 11, out time);
            MessageBox.Show($"Результат вычислений параллельно = {result.ToString()}");
        }
        private void Graphic_Click(object sender, RoutedEventArgs e)
        {
            var pm = new PlotModel()
            {
                Title = "12x - ln(11x) - 11"
            };
            var lineSeries = new LineSeries();

            int upLim = Convert.ToInt32(tbVerx.Text);
            int downLim = Convert.ToInt32(tbNiz.Text);
          

            for (int i = 0; i < 1000; i++)
            {
                double time = 0;
                ICalculator calcultGraph = GetCalculator();
                double result = calcultGraph.Calculate(i, upLim, downLim, x => (12 * x) - Math.Log(11 * x) - 11, out time);
                lineSeries.Points.Add(new DataPoint(i, time));
            }

            pm.Series.Add(lineSeries);
            Graph.Model = pm;
        }
        private ICalculator GetCalculator()
        {
            return ModeComboBox.SelectedIndex switch
            {
            
                0 => new PryamoygolnikCalculate(),
                1 => new TrapezCalculate(),
                _ => throw new NotImplementedException(),
            };
        }

        private void DoCalculate()
        {
            int count = Convert.ToInt32(tbN.Text);
            int upLim = Convert.ToInt32(tbVerx.Text);
            int downLim = Convert.ToInt32(tbNiz.Text);
            double time = 0;
            ICalculator calcult = GetCalculator();
            double result = calcult.Calculate(count, upLim, downLim, x => (12 * x) - Math.Log(11 * x) - 11, out time);
            MessageBox.Show($"Результат вычислений = {result.ToString()}");
        }


    }
}
