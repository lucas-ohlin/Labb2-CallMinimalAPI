namespace Labb2_CallMinimalAPI.Models {
    public class ErrorViewModel {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}