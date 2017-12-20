namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDOBInCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '7/2/1990' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
