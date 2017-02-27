namespace GPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class graph1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Graph", "Connections", c => c.String());
            AddColumn("dbo.Graph", "Data", c => c.String());
            AddColumn("dbo.Graph", "UsedIds", c => c.String());
            AddColumn("dbo.Graph", "DeletedIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Graph", "DeletedIds");
            DropColumn("dbo.Graph", "UsedIds");
            DropColumn("dbo.Graph", "Data");
            DropColumn("dbo.Graph", "Connections");
        }
    }
}
