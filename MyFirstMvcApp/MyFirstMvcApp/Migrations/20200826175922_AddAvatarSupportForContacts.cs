using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstMvcApp.Migrations
{
    public partial class AddAvatarSupportForContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarContent",
                table: "ContactListEntry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarContent",
                table: "ContactListEntry");
        }
    }
}
