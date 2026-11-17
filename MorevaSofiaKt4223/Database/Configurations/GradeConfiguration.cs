using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MorevaSofiaKt4223.Database.Helpers;
using MorevaSofiaKt4223.Models;

namespace MorevaSofiaKt4223.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "cd_grade";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.GradeId)
                .HasName($"pk_{TableName}_grade_id");

            builder.Property(p => p.GradeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("grade_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор оценки");

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("c_value")
                .HasColumnType(ColumnType.Int)
                .HasComment("Значение оценки");

            builder.Property(p => p.StudentId)
                .IsRequired()
                .HasColumnName("f_student_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор студента");

            builder.Property(p => p.DisciplineId)
                .IsRequired()
                .HasColumnName("f_discipline_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор дисциплины");

            builder.HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .HasConstraintName($"fk_{TableName}_f_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.StudentId)
                .HasDatabaseName($"idx_{TableName}_f_student_id");

            builder.Navigation(p => p.Student)
                .AutoInclude();

            builder.HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DisciplineId)
                .HasConstraintName($"fk_{TableName}_f_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.DisciplineId)
                .HasDatabaseName($"idx_{TableName}_f_discipline_id");

            builder.Navigation(p => p.Discipline)
                .AutoInclude();
        }
    }
}