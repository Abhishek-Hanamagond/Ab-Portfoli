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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(b => b.publishedAt)
                    .HasColumnType("timestamp with time zone") // Ensures TIMESTAMPTZ in PostgreSQL
                    .HasConversion(dateTimeConverter);
            });
        }

    }
}
