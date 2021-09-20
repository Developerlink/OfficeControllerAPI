using Microsoft.EntityFrameworkCore;
using OfficeControllerModelLibrary.Models;

namespace OfficeControllerDataLibrary
{
    public class OfficeControllerDbContext : DbContext
    {
        public OfficeControllerDbContext(DbContextOptions<OfficeControllerDbContext> options)
            :base(options)
        {
        }

        public OfficeControllerDbContext()
        {

        }

        public DbSet<Alarm> Alarm { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<LightValue> LightValue { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Temperature> Temperature { get; set; }
        public DbSet<TempScale> TempScale { get; set; }

    }
}
