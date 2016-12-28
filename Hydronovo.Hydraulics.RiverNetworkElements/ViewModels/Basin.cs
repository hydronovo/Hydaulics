using System;
using System.Collections.Generic;

namespace Hydronovo.Hydraulics.PT.RiverNetwork.ViewModels
{
    public class Basin
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public List<River> Rivers { get; }
    }
}
