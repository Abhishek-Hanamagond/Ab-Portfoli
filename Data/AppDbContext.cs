using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portfolio.Models;

namespace portfolio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Projects> Projects { get; set; }

        public DbSet<CaseStudy> CaseStudy { get; set; }

        public DbSet<Blog> Blogs { get; set; }
    }
}
