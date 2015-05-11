namespace ATEA.Migrations
{
    using ATEA.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ATEA.Context.ATEAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ATEA.Context.ATEAContext context)
        {
            // Seeded into the database
            context.Messages.AddOrUpdate(
                m => m.Title,
                new Message { 
                    MessageId = 1,
                    Title = "First seeded message!",
                    Body = "This is seeded! :)",
                    Date = DateTime.Now 
                });
        }
    }
}
