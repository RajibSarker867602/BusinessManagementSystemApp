namespace BusinessManagementSystemApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialstate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CategoryCode = c.String(nullable: false),
                        IsActive = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustCode = c.Int(nullable: false),
                        CustName = c.String(nullable: false, maxLength: 50),
                        CustEmail = c.String(nullable: false),
                        CustAddress = c.String(nullable: false),
                        CustContact = c.Int(nullable: false),
                        CustLoyaltyPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false, maxLength: 5),
                        ProductName = c.String(nullable: false, maxLength: 20),
                        Image = c.String(),
                        ReorderLevel = c.Int(nullable: false),
                        AvailableQuantity = c.Int(nullable: false),
                        CurrentMRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        IsActive = c.String(),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManufactureDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewMRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        InvoiceNo = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.Int(nullable: false),
                        ContactPerson = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerModelsId = c.Int(nullable: false),
                        CustomerPayment = c.Single(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModels", t => t.CustomerModelsId, cascadeDelete: true)
                .Index(t => t.CustomerModelsId);
            
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        ProductsId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        Products_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Products_ProductId)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.Products_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesDetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.SalesDetails", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerModelsId", "dbo.CustomerModels");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SalesDetails", new[] { "Products_ProductId" });
            DropIndex("dbo.SalesDetails", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "CustomerModelsId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.SalesDetails");
            DropTable("dbo.Sales");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Products");
            DropTable("dbo.CustomerModels");
            DropTable("dbo.Categories");
        }
    }
}
