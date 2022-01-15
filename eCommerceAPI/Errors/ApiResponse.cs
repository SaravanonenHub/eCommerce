using System;

namespace eCommerceAPI.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageforStatusCode(statusCode);
        }

      

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageforStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource, not found",
                500 => "Server error",
                _=> null
            };
        }
    }
}