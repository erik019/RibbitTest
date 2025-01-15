using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ribbit_Test.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    CantidadEnStock = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CantidadEnStock", "Descripcion", "FechaCreacion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 10, "Laptop de alta gama para desarrolladores", new DateTime(2025, 1, 15, 2, 15, 54, 845, DateTimeKind.Utc).AddTicks(9834), "Laptop", 1500.99m },
                    { 2, 50, "Mouse inalámbrico ergonómico", new DateTime(2025, 1, 15, 2, 15, 54, 845, DateTimeKind.Utc).AddTicks(9971), "Mouse", 25.50m },
                    { 3, 20, "Teclado mecánico retroiluminado", new DateTime(2025, 1, 15, 2, 15, 54, 845, DateTimeKind.Utc).AddTicks(9972), "Teclado", 80.75m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
