namespace DemoWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        IdHotel = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Category = c.Int(nullable: false),
                        HasWifi = c.Boolean(nullable: false),
                        HasParking = c.Boolean(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.IdHotel);
            
            CreateTable(
                "dbo.LinkRoomReservations",
                c => new
                    {
                        IdLinkRoomReservation = c.Int(nullable: false, identity: true),
                        PriceRoom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdReservation = c.Int(nullable: false),
                        IdRoom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLinkRoomReservation);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        IdPicture = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IdRoom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPicture);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        IdReservation = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Name = c.String(),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.IdReservation);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        IdRoom = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasTV = c.Boolean(nullable: false),
                        HasHairDryer = c.Boolean(nullable: false),
                        IdHotel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRoom)
                .ForeignKey("dbo.Hotels", t => t.IdHotel, cascadeDelete: true)
                .Index(t => t.IdHotel);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "IdHotel", "dbo.Hotels");
            DropIndex("dbo.Rooms", new[] { "IdHotel" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.Pictures");
            DropTable("dbo.LinkRoomReservations");
            DropTable("dbo.Hotels");
        }
    }
}
