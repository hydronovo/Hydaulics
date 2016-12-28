using OxyPlot;
using OxyPlot.Axes;

namespace Hydronovo.Hydraulics.PT.RiverNetwork.Utils
{
    public static class Utils
    {
        public static DataPoint InverseTransform(this PlotModel plotModel, ScreenPoint screenPoint)
        {
            Axis axisX;
            Axis axisY;
            plotModel.GetAxesFromPoint(screenPoint, out axisX, out axisY);

            if (axisX == null || axisY == null)
            {
                return DataPoint.Undefined;
            }
            var x = axisX.InverseTransform(screenPoint.X);
            var y = axisY.InverseTransform(screenPoint.Y);
            return new DataPoint(x, y);
        }
    }
}
