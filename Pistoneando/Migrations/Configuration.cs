namespace Pistoneando.Migrations
{
    using Pistoneando.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pistoneando.Models.PistoneandoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Pistoneando.Models.PistoneandoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            context.Categoria.AddOrUpdate(
                c => c.Nombre,
                new Categoria { Nombre = "Utilitarias" },
                new Categoria { Nombre = "Motocicletas" },
                new Categoria { Nombre = "Deportivos"});

            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
