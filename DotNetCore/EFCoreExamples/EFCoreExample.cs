using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DotNetCore.Models;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace DotNetCore.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()//Start Read
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();
            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }

        }//End Read
        public void Edit(int id) // Start Edit
        {
            AppDbContext db = new AppDbContext();//Create
            //BlogModel item = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }// End Edit

        public void Create(string title,string author, string conent)//Start Create
        {
            BlogModel blog = new BlogModel()//Create Boject 
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = conent
            };
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();//Execute

            string message = result > 0 ? "Creating Successful" : "Creating failed";
            Console.WriteLine(message);
        }// End Create
        public void Update(int id,string title,string Author,string Content)//Start Update
        {
          

            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = Author;
            item.BlogContent = Content;

            int result = db.SaveChanges();//Execute

            string message = result > 0 ? "Updating Successful" : "Updating failed";
            Console.WriteLine(message);
        }//End Update
        public void Delete(int id)//Start Delete
        {


            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Blogs.Remove(item);

            int result = db.SaveChanges();//Execute

            string message = result > 0 ? "Deleting Successful" : "Deleting failed";
            Console.WriteLine(message);
        }//End Delete
    }
}
