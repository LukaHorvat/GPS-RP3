namespace GPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Graph : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Graph", "GraphId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Graph", "GraphId");
        }
    }
}
