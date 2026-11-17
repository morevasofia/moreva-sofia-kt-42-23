using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MorevaSofiaKt4223.Database.Helpers;
using MorevaSofiaKt4223.Models;

namespace MorevaSofiaKt4223.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("student_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType($"{ColumnType.String}(100)")
                .HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType($"{ColumnType.String}(100)")
                .HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("f_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор группы");

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("f_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Признак удаления студента");

            builder.HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName($"fk_{TableName}_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.GroupId)
                .HasDatabaseName($"idx_{TableName}_f_group_id");

            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}