namespace GPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class graph : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Graph", "GraphId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Graph", "GraphId", c => c.Int(nullable: false));
        }
    }
}
