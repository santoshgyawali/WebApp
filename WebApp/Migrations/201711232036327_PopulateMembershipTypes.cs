namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate) VALUES(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate) VALUES(2,10,3,10)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate) VALUES(3,30,6,40)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths,DiscountRate) VALUES(4,50,9,50)");
        }
        
        public override void Down()
        {
        }
    }
}
