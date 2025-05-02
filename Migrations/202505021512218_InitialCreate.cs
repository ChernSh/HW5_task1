namespace HW5_task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300),
                        Description = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        AssignedUserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedUserId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.AssignedUserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.TaskAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(nullable: false),
                        TaskItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskItems", t => t.TaskItemId, cascadeDelete: true)
                .Index(t => t.TaskItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskAttachments", "TaskItemId", "dbo.TaskItems");
            DropForeignKey("dbo.TaskItems", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TaskItems", "AssignedUserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "OwnerId", "dbo.Users");
            DropIndex("dbo.TaskAttachments", new[] { "TaskItemId" });
            DropIndex("dbo.TaskItems", new[] { "ProjectId" });
            DropIndex("dbo.TaskItems", new[] { "AssignedUserId" });
            DropIndex("dbo.Projects", new[] { "OwnerId" });
            DropTable("dbo.TaskAttachments");
            DropTable("dbo.TaskItems");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
