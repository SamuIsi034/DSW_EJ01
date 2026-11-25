using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSW_3P_EJ01.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Personajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "Personajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Poder",
                table: "Personajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Videojuego",
                table: "Personajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "Poder",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "Videojuego",
                table: "Personajes");
        }
    }
}
