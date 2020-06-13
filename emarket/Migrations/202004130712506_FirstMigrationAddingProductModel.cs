namespace emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrationAddingProductModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        image = c.String(),
                        description = c.String(),
                        category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
