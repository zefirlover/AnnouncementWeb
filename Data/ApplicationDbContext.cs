using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnnouncementWeb.Data.Contracts;
using AnnouncementWeb.Models;

namespace AnnouncementWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Announcement> Announcements { get; set; }
        
        public override int SaveChanges()
        {
            UpdateDates();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateDates();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateDates();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateDates();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateDates()
        {
            var now = DateTime.UtcNow;

            var entries = ChangeTracker
                .Entries()
                .Where(x => x.Entity is IWithDateCreated);

            foreach (var entry in entries)
            {
                var entity = (IWithDateCreated)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.SetDateCreated(now);
                }
                else
                {
                    entry.Property(nameof(IWithDateCreated.DateCreated)).IsModified = false;
                }
            }
        }
    }
}