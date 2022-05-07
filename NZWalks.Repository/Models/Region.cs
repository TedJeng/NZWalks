using System;
using System.Collections.Generic;

#nullable disable

namespace NZWalks.Repository.Models
{
    public partial class Region
    {
        public Region()
        {
            Walks = new HashSet<Walk>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Population { get; set; }

        public virtual ICollection<Walk> Walks { get; set; }
    }
}
