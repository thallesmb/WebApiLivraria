using Azure;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using WebApi_Livraria.Data;
using WebApi_Livraria.DTO.Autor;
using WebApi_Livraria.Models;

namespace WebApi_Livraria.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> response = new();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == idAutor);

                if(autor is null)
                {
                    response.Mensagem = "Autor não localizado!";
                    return response;
                }

                response.Mensagem = "Autor encontrado!";
                response.Status = true;
                response.Dados = autor;

                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> response = new();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor )
                    .FirstOrDefaultAsync(livro => livro.Id == idLivro);

                if (livro is null)
                {
                    response.Mensagem = "Nenhum registro localizado!";
                    return response;
                }

                response.Mensagem = "Autor encontrado!";
                response.Status = true;
                response.Dados = livro.Autor;

                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            ResponseModel<List<AutorModel>> response = new();

            try
            {
                AutorModel autor = new()
                {
                    Nome = autorCriacaoDTO.Nome,
                    Sobrenome = autorCriacaoDTO.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Status = true;
                response.Mensagem = "Autor criado com sucesso!";

                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO)
        {
            ResponseModel<List<AutorModel>> response = new();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == autorEdicaoDTO.Id);

                if (autor is null)
                {
                    response.Mensagem = "Nenhum autor localizado!";
                    return response;
                }

                autor.Nome = autorEdicaoDTO.Nome;
                autor.Sobrenome = autorEdicaoDTO.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor editado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAtor)
        {
            ResponseModel<List<AutorModel>> response = new();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == idAtor);

                if(autor is null)
                {
                    response.Mensagem = "Nenhum autor localizado!";
                    return response;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor removido com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> response = new();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                response.Mensagem = "Todos os autores foram coletados!";
                response.Dados = autores;

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