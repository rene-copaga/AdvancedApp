using Microsoft.EntityFrameworkCore;

namespace AdvancedApp.Models
{
    public class AdvancedContext : DbContext
    {
        public AdvancedContext(DbContextOptions<AdvancedContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Ignore(e => e.Id);
            modelBuilder.Entity<Employee>().HasKey(e => e.SSN);

            modelBuilder.Entity<SecondaryIdentity>()
                .HasOne(s => s.PrimaryIdentity)
                .WithOne(e => e.OtherIdentity)
                .HasForeignKey<SecondaryIdentity>(s => s.PrimarySSN);
        }
    }
}
