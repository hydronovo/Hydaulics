using System.Collections.Generic;
using OxyPlot;
using Prism.Mvvm;

namespace Hydronovo.Hydraulics.PT.RiverNetwork.ViewModels
{
    public class RiverNetworkViewModel : BindableBase
    {
        private string title = "River Network";
        private IList<DataPoint> points = new List<DataPoint>();

        public RiverNetworkViewModel()
        {
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
            //_points.Add(branchPoints1);
            //_points.Add(branchPoints2);
            Points = branchPoints2;
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        
        public IList<DataPoint> Points
        {
            get { return points; }
            set { SetProperty(ref points, value); }
        }

    }
}
