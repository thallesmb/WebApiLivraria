using Microsoft.EntityFrameworkCore;
using WebApi_Livraria.Data;
using WebApi_Livraria.DTO.Livro;
using WebApi_Livraria.Models;

namespace WebApi_Livraria.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> response = new();

            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livro => livro.Id == idLivro);

                if (livro is null)
                {
                    response.Mensagem = "Livro não localizado!";
                    return response;
                }

                response.Mensagem = "Livro encontrado!";
                response.Dados = livro;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> response = new();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livro => livro.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro is null || livro.Count == 0)
                {
                    response.Mensagem = "Nenhum registro localizado!";
                    return response;
                }

                response.Mensagem = "Livros localizados!";
                response.Status = true;
                response.Dados = livro;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO)
        {
            ResponseModel<List<LivroModel>> response = new();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == livroCriacaoDTO.Autor.Id);

                if(autor is null)
                {
                    response.Mensagem = "Autor não encontrado!";

                    return response;
                }

                LivroModel livro = new()
                {
                    Titulo = livroCriacaoDTO.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                response.Mensagem = "Livro criado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDTO livroEdicaoDTO)
        {
            ResponseModel<List<LivroModel>> response = new();

            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livro => livro.Id == livroEdicaoDTO.Id);

                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == livroEdicaoDTO.Autor.Id);

                if (livro is null)
                {
                    response.Mensagem = "Nenhum livro localizado!";
                    return response;
                }

                if(autor is null)
                {
                    response.Mensagem = "Nenhum autor localizado!";
                    return response;
                }

                livro.Titulo = livroEdicaoDTO.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                response.Mensagem = "Livro editado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> response = new();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livro => livro.Id == idLivro);

                if (livro is null)
                {
                    response.Mensagem = "Nenhum livro localizado!";
                    return response;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                response.Mensagem = "Livro removido com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> response = new();

            try
            {
                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();

                response.Mensagem = "Todos os livros foram coletados!";
                response.Dados = livros;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }
    }
}