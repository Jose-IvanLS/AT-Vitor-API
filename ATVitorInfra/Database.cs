using Microsoft.EntityFrameworkCore;
using System;
using ATVitorCore.Entities;

namespace ATVitorInfra {
    public class Database : DbContext {

        
        public Database(DbContextOptions options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AutorLivro>().HasKey(al => new { al.IdLivro, al.IdAutor });
            modelBuilder.Entity<AutorLivro>().HasOne(al => al.Livro).WithMany(a => a.Autores).HasForeignKey(al => al.IdLivro);
            modelBuilder.Entity<AutorLivro>().HasOne(al => al.Autor).WithMany(l => l.Livros).HasForeignKey(al => al.IdAutor);
        }


        //Tabelas das entidades são criadas aqui.
        public DbSet<Autor> Autores { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<AutorLivro> AutorLivro { get; set; }

    }
}
