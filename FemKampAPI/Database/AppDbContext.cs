using FemKampAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FemKampAPI.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<ResourceGroup> ResourceGroup { get; set; }
    }
}
