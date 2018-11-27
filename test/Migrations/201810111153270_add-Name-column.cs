namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNamecolumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.Short(nullable: false));
        }
    }
}
