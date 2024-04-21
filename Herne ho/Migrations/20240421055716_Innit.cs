using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herne_ho.Migrations
{
    /// <inheritdoc />
    public partial class Innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkerModels",
                columns: table => new
                {
                    WorkerId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerName = table.Column<string>(type: "text", nullable: false),
                    WorkerType = table.Column<int>(type: "integer", nullable: false),
                    WorkerEmail = table.Column<string>(type: "text", nullable: true),
                    WorkerPhone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerModels", x => x.WorkerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerModels");
        }
    }
}
