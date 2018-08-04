namespace AspnetIdentityTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfgs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Operator = c.String(),
                        Time = c.DateTime(nullable: false),
                        Text = c.String(),
                        ClientName = c.String(),
                        Executor = c.String(),
                        SolutionComment = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.SupportRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupportRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OperatorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.RequestModels");
        }
    }
}
