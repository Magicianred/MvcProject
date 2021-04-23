namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            AlterColumn("dbo.Headings", "WriterID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contents", "WriterID", c => c.Int());
            CreateIndex("dbo.Headings", "WriterID");
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Headings", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Headings", new[] { "WriterID" });
            AlterColumn("dbo.Contents", "WriterID", c => c.Int(nullable: false));
            AlterColumn("dbo.Headings", "WriterID", c => c.Int());
            CreateIndex("dbo.Contents", "WriterID");
            CreateIndex("dbo.Headings", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
            AddForeignKey("dbo.Headings", "WriterID", "dbo.Writers", "WriterID");
        }
    }
}
