namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genre(Id,Name) VALUES(1,'Action')");
            Sql("INSERT INTO Genre(Id,Name) VALUES(2,'ActionComedy')");
            Sql("INSERT INTO Genre(Id,Name) VALUES(3,'Romance')");
            Sql("INSERT INTO Genre(Id,Name) VALUES(4,'Thriller')");
            Sql("INSERT INTO Genre(Id,Name) VALUES(5,'Comedy')");
            Sql("INSERT INTO Genre(Id,Name) VALUES(6,'Adventure')");
        }
        
        public override void Down()
        {
        }
    }
}
