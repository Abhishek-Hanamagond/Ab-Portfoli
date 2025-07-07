using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio.Migrations
{
    /// <inheritdoc />
    public partial class BlogsUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "skil",
                table: "Blogs",
                newName: "skill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "skill",
                table: "Blogs",
                newName: "skil");
        }
    }
}
