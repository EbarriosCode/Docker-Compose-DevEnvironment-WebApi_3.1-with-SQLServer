using Microsoft.EntityFrameworkCore.Migrations;

namespace DockerizingWebApi.Migrations
{
    public partial class Initial_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    ArtistaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.ArtistaID);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistaID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Anio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Album_Artista_ArtistaID",
                        column: x => x.ArtistaID,
                        principalTable: "Artista",
                        principalColumn: "ArtistaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistaID",
                table: "Album",
                column: "ArtistaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artista");
        }
    }
}
