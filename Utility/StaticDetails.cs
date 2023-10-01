namespace Labb2_CallMinimalAPI.Utility {
    public static class StaticDetails {

        public static string BookAPIBase { get; set; }

        public enum APIType {
            GET,
            POST,
            PUT,
            DELETE
        }

    }
}
