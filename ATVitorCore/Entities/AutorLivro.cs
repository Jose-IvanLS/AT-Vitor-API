using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATVitorCore.Entities {
    public class AutorLivro {

        public Guid Id { get; set; }

        public Guid IdLivro { get; set; }
        public Livro Livro { get; set; }
        

        public Guid IdAutor { get; set; }
        public Autor Autor { get; set;}
        
    }
}
