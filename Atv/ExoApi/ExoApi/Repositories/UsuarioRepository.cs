using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly SqlContext _context;

        public UsuarioRepository(SqlContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Users usuario)
        {
            Users usuarioEncontrado = _context.Users.Find(id);
            if (usuarioEncontrado == null)
            {
                return;
            }

            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.Senha = usuario.Senha;
            _context.Users.Update(usuarioEncontrado);
            _context.SaveChanges();
        }

        public Users BuscarPorId(int id)
        {
            return _context.Users.Find(id);
        }

        public void Cadastrar(Users usuario)
        {
            _context.Users.Add(usuario);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();
        }

        public List<Users> Listar()
        {
            return _context.Users.ToList();
        }

        public Users Login(string email, string senha)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
