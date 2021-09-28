using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATVitorCore.Entities {
    public class Livro {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string ISBN { get; set; }
        public int Ano { get; set; }

        public ICollection<AutorLivro> Autores { get; set; } = new List<AutorLivro>();

        public void AssociarAutor(Autor autor) {
            var testeGuid = Guid.NewGuid();
            AutorLivro autorLivro = new AutorLivro();
            autorLivro.Id = testeGuid;
            autorLivro.IdAutor = autor.Id;
            autorLivro.IdLivro = Id;

            Autores.Add(autorLivro);

        }

    }
}
