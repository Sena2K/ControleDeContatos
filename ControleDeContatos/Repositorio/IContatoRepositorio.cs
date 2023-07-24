using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {

        List<ContatoModel> GetContatos();
         ContatoModel Adicionar(ContatoModel contato);
    }
}
