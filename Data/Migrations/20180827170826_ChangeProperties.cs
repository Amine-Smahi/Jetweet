using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jetweet.Data.Migrations {
  public partial class ChangeProperties : Migration {
    protected override void Up (MigrationBuilder migrationBuilder) { }

    protected override void Down (MigrationBuilder migrationBuilder) {
      migrationBuilder.RenameColumn (
        name: "Text",
        table: "Tweet",
        newName: "Text");

      migrationBuilder.RenameColumn (
        name: "ImageUrl",
        table: "Tweet",
        newName: "ImageUrl");
    }
  }
}