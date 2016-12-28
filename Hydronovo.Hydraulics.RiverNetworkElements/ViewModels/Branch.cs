using System;
using System.Collections.Generic;

namespace Hydronovo.Hydraulics.PT.RiverNetwork.ViewModels
{
    public class Branch
    {
        public Guid Id { get;}
        public string Name { get; }
        public double Length { get; }
        public List<GeoNode> GeoNodes { get; }
    }
}
