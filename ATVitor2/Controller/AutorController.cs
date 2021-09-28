using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATVitorCore;
using ATVitor2.Dto;
using ATVitor2.Response;
using ATVitorInfra;
using Microsoft.EntityFrameworkCore;

namespace ATVitor2.Controller {
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase {

        public AutorController(Application application, Database dbi) {

            db = dbi;
            app = application;
        }

        public readonly Database db;
        private Application app;

        [HttpGet]
        public ActionResult GetAll() {
            var autores = app.GetAllAutores();

            return Ok(autores);
        }

        [HttpGet("{id}/livros")]
        public async Task<ActionResult<List<LivroResponse>>> GetLivros(Guid id) {
            var livro = await db.Autores.Include(x => x.Livros).FirstOrDefaultAsync(x => x.Id == id);


            if(livro == null) {
                return NotFound();
            }


            var idsLivros = livro.Livros.Select(x => x.IdLivro);

            var livros = db.Autores.Where(livro => idsLivros.Contains(livro.Id));

            List<LivroResponse> lista = new List<LivroResponse>();



            foreach(var livro1 in idsLivros) {
                var a = app.BookById(livro1);
                LivroDto l = new LivroDto();
                var response = new LivroResponse();
                response.Id = a.Id;
                response.Nome = a.Nome;

                lista.Add(response);
            }

                /*foreach(var livro1 in livros) {
                    var response = new LivroResponse();
                    response.Id = livro1.Id;
                    response.Nome = livro1.Nome;

                    lista.Add(response);
                }*/

                return lista;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id) {
            var autor = app.AutorById(id);

            return Ok(autor);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AutorDto value) {

            app.SaveAutor(value.Nome, value.Sobrenome, value.Nascimento);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] AutorDto value, Guid id) {
            var autor = app.AutorById(id);
            autor.Nome = value.Nome;
            autor.Sobrenome = value.Sobrenome;
            autor.Nascimento = value.Nascimento;
            app.ChangeAutor(autor);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id) {
            var autor = app.AutorById(id);
            app.DeleteAutor(autor);
            return Ok();
        }
    }
}
