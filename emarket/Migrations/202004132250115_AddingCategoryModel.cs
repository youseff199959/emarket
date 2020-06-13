namespace emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        number_of_products = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Products", "category_id");
            AddForeignKey("dbo.Products", "category_id", "dbo.Categories", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "category_id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_id" });
            DropTable("dbo.Categories");
        }
    }
}
