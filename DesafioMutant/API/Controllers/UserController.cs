using System;
using System.Net.Http;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly string requestUri = "https://jsonplaceholder.typicode.com/users";
        private readonly HttpClient _clientFactory;
        private readonly IUserBO _userBO;

        public UserController(IHttpClientFactory clientFactory, IUserBO userBO)
        {
            _clientFactory = clientFactory.CreateClient();
            _userBO = userBO;
        }
        [HttpGet("baixarDados")]
        [SwaggerOperation(
        Summary = "Método BaixarDados",
        Description = "Consulta API e retorna json com Usuarios</br>"   
       )]
        public async Task<IActionResult> BaixarDados()
        {
            Log.Information("Método BaixarDados");
            try
            {
                var result = await _clientFactory.GetAsync(requestUri);
                result.EnsureSuccessStatusCode();
                var jsonResult = await result.Content.ReadAsStringAsync();
                Log.Information("Método BaixarDados Executado");

                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                GravaNoLog("BaixarDados",ex);
                return Problem("Método BaixarDados apresentou Erro! Verificar Logs");
            }
            
        }

        [HttpGet("salvarDados")]
        [SwaggerOperation(
        Summary = "Método SalvarDados",
        Description = "Consulta API e salva o retorno na base de dados</br>"
       )]
        public async Task<IActionResult> SalvarDados()
        {
            try
            {
                var result = await _clientFactory.GetAsync(requestUri);
                result.EnsureSuccessStatusCode();
                var resultContent = await result.Content.ReadAsStringAsync();
                await _userBO.Salvar(resultContent);
                Log.Information("Método SalvarDados Executado");
                return Ok();
            }
            catch (Exception ex)
            {
                GravaNoLog("SalvarDados", ex);
                return Problem(ex.InnerException.Message);
            }
        }
        private static void GravaNoLog(string Metodo, Exception ex)
        {
            Log.Error($"Erro No Método: {Metodo} " +
                $"Erro: {ex.InnerException.Message} " +
                $"StackTrace: {ex.StackTrace}");
        }
    }
}
