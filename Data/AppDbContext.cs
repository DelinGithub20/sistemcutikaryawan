using Microsoft.EntityFrameworkCore;
using sistemcutikaryawan.Models;

namespace sistemcutikaryawan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Cuti> Cutis { get; set; }
    }
}