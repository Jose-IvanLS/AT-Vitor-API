using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATVitorCore.Entities;
using ATVitorCore.Repositories;
using ATVitorCore;
using ATVitor2.Dto;
using ATVitorInfra;
using ATVitor2.Response;
using Microsoft.EntityFrameworkCore;

namespace ATVitor2.Controller {
    [Route("api/livro")]
    [ApiController]
    public class LivroController : ControllerBase {



        public LivroController(Application application, Database dbi) {
            app = application;
            db = dbi;
        }

        private Application app;
        public readonly Database db;

        [HttpGet]
        public ActionResult GetAll() {
            var livros = app.GetAllBooks();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id) {
            var livro = app.BookById(id);

            return Ok(livro);
        }

        [HttpGet("{id}/autores")]
        public async Task<ActionResult<List<AutorResponse>>> GetAutores(Guid id) {
            var livro = await db.Livros.Include(x => x.Autores).FirstOrDefaultAsync(x => x.Id == id);


            if(livro == null) {
                return NotFound();
            }

            var idsAutores = livro.Autores.Select(x => x.IdAutor) ;

            var autores = db.Autores.Where(autor => idsAutores.Contains(autor.Id));

            List<AutorResponse> list = new List<AutorResponse>();



            foreach(var autor in autores) {
                var response = new AutorResponse();
                response.Id = autor.Id;
                response.Nome = autor.Nome;

                list.Add(response);
            }

            return list;
        }



        [HttpPost]
        public ActionResult Post([FromBody] LivroDto value, Guid idAutor) {
            
            app.SaveBook(value.Nome, value.ISBN, value.Ano, idAutor);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] LivroDto value, Guid id) {
            var livro = app.BookById(id);
            livro.Nome = value.Nome;
            livro.ISBN = value.ISBN;
            livro.Ano = value.Ano;
            app.ChangeBook(livro);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id) {
            var livro = app.BookById(id);
            app.DeleteBook(livro);
            return Ok();
        }
    }
}
