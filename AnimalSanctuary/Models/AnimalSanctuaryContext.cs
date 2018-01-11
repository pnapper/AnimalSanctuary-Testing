using System;
using Microsoft.EntityFrameworkCore;

namespace AnimalSanctuary.Models
{
    public class AnimalSanctuaryContext : DbContext
    {
        public virtual DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=AnimalSanctuary;uid=root;pwd=root;");
    }
}