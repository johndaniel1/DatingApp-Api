namespace DatingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photoclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        IsMain = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "KnownAs", c => c.String());
            AddColumn("dbo.Users", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastActive", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Introduction", c => c.String());
            AddColumn("dbo.Users", "LookingFor", c => c.String());
            AddColumn("dbo.Users", "Interests", c => c.String());
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Interests");
            DropColumn("dbo.Users", "LookingFor");
            DropColumn("dbo.Users", "Introduction");
            DropColumn("dbo.Users", "LastActive");
            DropColumn("dbo.Users", "Created");
            DropColumn("dbo.Users", "KnownAs");
            DropColumn("dbo.Users", "DateOfBirth");
            DropColumn("dbo.Users", "Gender");
            DropTable("dbo.Photos");
        }
    }
}
