using System;
using System.Collections.Generic;

namespace Hydronovo.Hydraulics.PT.RiverNetwork.ViewModels
{
    public class River
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public List<Branch> Branches { get; }
    }
}
