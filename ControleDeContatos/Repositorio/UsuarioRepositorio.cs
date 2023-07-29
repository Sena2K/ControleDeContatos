using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Data;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public UsuarioModel BuscarPorID(int id) 
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> GetContatos()
        {
            return _context.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //INSERÇÃO NO BD
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorID(usuario.Id);
            if (usuarioDB == null) throw new System.Exception("Erro na att do usuario");
                
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;
            
            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorID(id);
            if (usuarioDB == null) throw new System.Exception("Erro na att do usuario");
            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();
            return true;
        }

   
    }
}
