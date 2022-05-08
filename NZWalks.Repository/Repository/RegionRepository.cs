using Microsoft.EntityFrameworkCore;
using NZWalks.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZWalks.Repository.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksContext _context;

        public RegionRepository(NZWalksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _context.Regions
                                 .Include(r => r.Walks)
                                 .ToListAsync();
        }

    }
}
