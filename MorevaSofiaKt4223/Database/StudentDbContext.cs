using Microsoft.EntityFrameworkCore;
using MorevaSofiaKt4223.Database.Configurations;
using MorevaSofiaKt4223.Models;

namespace MorevaSofiaKt4223.Database
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Speciality> Specialities { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Discipline> Disciplines { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SpecialityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
        }
    }
}