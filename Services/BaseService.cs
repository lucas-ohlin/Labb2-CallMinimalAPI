using Labb1_MinimalAPI.Models;
using Labb2_CallMinimalAPI.Models;
using Labb2_CallMinimalAPI.Utility;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Labb2_CallMinimalAPI.Services {
    public class BaseService : IBaseService {

        public ResponseDTO responseModel { get; set; }
        public IHttpClientFactory _httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient) {
            this._httpClient = httpClient;
            this.responseModel = new ResponseDTO();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest) {
            try {

                var client = _httpClient.CreateClient("BookAPI");

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);

                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null) {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                       Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResp = null;

                switch (apiRequest.ApiType) {
                    case StaticDetails.APIType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                }

                apiResp = await client.SendAsync(message);
                var apiContent = await apiResp.Content.ReadAsStringAsync();
                var apiResponsDTO = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponsDTO;

            } catch (Exception e) {
                var dto = new ResponseDTO {
                    DisplayMessage = "Error",
                    ErrorMesages = new List<string>() { Convert.ToString(e.Message) },
                    IsSuccess = false,
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponsDTO = JsonConvert.DeserializeObject<T>(res);

                return apiResponsDTO;
            }
        }

        public void Dispose() {
            //Garbage collection
            GC.SuppressFinalize(true);

        }
    }
}
