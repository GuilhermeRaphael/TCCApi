using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCCApi.Models;

namespace TCCApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Objeto> TB_OBJETOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Objeto>().ToTable("TB_OBJETOS");

            modelBuilder.Entity<Objeto>().HasData
            (
                new Objeto { Id = 1, Nome = "Mesa", Descricao = "Mesa de madeira", LocalidadePrimaria ="Predio A", LocalidadeSecundaria = "Andar 1", LocalidadeTercearia ="Sala 101", Situacao = "Ativa", idTipoObjeto = 1, DataInclusao ="2025-06-20", IdUsuarioInclusao = 100, DataAtualizacao = "2025-06-21", IdUsuarioAtualizacao = 100 },
                new Objeto { Id = 2, Nome = "Cadeira",  Descricao = "Cadeira ergonômica para escritório",  LocalidadePrimaria = "Prédio B",LocalidadeSecundaria = "Andar 2",LocalidadeTercearia = "Sala 205",Situacao = "Em uso",idTipoObjeto = 2,DataInclusao = "2025-06-18", IdUsuarioInclusao = 101,DataAtualizacao = "2025-06-20",IdUsuarioAtualizacao = 101}
            );
        }


    }
}