using Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Presents> Presents { get; set; }

        // Az volt írva, hogy a második kötprog leírását használjuk így a projekt mappán kívülre mentem a DB-t
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.//..//DB//presents.db");
        }
    }
}
