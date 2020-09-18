using Business;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Testes
{
    [TestClass]
    public class Tests
    {
       
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }
        private readonly string requestUri = "https://jsonplaceholder.typicode.com/users";
       
        [TestInitialize]
        public void Initialize()
        {
            Services = new ServiceCollection();

            ServiceProvider = Services.BuildServiceProvider();
        }
        [TestMethod]
        public void TesteRegraNegocioUsersSomenteSuites()
        {
            var jsonResult = ConsultaApi();
            var usuarioSalvar = ProcessarRegrasNegocioUsuarios(jsonResult);

            var UsuariosPosuemSuite = true;
                foreach (var user in usuarioSalvar)
                {
                if (!user.address.suite.Contains("Suite"))
                    {
                    UsuariosPosuemSuite = false;
                    return;
                    }
                }
            Assert.IsTrue(UsuariosPosuemSuite, "Usuarios Hospesados em Suítes");
        }

        [TestMethod]
        public void TesteConsultaApi()
        {
            var jsonResult = ConsultaApi();
            Assert.IsTrue(!string.IsNullOrEmpty(jsonResult));
        }

        private string ConsultaApi()
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetAsync(requestUri).GetAwaiter().GetResult();
               return result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
        private IEnumerable<User> ProcessarRegrasNegocioUsuarios(string jsonUsers)
        {
            var users = ConverterJsonParaUsers(jsonUsers);
            var listaParaGravar = new List<User>();

            foreach (var user in users)
            {
                if (user.address.suite.Contains("Suite"))
                {
                    listaParaGravar.Add(user);
                }
            }
            listaParaGravar.OrderBy(x => x.name);
            return listaParaGravar;
        }
        private IEnumerable<User> ConverterJsonParaUsers(string jsonUsers)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(jsonUsers);
        }
    }
}
