using Microsoft.AspNetCore.Mvc;
using WebApi_Livraria.DTO.Livro;
using WebApi_Livraria.Models;
using WebApi_Livraria.Services.Livro;

namespace WebApi_Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();

            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);

            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);

            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO)
        {
            var livros = await _livroInterface.CriarLivro(livroCriacaoDTO);

            return Ok(livros);
        }

        [HttpPost("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDTO livroEdicaoDTO)
        {
            var livros = await _livroInterface.EditarLivro(livroEdicaoDTO);

            return Ok(livros);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livros = await _livroInterface.ExcluirLivro(idLivro);

            return Ok(livros);
        }
    }
}