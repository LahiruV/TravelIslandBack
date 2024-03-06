using Microsoft.EntityFrameworkCore;
using TravelIsland.Models;

namespace TravelIsland.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AirlineSighting> AirlineSightings { get; set; }
    }
}
