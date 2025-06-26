using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIniAccountSystem.Models;

namespace MIniAccountSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModule> UserModules { get; set; }
        //public DbSet<Account> Accounts { get; set; }  // << Add this inside the class!

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Children)
                .WithOne(a => a.Parent)
                .HasForeignKey(a => a.ParentId);
        }
    }
}
