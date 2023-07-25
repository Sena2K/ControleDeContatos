using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel BuscarPorID(int id);
        List<ContatoModel> GetContatos();
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar (ContatoModel contato);

        bool Apagar(int id);
      
    }
}
