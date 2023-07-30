using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsarioRepositorio
    {

        UsuarioModel BuscarLogin(string login);
        
        UsuarioModel BuscarPorID(int id);
        List<UsuarioModel> GetContatos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);

    }
}
