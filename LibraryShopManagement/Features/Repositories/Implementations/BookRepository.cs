using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Models;
using BlazorApp.Features.Repositories.Interfaces;

namespace BlazorApp.Features.Repositories.Implementations;

public class BookRepository : IBookRepository
{
    private static readonly List<Book> Books = new()
    {
        new Book { Id = 1, Title = "The Apricot Shelf", Author = "Mia Carter", Price = 18.99m, Stock = 12 },
        new Book { Id = 2, Title = "Cloud Library", Author = "Noah Wells", Price = 24.50m, Stock = 8 },
        new Book { Id = 3, Title = "Soft Blue Stories", Author = "Ava Reed", Price = 14.75m, Stock = 20 }
    };

    public Task<List<Book>> GetAllAsync()
    {
        return Task.FromResult(Books.OrderBy(x => x.Id).ToList());
    }

    public Task<Book> AddAsync(Book book)
    {
        var nextId = Books.Count == 0 ? 1 : Books.Max(x => x.Id) + 1;
        book.Id = nextId;
        Books.Add(new Book
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            Stock = book.Stock
        });
        return Task.FromResult(book);
    }

    public Task UpdateAsync(Book book)
    {
        var existing = Books.FirstOrDefault(x => x.Id == book.Id);
        if (existing is not null)
        {
            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Price = book.Price;
            existing.Stock = book.Stock;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var existing = Books.FirstOrDefault(x => x.Id == id);
        if (existing is not null)
        {
            Books.Remove(existing);
        }
        return Task.CompletedTask;
    }
}
