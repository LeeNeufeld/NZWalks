using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDBContext NZWalksDBContext;
        public RegionRepository(NZWalksDBContext NZWalksDBContext)
        {
            this.NZWalksDBContext = NZWalksDBContext;
        }

        public async Task< IEnumerable<Region>> GetAllAsync()
        {
           return await NZWalksDBContext.Regions.ToListAsync();
        }
    }
}
