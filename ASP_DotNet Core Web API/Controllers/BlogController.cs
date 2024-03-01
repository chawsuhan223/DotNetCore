using ASP_DotNet_Core_Web_API.EFCoreExamples;
using ASP_DotNet_Core_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DotNet_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        //get    => read
        //post   => create
        //put    => update
        //delete => delete
        //get    => edit
        private readonly AppDbContext _db;
        public BlogController()//build constructor
        {
            _db = new AppDbContext();
        }


        [HttpGet]//Get Method for Read
        public IActionResult GetBlogs()//public void Read()
        {
            //_db.Blogs.ToList();
            List<BlogModel> Lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();//ascending descending
            return Ok(Lst);//auto convert json format

        }//Read

        [HttpGet("{id}")]//Get Method 
        public IActionResult GetBlog(int id)//public void Read()
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return NotFound();//404 Not Found
            }
            return Ok(item);

        }

        [HttpPost]//Create
        public IActionResult CreateBlogs(BlogModel blog)//public void Create()
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Created successful" : "Clean Blogs";
            return Ok(message);

        }//Create

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id,BlogModel blog)//public void Update()
        {

            AppDbContext db = new AppDbContext();
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return NotFound();//404 Not Found
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _db.SaveChanges();//Execute

            string message = result > 0 ? "Updating Successful" : "Updating failed";
            //Console.WriteLine(message);
            return Ok(message);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlogs(int id)//public void Delete()
        {

            AppDbContext db = new AppDbContext();
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);//one
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                
            }
            _db.Blogs.Remove(item);

            int result = _db.SaveChanges();//Execute

            string message = result > 0 ? "Deleting Successful" : "Deleting failed";
            //Console.WriteLine(message);
            return NotFound(message);//404 Not Found
        }
    }
}
