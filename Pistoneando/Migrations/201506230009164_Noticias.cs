namespace Pistoneando.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Noticias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Noticia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        Titulo = c.String(nullable: false),
                        FechaPublicacion = c.DateTime(nullable: false),
                        ImagenPortada = c.String(nullable: false),
                        DescripcionCorta = c.String(nullable: false, maxLength: 170),
                        DescripcionLarga = c.String(nullable: false),
                        Contenido = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticia", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Noticia", new[] { "CategoriaID" });
            DropTable("dbo.Noticia");
            DropTable("dbo.Categoria");
        }
    }
}
