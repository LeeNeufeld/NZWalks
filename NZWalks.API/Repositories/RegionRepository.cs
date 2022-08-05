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

        public async Task<Region> AddAsync(Region region)
        {
          region.Id = Guid.NewGuid();
          await NZWalksDBContext.AddAsync(region);
          await NZWalksDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await NZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            NZWalksDBContext.Regions.Remove(region);
            await NZWalksDBContext.SaveChangesAsync();

            return region;
        }

        public async Task< IEnumerable<Region>> GetAllAsync()
        {
           return await NZWalksDBContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
          return await NZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
          var existingRegion = await NZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if( existingRegion == null)
            {
                return null; 
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat  = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

           await NZWalksDBContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
