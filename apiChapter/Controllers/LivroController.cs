using apiChapter.Models;
using apiChapter.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apiChapter.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly LivroRepository _livroRepository;
        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livroProcurado = _livroRepository.BuscarPorId(id);
                if (livroProcurado == null)
                {
                    return NotFound();
                }
                return Ok(livroProcurado);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {

            try
            {
                _livroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {

            try
            {
                _livroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
