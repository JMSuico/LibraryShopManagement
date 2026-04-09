using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Models;

namespace BlazorApp.Features.Repositories.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book> AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(int id);
}
