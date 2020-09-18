using System.Threading.Tasks;

namespace Business
{
    public interface IUserBO
    {
        Task Salvar(string jsonUsers); 
    }
}
