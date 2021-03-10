using Microsoft.EntityFrameworkCore.Migrations;

namespace store.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(name: "Stock", defaultValue: 0,table:"Items");
            migrationBuilder.Sql("Insert into Items(Name,Price) values('Item 1',50)");
            migrationBuilder.Sql("Insert into Items(Name,Price) values('Item 2',150)");
            migrationBuilder.Sql("Insert into Items(Name,Price) values('Item 3',20)");
            migrationBuilder.Sql("Insert into Items(Name,Price) values('Item 4',30)");
            migrationBuilder.Sql("Insert into Items(Name,Price) values('Item 5',550)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(name: "Stock", defaultValue: null, table: "Items");
            migrationBuilder.Sql("Delete from Items where Name in ('Item 1','Item 2','Item 3','Item 4','Item 5')");
        }
    }
}
