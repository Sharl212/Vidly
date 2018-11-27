namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttributeToMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
