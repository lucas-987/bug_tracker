using BugTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTrackerAPI.Maps
{
    public class BugMap
    {
        public BugMap(EntityTypeBuilder<Bug> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("bugs");

            entityBuilder.Property(x => x.Title).HasColumnName("title");
            entityBuilder.Property(x => x.Description).HasColumnName("description");
            entityBuilder.Property(x => x.CreatedDate).HasColumnName("created_date");
            entityBuilder.Property(x => x.Status).HasColumnName("status");
            entityBuilder.Property(x => x.NbReport).HasColumnName("nb_report");
            entityBuilder.Property(x => x.Priority).HasColumnName("priority");
            entityBuilder.Property(x => x.FixedDate).HasColumnName("fixed_date");
            entityBuilder.Property(x => x.DueDate).HasColumnName("due_date");
        }
    }
}
