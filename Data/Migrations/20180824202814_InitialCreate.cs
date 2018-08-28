using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jetweet.Data.Migrations {
  public partial class InitialCreate : Migration {
    protected override void Up (MigrationBuilder migrationBuilder) {
      migrationBuilder.CreateTable (
        name: "Tweet",
        columns : table => new {
          Id = table.Column<int> (nullable: false)
            .Annotation ("Sqlite:Autoincrement", true),
            ImageUrl = table.Column<string> (nullable: false),
            Text = table.Column<string> (nullable: false)
        },
        constraints : table => { table.PrimaryKey ("PK_Tweet", x => x.Id); });
    }

    protected override void Down (MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable (
        name: "Tweet");
    }
  }
}