using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MorevaSofiaKt4223.Database.Helpers;
using MorevaSofiaKt4223.Models;

namespace MorevaSofiaKt4223.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("discipline_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_name")
                .HasColumnType($"{ColumnType.String}(100)")
                .HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("f_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Признак удаления дисциплины");
        }
    }
}