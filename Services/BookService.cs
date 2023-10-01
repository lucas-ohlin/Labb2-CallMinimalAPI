using Labb1_MinimalAPI.Models.DTOs;
using Labb1_MinimalAPI.Models;
using static Labb2_CallMinimalAPI.Utility.StaticDetails;
using Labb2_CallMinimalAPI.Utility;

namespace Labb2_CallMinimalAPI.Services {
    public class BookService : BaseService, IBookService {

        private readonly IHttpClientFactory _clientFactory;

        public BookService(IHttpClientFactory httpClient) : base(httpClient) {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateBookAsync<T>(BookCreateDTO book) {
            return await this.SendAsync<T>(new Models.ApiRequest {
                ApiType = APIType.POST,
                Data = book,
                Url = BookAPIBase + "/api/books/",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(Guid id) {
            return await this.SendAsync<T>(new Models.ApiRequest {
                ApiType = APIType.DELETE,
                Url = BookAPIBase + "/api/books/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllBooks<T>() {
            return await this.SendAsync<T>(new Models.ApiRequest {
                ApiType = APIType.GET,
                Url = BookAPIBase + "/api/books/",
                AccessToken = ""
            });
        }

        public async Task<T> GetBookById<T>(Guid id) {
            return await this.SendAsync<T>(new Models.ApiRequest {
                ApiType = APIType.GET,
                Url = BookAPIBase + "/api/books/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetBooksByTitle<T>(string title) {
            return await this.SendAsync<T>(new Models.ApiRequest {
                ApiType = APIType.GET,
                Url = BookAPIBase + "/api/books/title/" + title,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateBookAsync<T>(BookUpdateDTO book) {
            return await this.SendAsync<T>(new Models.ApiRequest {
                ApiType = APIType.PUT,
                Data = book,
                Url = BookAPIBase + "/api/books/",
                AccessToken = ""
            });
        }

    }
}
