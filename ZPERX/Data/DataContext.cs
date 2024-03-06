using Microsoft.EntityFrameworkCore;
using ZPERX.Models;

namespace ZPERX.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AirlineSighting> AirlineSightings { get; set; }
    }
}
