using ElSaiys.DTOs;
using System.Threading.Tasks;

namespace ElSaiys.Repositories
{
    public interface IUserRepository
    {
        Task<UserResult> CarOwner(string slug);
    }
}