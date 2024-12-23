using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Database=testEF;Integrated Security=True;TrustServerCertificate=true")
                          .LogTo(Console.WriteLine, LogLevel.Information)
                          .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityBase>(builder => 
            {
                builder.UseTpcMappingStrategy();

                builder.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("Places");

                entity.HasOne(p => p.Organization)
                    .WithOne(o => o.Place)
                    .HasForeignKey<Place>(p => p.OrganizationId);
                
                entity.HasOne(p => p.Location)
                .WithOne(l => l.Place)
                    .HasForeignKey<Place>(p => p.LocationId);

                //entity.Navigation(p => p.Organization).AutoInclude();
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organizations");
                
                entity.Property(o => o.Name).HasMaxLength(100).IsRequired();

                //entity.Navigation(x => x.Place).AutoInclude();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations");
                
                entity.Property(l => l.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
