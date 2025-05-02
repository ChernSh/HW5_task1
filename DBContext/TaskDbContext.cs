using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW5_task1.Models;
namespace HW5_task1.DBContext
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("name=TaskTrackerDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasRequired(t => t.AssignedUser)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.AssignedUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskItem>()
                .HasRequired(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .WillCascadeOnDelete(false);
        }
    }
}
