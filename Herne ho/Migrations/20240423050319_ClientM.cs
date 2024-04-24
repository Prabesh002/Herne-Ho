using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herne_ho.Migrations
{
    /// <inheritdoc />
    public partial class ClientM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientModelClientId",
                table: "WorkerModels",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientModels",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    CLientPhone = table.Column<string>(type: "text", nullable: true),
                    ClientEmail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModels", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerModels_ClientModelClientId",
                table: "WorkerModels",
                column: "ClientModelClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerModels_ClientModels_ClientModelClientId",
                table: "WorkerModels",
                column: "ClientModelClientId",
                principalTable: "ClientModels",
                principalColumn: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerModels_ClientModels_ClientModelClientId",
                table: "WorkerModels");

            migrationBuilder.DropTable(
                name: "ClientModels");

            migrationBuilder.DropIndex(
                name: "IX_WorkerModels_ClientModelClientId",
                table: "WorkerModels");

            migrationBuilder.DropColumn(
                name: "ClientModelClientId",
                table: "WorkerModels");
        }
    }
}
