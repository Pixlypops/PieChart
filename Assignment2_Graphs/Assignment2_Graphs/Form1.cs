using LiveCharts;
using LiveCharts.WinForms;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Assignment2_Graphs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {
            chart1.Series.Clear();
            Series series = new Series("PieSeries")
            { 
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };
            chart1.Series.Add(series);
            chart1.Legends.Add(new Legend());
            chart1.Legends[0].Docking = Docking.Right;
        }
        private void btnUpdateChart_Click(object sender, EventArgs e)
        {
            if (!chart1.Series.IsUniqueName("PieSeries"))
            {
               
                InitializeChart();
            }

            string input = textBox1.Text;
            string[] value = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var numbers = value.Select(val => double.TryParse(val, out double result) ? result : 0).ToArray();

            chart1.Series["PieSeries"].Points.Clear();
            for (int i = 0; i < numbers.Length; i++)
            {
                DataPoint point = new DataPoint
                {
                    YValues = new double[] { numbers[i] },
                    Label = $"Val: {i + 1}: {numbers[i]}"
                };
                chart1.Series["PieSeries"].Points.Add(point);

            }

            for (int i = 0; i < chart1.Series["PieSeries"].Points.Count; i++)
            {
                chart1.Series["PieSeries"].Points[i].LegendText = $"Slice {i + 1}";
            }
        }       
    }
}
