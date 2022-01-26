using BugTrackerAPI.Maps;
using BugTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BugTrackerAPI.Database
{
    public class BugContext : DbContext
    {
        public BugContext(DbContextOptions<BugContext> options) : base(options)
        {
        }

        public DbSet<Bug> Bugs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            new BugMap(modelBuilder.Entity<Bug>());
        }
    }
}
