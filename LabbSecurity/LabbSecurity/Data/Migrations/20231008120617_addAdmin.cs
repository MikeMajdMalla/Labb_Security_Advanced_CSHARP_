using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabbSecurity.Data.Migrations
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Age], [FirstName], [Gender], [LastName]) VALUES (N'8e8104da-ab87-4bb9-a3cd-c7e7c8c60856', N'Admin', N'ADMIN', N'Admin@test7.com', N'ADMIN@TEST7.COM', 0, N'AQAAAAEAACcQAAAAEIURDFfTlDilsvhRDkRIl5QvfqoanAm9DXptIUr7vNc77H94vr7mm4RSaToVJESt4w==', N'CO7FLYOOAM4EGOJG3EAA3ESZS34L5T75', N'924ef186-caaa-4611-b2cf-be275be15bb8', NULL, 0, 0, NULL, 1, 0, 35, N'Tobia', N'Male', N'Petersson')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELTE FROM [AspNetUsers] WHERE Id='8e8104da-ab87-4bb9-a3cd-c7e7c8c60856'");

        }
    }
}
