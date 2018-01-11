using Microsoft.EntityFrameworkCore;

namespace AnimalSanctuary.Models
{
    public class TestDbContext : AnimalSanctuaryContext
    {
        public override DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;port=8889;database=AnimalSanctuary_test;uid=root;pwd=root;");
        }
    }
}