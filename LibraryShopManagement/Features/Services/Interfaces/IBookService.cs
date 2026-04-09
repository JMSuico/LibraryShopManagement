using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Models;

namespace BlazorApp.Features.Services.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetBooksAsync();
    Task<Book> CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
}
