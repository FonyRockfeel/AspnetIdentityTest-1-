namespace AspnetIdentityTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDtoGUID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SupportRequests");

            DropColumn("dbo.SupportRequests", "Id");
            AddColumn("dbo.SupportRequests", "Id", c => c.Guid(nullable: false, identity: true));

            AddPrimaryKey("dbo.SupportRequests", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SupportRequests");

            DropColumn("dbo.SupportRequests", "Id");
            AddColumn("dbo.SupportRequests", "Id", c => c.Int(nullable: false, identity: true));

            AddPrimaryKey("dbo.SupportRequests", "Id");
        }
    }
}
