using Labb1_MinimalAPI.Models.DTOs;
using Labb1_MinimalAPI.Models;

namespace Labb2_CallMinimalAPI.Services {
    public interface IBookService {

        Task<T> GetAllBooks<T>();
        Task<T> GetBookById<T>(Guid id);
        Task<T> GetBooksByTitle<T>(string title);
        Task<T> CreateBookAsync<T>(BookCreateDTO book);
        Task<T> UpdateBookAsync<T>(BookUpdateDTO book);
        Task<T> DeleteBookAsync<T>(Guid id);

    }
}
