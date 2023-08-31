using Microsoft.EntityFrameworkCore;
using WorldDatabase.Models;

namespace WorldDatabase.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>(b =>
            {
                b.HasMany(r => r.States)
                .WithOne(o => o.Country).HasForeignKey(o => o.Country_id).OnDelete(DeleteBehavior.Restrict);

                b.HasMany(r => r.Timezones)
                .WithOne(o => o.Country).HasForeignKey(o => o.CountryId).OnDelete(DeleteBehavior.Restrict);

                b.HasOne(r => r.Translations)
                .WithOne(o => o.Country).HasForeignKey<Translation>(o => o.CountryId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<State>(b => { 
                b.HasMany(r => r.Cities)
                .WithOne(o => o.State).HasForeignKey(f => f.State_id).OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Timezone> Timezones { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
    }
}
