namespace WindowsEFEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsetsAgregados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        AulaId = c.Int(nullable: false, identity: true),
                        Capacidad = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AulaId);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Programa = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MateriaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Materias");
            DropTable("dbo.Aulas");
        }
    }
}
