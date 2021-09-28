using ATVitorCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATVitorCore.Repositories {
    public interface IRepositoryLivro {
        IEnumerable<Livro> ListarLivros();
        Livro GetById(Guid id);        
        void Save(Livro livro);
        void DeleteLivro(Livro livro);
        void UpdateLivro(Livro livro);
    }
}
