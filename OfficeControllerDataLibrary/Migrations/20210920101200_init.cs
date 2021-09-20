using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeControllerDataLibrary.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempScale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempScale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alarm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarm_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LightValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LightValue_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    TempScaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temperature_TempScale_TempScaleId",
                        column: x => x.TempScaleId,
                        principalTable: "TempScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarm_RoomId",
                table: "Alarm",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LightValue_RoomId",
                table: "LightValue",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_RoomId",
                table: "Temperature",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_TempScaleId",
                table: "Temperature",
                column: "TempScaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarm");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "LightValue");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "TempScale");
        }
    }
}
