using System;
using Prism.Mvvm;

namespace Hydronovo.Hydraulics.PT.RiverNetwork.ViewModels
{
    public class GeoNode : BindableBase
    {
        public Guid Id { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Distance { get; set; }
        public bool IsUserDefineDistance { get; set; }
        public GeoNodeType Type { get; set; }

        public void CalculateDistance(GeoNode upNode)
        {
            Distance = Math.Sqrt(Math.Pow(X - upNode.X, 2) + Math.Pow(Y - upNode.Y, 2)) + upNode.Distance;
        }
    }
}
