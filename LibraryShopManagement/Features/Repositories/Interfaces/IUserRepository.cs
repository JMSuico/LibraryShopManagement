using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Models;

namespace BlazorApp.Features.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}
