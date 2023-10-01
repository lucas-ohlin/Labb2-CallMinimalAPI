using Labb2_CallMinimalAPI.Models;

namespace Labb2_CallMinimalAPI.Services {
    public interface IBaseService : IDisposable {

        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);

    }
}
