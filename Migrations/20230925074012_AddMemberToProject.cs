using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Project_ProjectId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_ProjectId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Member");

            migrationBuilder.CreateTable(
                name: "MemberProject",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProject", x => new { x.MembersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_MemberProject_Member_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberProject_ProjectsId",
                table: "MemberProject",
                column: "ProjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberProject");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Member_ProjectId",
                table: "Member",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Project_ProjectId",
                table: "Member",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
