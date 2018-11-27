namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMakeFieldsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
