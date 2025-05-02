namespace HW5_task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToTaskItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskItems", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskItems", "Status");
        }
    }
}
