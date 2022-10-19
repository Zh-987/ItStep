using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger/*, AppDBContext dbContext*/)
        {
            _logger = logger;
            /*_dbContext = dbContext;*/
        }

        public string RetString()
        {
            return "Hello world";
        }

        public IActionResult GetView()
        {
            return View();
        }
             
        public IActionResult RetHTMl()
        {
            /* var nameha = "<h1>Hello World!!!</h1>";*/
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><body>Hello World</body></html>"
            };
        }

        public IActionResult RetEmpty()
        {
            return new EmptyResult(); //Empty file with Status code 200
        }

        public IActionResult RetEmptyContent()
        {
            return new NoContentResult();  //Empty file with Status code 204
        }
        /* public IActionResult RetFile()
         {
             return new FileResult();  //Empty file with Status code 204 
         }

         * FileContentResult();
         * VirtualFileResult();
         * FileStreamResult();
         * ObjectResult();
         */

        public IActionResult RetObject()
        {
            return new ObjectResult(new Cherepaha("Morskoi",100, "ssss", "ssss"));  //Empty file with Status code 204  JsonResult(); Ok();
        }

        record class Cherepaha(string Name, int Age, string Oruzhie, string Enemy);

        public IActionResult GetContent()
        {
            return Content("Hello world again!!!");
        }

        //JsonResult();

        public JsonResult GetJson()
        {
            return Json("Leonardo");
        }

        public IActionResult GetJsonViaAction()
        {
            var ninja = new Cherepaha("Rafael",20,"Vilka","Shreder") ;

            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            return Json(ninja, jsonOptions);
        }

        public IActionResult GetStatus()
        {
            return StatusCode(400);
        }

        public IActionResult GetStatusError()
        {
            return NotFound("Resource not found");
            /* return NotFoundResult();*/
        }

        record class Error(string ErrorName);

        public IActionResult GetAuthorize(int age) 
        {
            if(age < 16)
            {
                /*return Unauthorized();*/ // Access denied oraccess is not available
                return Unauthorized(new Error("Access denied"));
            }
            else
            {
                return Content("Yes you can watch this film, Access is available");
            }
        }

        public IActionResult GetBadRequest(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name is NULL");
            }
            return Content($"Name: {name}");
        }

        public IActionResult GetOk()
        {
            return Ok("Sending to Front XD");
        }

        public IActionResult GetFile()
        {
            string FilePath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory , "Files/Rango.txt");

            string TypeFile = "text/plain";

            string FileName = "Rango.txt";

            return PhysicalFile(FilePath, TypeFile, FileName);  /*
                                                                 * FileContentResult();
                                                                 * VirtualFileResult();
                                                                 * FileStreamResult();
                                                                 */
        }


        public IActionResult GetRedirect() => Content("GetFile");

        public IActionResult GetRedirect2()
        {
            return Redirect("Test/GetFile");
        }

        public IActionResult GetRedirect3()
        {
            return Redirect("www.ItStep.com");
        }

        public IActionResult GetRedirect4()
        {
            return RedirectToAction("Index","Home");
        }

    }
}
