namespace emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOnCartModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "product_id", "dbo.Products");
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", new[] { "added_at", "product_id" });
            AddForeignKey("dbo.Carts", "product_id", "dbo.Products", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "product_id", "dbo.Products");
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", "product_id");
            AddForeignKey("dbo.Carts", "product_id", "dbo.Products", "id");
        }
    }
}
