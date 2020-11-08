using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCORE.Migrations
{
    public partial class SeedDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("INSERT INTO Alunos(nome,sexo,email,nascimento) VALUES('Vinicius Lemos', 'masculino', 'vinicisiu@hotmail.com', '21/02/1999')");
            //migrationBuilder.Sql("INSERT INTO Alunos(nome,sexo,email,nascimento) VALUES('Vinicius Sousa', 'masculino', 'vinicisisousa@hotmail.com', '21/02/1999')");
            //migrationBuilder.Sql("INSERT INTO Alunos(nome,sexo,email,nascimento) VALUES('José Vinicius ', 'masculino', 'josevinicisius@hotmail.com', '21/02/1999')");
            //migrationBuilder.Sql("INSERT INTO Alunos(nome,sexo,email,nascimento) VALUES('Bia', 'Feminino', 'beeea@hotmail.com', '21/02/1999')");
            //migrationBuilder.Sql("INSERT INTO Alunos(nome,sexo,email,nascimento) VALUES('Maria do socorro', 'Feminino', 'maria@hotmail.com', '20/10/1970')");
            //migrationBuilder.Sql("INSERT INTO Alunos(nome,sexo,email,nascimento) VALUES('Mariah', 'Femino', 'mariah@hotmail.com', '28/11/1997')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Alunos");
        }
    }
}
