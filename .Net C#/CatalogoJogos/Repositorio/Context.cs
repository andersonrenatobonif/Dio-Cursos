using CatalogoJogos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Repositorio
{
    public class Context : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=ANDERSON\SQLEXPRESS;Database=CatalogoJogos;Trusted_Connection=True;");
        }
    
    }
}
