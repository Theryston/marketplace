using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Data.Context
{
    internal class MarketplaceDbContext : DbContext
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options)
        { }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketplaceDbContext).Assembly);
        }
    }
}
