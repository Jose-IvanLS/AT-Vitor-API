using ATVitorCore.Entities;
using ATVitorCore.Repositories;
using System;
using System.Collections.Generic;

namespace ATVitorCore {
    public class Application {

        public IRepositoryLivro RepoLivro { get; }
        public IRepositoryAutor RepoAutor { get; }

        public Application(IRepositoryLivro RepoLivroC, IRepositoryAutor RepoAutorC) {

            RepoLivro = RepoLivroC;
            RepoAutor = RepoAutorC;
        }

        public void SaveBook(string nome, string ISBN, int ano, Guid idAutor) {
            
            var NovoLivro = new Livro();
            NovoLivro.Autores = new List<AutorLivro>();
            NovoLivro.Id = Guid.NewGuid();
            NovoLivro.Nome = nome;
            NovoLivro.ISBN = ISBN;
            NovoLivro.Ano = ano;

            var aut = RepoAutor.GetById(idAutor);

            NovoLivro.AssociarAutor(aut);

            RepoLivro.Save(NovoLivro);
        }

        public IEnumerable<Livro> GetAllBooks() {
            var livros = RepoLivro.ListarLivros();
            return livros;
        }

        public Livro BookById(Guid id) {
            var livro = RepoLivro.GetById(id);
            return livro;
            
        }

        public void ChangeBook(Livro livro) {
            RepoLivro.UpdateLivro(livro);
        }

        public void DeleteBook(Livro livro) {
            RepoLivro.DeleteLivro(livro);

        }
        /*
         * 
         
         
         
         
         
         
         
         
         
         
         
         
         
         */
        public IEnumerable<Autor> GetAllAutores() {
            var autores = RepoAutor.ListarAutores();
            return autores;
        }

        public void SaveAutor(string nome, string sobrenome, DateTime nascimento) {

            var NewAutor = new Autor();
            NewAutor.Id = Guid.NewGuid();
            NewAutor.Nome = nome;
            NewAutor.Sobrenome = sobrenome;
            NewAutor.Nascimento = nascimento;

            RepoAutor.Save(NewAutor);

        }

        public Autor AutorById(Guid id) {
            var autor = RepoAutor.GetById(id);
            return autor;
        }

        public void ChangeAutor(Autor autor) {
            RepoAutor.UpdateAutor(autor);
        }

        public void DeleteAutor(Autor autor) {
            RepoAutor.DeleteAutor(autor);

        }
    }
}
