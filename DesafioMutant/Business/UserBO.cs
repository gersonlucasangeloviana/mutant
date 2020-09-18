using Domain.Model;
using Nest;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBO : IUserBO
    {
        private readonly IUserRepository _repository;

        public UserBO(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task Salvar(string jsonUsers)
        {
            var users = ConverterJsonParaUsers(jsonUsers);
            var listaTratadaParaBase = new List<User>();

            foreach (var user in users)
            {
                if (user.address.suite.Contains("Suite"))
                {
                    listaTratadaParaBase.Add(user);
                }
            }

            listaTratadaParaBase.Sort(delegate (User p1, User p2)
            {
                return p1.name.CompareTo(p2.name);
            });

            await _repository.Cadastrar(listaTratadaParaBase);
        }
        private List<User> ConverterJsonParaUsers(string jsonUsers)
        {
            return JsonConvert.DeserializeObject<List<User>>(jsonUsers);
        }
       
    }
}
