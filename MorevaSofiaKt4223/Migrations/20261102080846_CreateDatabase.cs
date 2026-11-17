using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MorevaSofiaKt4223.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    f_is_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Признак удаления дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_speciality",
                columns: table => new
                {
                    speciality_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор специальности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название специальности"),
                    c_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Код специальности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_speciality_speciality_id", x => x.speciality_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название группы"),
                    c_group_course = table.Column<int>(type: "int4", nullable: false, comment: "Курс"),
                    f_speciality_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор специальности"),
                    f_is_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Признак удаления группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                    table.ForeignKey(
                        name: "fk_cd_group_f_speciality_id",
                        column: x => x.f_speciality_id,
                        principalTable: "cd_speciality",
                        principalColumn: "speciality_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    f_group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы"),
                    f_is_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Признак удаления студента")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_cd_student_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_value = table.Column<int>(type: "int4", nullable: false, comment: "Значение оценки"),
                    f_student_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента"),
                    f_discipline_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_grade_grade_id", x => x.grade_id);
                    table.ForeignKey(
                        name: "fk_cd_grade_f_discipline_id",
                        column: x => x.f_discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_grade_f_student_id",
                        column: x => x.f_student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_grade_f_discipline_id",
                table: "cd_grade",
                column: "f_discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_grade_f_student_id",
                table: "cd_grade",
                column: "f_student_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_group_f_speciality_id",
                table: "cd_group",
                column: "f_speciality_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_f_group_id",
                table: "cd_student",
                column: "f_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_grade");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");

            migrationBuilder.DropTable(
                name: "cd_speciality");
        }
    }
}
