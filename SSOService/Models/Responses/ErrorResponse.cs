namespace SSOService.Models.Responses
{
    /// <summary>
    /// Represents an error response with a message, status code, and optional details.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The HTTP status code associated with the error.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// A message describing the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Additional details about the error, if available.
        /// </summary>
        public string? Details { get; set; }
    }
}
