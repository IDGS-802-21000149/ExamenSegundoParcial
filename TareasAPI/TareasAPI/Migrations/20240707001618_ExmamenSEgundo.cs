using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasAPI.Migrations
{
    /// <inheritdoc />
    public partial class ExmamenSEgundo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    idTarea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    imagen = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tarea__756A5402495A31DF", x => x.idTarea);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");
        }
    }
}
