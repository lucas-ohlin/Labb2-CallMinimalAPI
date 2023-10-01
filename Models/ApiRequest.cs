using static Labb2_CallMinimalAPI.Utility.StaticDetails;

namespace Labb2_CallMinimalAPI.Models {
    public class ApiRequest {
        public APIType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
