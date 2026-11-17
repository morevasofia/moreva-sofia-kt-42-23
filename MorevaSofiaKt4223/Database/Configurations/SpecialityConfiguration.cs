using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MorevaSofiaKt4223.Database.Helpers;
using MorevaSofiaKt4223.Models;

namespace MorevaSofiaKt4223.Database.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        private const string TableName = "cd_speciality";

        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.SpecialityId)
                .HasName($"pk_{TableName}_speciality_id");

            builder.Property(p => p.SpecialityId)
                .ValueGeneratedOnAdd()
                .HasColumnName("speciality_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор специальности");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnName("c_title")
                .HasColumnType($"{ColumnType.String}(100)")
                .HasMaxLength(100)
                .HasComment("Название специальности");

            builder.Property(p => p.Code)
                .IsRequired(false)
                .HasColumnName("c_code")
                .HasColumnType($"{ColumnType.String}(100)")
                .HasMaxLength(100)
                .HasComment("Код специальности");
        }
    }
}