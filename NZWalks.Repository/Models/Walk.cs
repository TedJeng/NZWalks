using System;
using System.Collections.Generic;

#nullable disable

namespace NZWalks.Repository.Models
{
    public partial class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual WalkDifficulty WalkDifficulty { get; set; }
    }
}
