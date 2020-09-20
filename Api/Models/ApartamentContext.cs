using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class ApartamentContext : DbContext
    {
        public ApartamentContext(DbContextOptions<ApartamentContext> options)
            : base(options)
        {
        }

        public DbSet<Apartament> Apartament { get; set; }
    }
}