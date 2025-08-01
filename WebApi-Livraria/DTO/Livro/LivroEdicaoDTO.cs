using WebApi_Livraria.DTO.Vinculo;

namespace WebApi_Livraria.DTO.Livro
{
    public class LivroEdicaoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorVinculoDTO Autor { get; set; }
    }
}
