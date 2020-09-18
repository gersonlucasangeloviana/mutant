using Domain.Model;
using Repository.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DesafioMutantDbContext _context;
        public UserRepository(DesafioMutantDbContext context)
        {
            _context = context;
        }
        public async Task Cadastrar(List<User> entity)
        {
            await _context.Users.AddRangeAsync(entity);
            _context.SaveChanges();
        }
    }
}
