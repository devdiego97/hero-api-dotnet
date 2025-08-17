using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hero_api_dotnet.interfaces;
using hero_api_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace hero_api_dotnet.Context
{
    public class HeroeDbContext
    {
        public class HeroesDbContext : DbContext
{
    public HeroesDbContext(DbContextOptions<HeroesDbContext> options) : base(options) { }
    public DbSet<Hero> Heroes => Set<Hero>();

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<Hero>();

            e.ToTable("heroes"); // nome da tabela

            e.HasKey(h => h.Id);
            e.Property(h => h.Name).IsRequired().HasMaxLength(120);

            // Enums: por padrão salvam como int. Se preferir string:
            e.Property(h => h.Type).HasConversion<string>();
           e.Property(h => h.Sex).HasConversion<string>();

            e.Property(h => h.Abilities).HasMaxLength(1400);
            e.Property(h => h.Superpower).HasMaxLength(200);
        }
}
    }
}