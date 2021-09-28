using ATVitorCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATVitorCore.Repositories {
    public interface IRepositoryAutor {

        IEnumerable<Autor> ListarAutores();
        Autor GetById(Guid id);
        void Save(Autor autor);
        void DeleteAutor(Autor autor);
        void UpdateAutor(Autor autor);
    }
}
