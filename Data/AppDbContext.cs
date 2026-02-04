using Microsoft.EntityFrameworkCore;
using RegistroVisitatori.Models;

namespace RegistroVisitatori.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Visita> Visite => Set<Visita>();
    }
}
