using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Hydronovo.Hydraulics.PT.RiverNetwork.Annotations;
using Hydronovo.Hydraulics.PT.RiverNetwork.Utils;
using OxyPlot;
using OxyPlot.Axes;
using LinearAxis = OxyPlot.Axes.LinearAxis;
using LineSeries = OxyPlot.Series.LineSeries;

namespace Hydronovo.Hydraulics.PT.RiverNetwork.Views
{
    /// <summary>
    /// Interaction logic for RiverNetworkView.xaml
    /// </summary>
    public partial class RiverNetworkView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get { return plotModel; }
            set
            {
                plotModel = value;
                OnPropertyChanged(nameof(PlotModel));
            }
        }
        
        
        public RiverNetworkView()
        {
            InitializeComponent();
            DataContext = this;
            
            var branchPoints1 = new List<DataPoint>{
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };

            var branchPoints2 = new List<DataPoint>{
                                  new DataPoint(50, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(30, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(20, 80),
                                  new DataPoint(50, 12)
                              };

            allPoints.Add(branchPoints1);
            allPoints.Add(branchPoints2);
            
            PlotView.ActualController.UnbindAll();
           
            //PlotView.ActualController.AddMouseManipulator();

            PlotModel = CreatePlot();
        }

        private List<List<DataPoint>> allPoints = new List<List<DataPoint>>();
        
        private PlotModel CreatePlot()
        {
            var pm = new PlotModel { Title = "River Network" };
            
            var linearAxisX = new LinearAxis
            {
                Minimum = 0,
                Maximum = 100,
                Position = AxisPosition.Bottom
            };

            var linearAxisY = new LinearAxis
            {
                Minimum = 0,
                Maximum = 100,
                Position = AxisPosition.Left
            };

            pm.PlotType = PlotType.Cartesian;
            pm.Axes.Add(linearAxisX);
            pm.Axes.Add(linearAxisY);
            
            foreach (var points in allPoints)
            {
                var ls = new LineSeries();
                foreach (var point in points)
                {
                    ls.Points.Add(point);
                }
                pm.Series.Add(ls);
            }
            //pm.MouseDown += (s, e) =>
            //{
            //    if ((e.ChangedButton != OxyMouseButton.Left))
            //    {
            //        return;
            //    }
            //    e.Handled = true;
            //};
            
            pm.MouseUp += PlotModel_MouseUp;

            


            //PlotView plotView = new PlotView();
            //plotView.Controller.UnbindAll();
            //Grid.Children.Add(plotView);

            //plotView.Model = PlotModel;

            return pm;
        }
        
        private void PlotModel_MouseUp(object sender, OxyMouseEventArgs e)
        {
            var dataPoint = PlotModel.InverseTransform(e.Position);
            if (dataPoint.IsDefined())
            {
                AddPoint(dataPoint);
            }
        }

        private void AddPoint(DataPoint dataPoint)
        {
            var ls = PlotModel.Series[0] as LineSeries;
            ls?.Points.Add(dataPoint);
            CreatePlot();
        }
    }
}
