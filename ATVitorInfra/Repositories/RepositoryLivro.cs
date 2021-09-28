using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATVitorCore.Entities;
using ATVitorCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ATVitorInfra.Repositories {

    public class RepositoryLivro : IRepositoryLivro {

        public readonly Database db;

        public RepositoryLivro(Database dbi) {
            db = dbi;
        }

        public void DeleteLivro(Livro livro) {
            db.Livros.Remove(livro);
            db.SaveChanges();
        }

        public Livro GetById(Guid id) {
            var livro = db.Livros.Find(id);
            return livro;
        }

        public IEnumerable<Livro> ListarLivros() {
            var livros = db.Livros.AsNoTracking().ToList();
            return livros;
        }

        public void Save(Livro livro) {
            
            db.Livros.Add(livro);
            db.SaveChanges();
        }

        public void UpdateLivro(Livro livro) {
            db.Livros.Update(livro);
            db.SaveChanges();
        }
    }
}
