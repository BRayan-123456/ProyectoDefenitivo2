using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoDefenitivo2.Data.Migrations
{
    public partial class acce1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoAccesorio",
                columns: table => new
                {
                    TipoAccesorioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAccesorio", x => x.TipoAccesorioID);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    TipoPersonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersona", x => x.TipoPersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    AccesoriosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoAccesorioID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Talla = table.Column<string>(nullable: true),
                    Valor = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.AccesoriosID);
                    table.ForeignKey(
                        name: "FK_Accesorios_TipoAccesorio_TipoAccesorioID",
                        column: x => x.TipoAccesorioID,
                        principalTable: "TipoAccesorio",
                        principalColumn: "TipoAccesorioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoPersonaID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Documento = table.Column<int>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Discapacidad = table.Column<string>(nullable: true),
                    Antecedentes = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaID);
                    table.ForeignKey(
                        name: "FK_Persona_TipoPersona_TipoPersonaID",
                        column: x => x.TipoPersonaID,
                        principalTable: "TipoPersona",
                        principalColumn: "TipoPersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_TipoAccesorioID",
                table: "Accesorios",
                column: "TipoAccesorioID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoPersonaID",
                table: "Persona",
                column: "TipoPersonaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoAccesorio");

            migrationBuilder.DropTable(
                name: "TipoPersona");
        }
    }
}
