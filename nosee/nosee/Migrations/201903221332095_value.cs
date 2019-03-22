namespace nosee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class value : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Value", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Items", "Value");
        }
    }
}
