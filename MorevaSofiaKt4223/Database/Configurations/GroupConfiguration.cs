using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MorevaSofiaKt4223.Database.Helpers;
using MorevaSofiaKt4223.Models;

namespace MorevaSofiaKt4223.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");

            builder.Property(p => p.GroupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор группы");

            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType($"{ColumnType.String}(100)")
                .HasMaxLength(100)
                .HasComment("Название группы");

            builder.Property(p => p.Course)
                .IsRequired()
                .HasColumnName("c_group_course")
                .HasColumnType(ColumnType.Int)
                .HasComment("Курс");

            builder.Property(p => p.SpecialityId)
                .IsRequired()
                .HasColumnName("f_speciality_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор специальности");

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("f_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Признак удаления группы");

            builder.HasOne(p => p.Speciality)
                .WithMany()
                .HasForeignKey(p => p.SpecialityId)
                .HasConstraintName($"fk_{TableName}_f_speciality_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.SpecialityId)
                .HasDatabaseName($"idx_{TableName}_f_speciality_id");

            builder.Navigation(p => p.Speciality)
                .AutoInclude();
        }
    }
}