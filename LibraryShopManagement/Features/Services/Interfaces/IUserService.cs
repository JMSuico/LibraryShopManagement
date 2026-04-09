using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Models;

namespace BlazorApp.Features.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}
