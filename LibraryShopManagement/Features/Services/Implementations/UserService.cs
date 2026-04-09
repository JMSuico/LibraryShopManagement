using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Models;
using BlazorApp.Features.Repositories.Implementations;
using BlazorApp.Features.Repositories.Interfaces;
using BlazorApp.Features.Services.Interfaces;

namespace BlazorApp.Features.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService()
    {
        userRepository = new UserRepository();
    }

    public Task<List<User>> GetUsersAsync() => userRepository.GetAllAsync();

    public Task<User> CreateUserAsync(User user) => userRepository.AddAsync(user);

    public Task UpdateUserAsync(User user) => userRepository.UpdateAsync(user);

    public Task DeleteUserAsync(int id) => userRepository.DeleteAsync(id);
}
