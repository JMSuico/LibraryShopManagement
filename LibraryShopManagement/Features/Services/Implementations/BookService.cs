using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Models;
using BlazorApp.Features.Repositories.Implementations;
using BlazorApp.Features.Repositories.Interfaces;
using BlazorApp.Features.Services.Interfaces;

namespace BlazorApp.Features.Services.Implementations;

public class BookService : IBookService
{
    private readonly IBookRepository bookRepository;

    public BookService()
    {
        bookRepository = new BookRepository();
    }

    public Task<List<Book>> GetBooksAsync() => bookRepository.GetAllAsync();

    public Task<Book> CreateBookAsync(Book book) => bookRepository.AddAsync(book);

    public Task UpdateBookAsync(Book book) => bookRepository.UpdateAsync(book);

    public Task DeleteBookAsync(int id) => bookRepository.DeleteAsync(id);
}
