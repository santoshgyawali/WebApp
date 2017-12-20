namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");
            //Sql("INSERT INTO MembershipType(id,Name) VALUES (1, 123) ON DUPLICATE KEY UPDATE Name = 123 ");
           // Sql("INSERT INTO MembershipType SET id = 2, Name = 456 ON DUPLICATE KEY UPDATE Name = 456");
            //Sql("INSERT INTO MembershipType(Name) VALUES (Monthly) SELECT Name From MembershipType WHERE Id=2");
           // Sql("INSERT INTO MembershipType(Name) VALUES (Quarterly) SELECT Name From MembershipType WHERE Id=3");
            //Sql("INSERT INTO MembershipType(Name) VALUES (Semi Yearly) SELECT Name From MembershipType WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
