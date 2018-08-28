using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jetweet.Data.Migrations {
  public partial class ChangetoTweet : Migration {
    protected override void Up (MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable (
        name: "Tweet");

      migrationBuilder.CreateTable (
        name: "Tweet",
        columns : table => new {
          Id = table.Column<int> (nullable: false)
            .Annotation ("Sqlite:Autoincrement", true),
            Text = table.Column<string> (nullable: false),
            ImageUrl = table.Column<string> (nullable: false)
        },
        constraints : table => { table.PrimaryKey ("PK_Tweet", x => x.Id); });
    }

    protected override void Down (MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable (
        name: "Tweet");

      migrationBuilder.CreateTable (
        name: "Tweet",
        columns : table => new {
          Id = table.Column<int> (nullable: false)
            .Annotation ("Sqlite:Autoincrement", true),
            Text = table.Column<string> (nullable: false),
            ImageUrl = table.Column<string> (nullable: false)
        },
        constraints : table => { table.PrimaryKey ("PK_Tweet", x => x.Id); });
    }
  }
}