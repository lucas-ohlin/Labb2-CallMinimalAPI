namespace Labb2_CallMinimalAPI.Models {
    public class ResponseDTO {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMesages { get; set; }

    }
}
