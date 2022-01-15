using System.Collections;

namespace eCommerceAPI.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable Errors { get; set; }
    }
}