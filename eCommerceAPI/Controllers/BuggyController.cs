using Core.Data;
using eCommerceAPI.Errors;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
             var thing = _context.Products.Find(2);
             if(thing == null)
             {
                 return NotFound(new ApiResponse(404));
             }
             return Ok();
        }
         [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
             var thing = _context.Products.Find(2);
             var thingto = thing.ToString();
             return Ok();
        }
         [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
             
             return BadRequest(new ApiResponse(400));
        }
         [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
             return BadRequest();
        }

    }
}