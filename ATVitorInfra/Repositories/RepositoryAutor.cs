using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATVitorCore.Entities;
using ATVitorCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ATVitorInfra.Repositories {
    public class RepositoryAutor : IRepositoryAutor {

        public readonly Database db;

        public RepositoryAutor(Database dbi) {
            db = dbi;
        }

        public void DeleteAutor(Autor autor) {
            db.Autores.Remove(autor);
            db.SaveChanges();
        }

        
        public Autor GetById(Guid id) {
            var autor = db.Autores.Find(id);
            return autor;
        }

        public IEnumerable<Autor> ListarAutores() {
            var autores = db.Autores.AsNoTracking().ToList();
            return autores;
        }

        public void Save(Autor autor) {
            db.Autores.Add(autor);
            db.SaveChanges();
        }

        public void UpdateAutor(Autor autor) {
            db.Autores.Update(autor);
            db.SaveChanges();
        }
    }
}
