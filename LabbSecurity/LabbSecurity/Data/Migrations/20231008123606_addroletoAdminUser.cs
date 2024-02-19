using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabbSecurity.Data.Migrations
{
    public partial class addroletoAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [AspNetUserRoles] (UserId,RoleId) SELECT '8e8104da-ab87-4bb9-a3cd-c7e7c8c60856', Id FROM [AspNetRoles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles] WHERE UserId='8e8104da-ab87-4bb9-a3cd-c7e7c8c60856' ");
        }
    }
}
