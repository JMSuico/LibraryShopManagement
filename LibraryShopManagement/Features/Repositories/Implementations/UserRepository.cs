using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Enums;
using BlazorApp.Features.Data.Models;
using BlazorApp.Features.Repositories.Interfaces;

namespace BlazorApp.Features.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new()
    {
        new User { Id = 1, Username = "admin", Password = "admin123", Role = UserRole.Admin },
        new User { Id = 2, Username = "staff01", Password = "staff123", Role = UserRole.Staff },
        new User { Id = 3, Username = "reader01", Password = "reader123", Role = UserRole.Customer }
    };

    public Task<List<User>> GetAllAsync()
    {
        return Task.FromResult(Users.OrderBy(x => x.Id).ToList());
    }

    public Task<User> AddAsync(User user)
    {
        var nextId = Users.Count == 0 ? 1 : Users.Max(x => x.Id) + 1;
        user.Id = nextId;
        Users.Add(new User
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Role = user.Role
        });
        return Task.FromResult(user);
    }

    public Task UpdateAsync(User user)
    {
        var existing = Users.FirstOrDefault(x => x.Id == user.Id);
        if (existing is not null)
        {
            existing.Username = user.Username;
            existing.Password = user.Password;
            existing.Role = user.Role;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var existing = Users.FirstOrDefault(x => x.Id == id);
        if (existing is not null)
        {
            Users.Remove(existing);
        }
        return Task.CompletedTask;
    }
}
