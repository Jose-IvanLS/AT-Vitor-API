using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATVitorCore.Entities {
    public class Autor {


        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }

        public ICollection<AutorLivro> Livros { get; set; } = new List<AutorLivro>();

    }
}
