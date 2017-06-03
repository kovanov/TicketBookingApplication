namespace TicketBookingApplication.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AirplaneId = c.Int(nullable: false),
                        ArrivalCityId = c.Int(nullable: false),
                        DepartureCityId = c.Int(nullable: false),
                        ArivalTime = c.DateTime(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airplanes", t => t.AirplaneId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.ArrivalCityId, cascadeDelete: false)
                .ForeignKey("dbo.Cities", t => t.DepartureCityId, cascadeDelete: false)
                .Index(t => t.AirplaneId)
                .Index(t => t.ArrivalCityId)
                .Index(t => t.DepartureCityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PostIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        FlightId = c.Int(nullable: false),
                        ComfortId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeatNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comforts", t => t.ComfortId, cascadeDelete: true)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.ComfortId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Comforts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Sex = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Orders", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Orders", "ComfortId", "dbo.Comforts");
            DropForeignKey("dbo.Flights", "DepartureCityId", "dbo.Cities");
            DropForeignKey("dbo.Flights", "ArrivalCityId", "dbo.Cities");
            DropForeignKey("dbo.Flights", "AirplaneId", "dbo.Airplanes");
            DropIndex("dbo.Orders", new[] { "ProfileId" });
            DropIndex("dbo.Orders", new[] { "ComfortId" });
            DropIndex("dbo.Orders", new[] { "FlightId" });
            DropIndex("dbo.Flights", new[] { "DepartureCityId" });
            DropIndex("dbo.Flights", new[] { "ArrivalCityId" });
            DropIndex("dbo.Flights", new[] { "AirplaneId" });
            DropTable("dbo.Profiles");
            DropTable("dbo.Comforts");
            DropTable("dbo.Orders");
            DropTable("dbo.Cities");
            DropTable("dbo.Flights");
            DropTable("dbo.Airplanes");
        }
    }
}
