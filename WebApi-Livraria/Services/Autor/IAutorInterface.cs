﻿using WebApi_Livraria.DTO.Autor;
using WebApi_Livraria.Models;

namespace WebApi_Livraria.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAtor);
    }
}