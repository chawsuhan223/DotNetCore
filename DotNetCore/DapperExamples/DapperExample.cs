using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections;
using DotNetCore.Models;
using System.Reflection.Metadata;

namespace DotNetCore.DapperExamples
{
    public class DapperExample
    {
        //need to create object
        //DTO => Data Transfer Object
        private readonly SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder()//Start Connectiion
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "sasa@123"
        };
        public void Read()//Start Read
        {
            
            //data set (2 Table / 3 Table)/ data table/ data row / data column
            string GetData = @"SELECT  [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
             FROM [TestDb].[dbo].[Tbl_Blog]";// stored data from DataBase

            using IDbConnection OpenDb = new SqlConnection(Connection.ConnectionString); //Open (SQLConnection => BlogId,BlogTitle,BlogAuthor,BlogContent)  Use Connection
            //OpenDb.Query(GetData); 
            List<BlogModel> lst= OpenDb. Query <BlogModel>(GetData).ToList();

            
            foreach(BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);



            }
            Console.WriteLine();
        }//End Read
        public void Edit(int id)//Start Edit
        {
            //data set (2 Table / 3 Table)/ data table/ data row / data column
            string GetData = @"SELECT  [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
             FROM[dbo].[Tbl_Blog] Where BlogId = @BlogID";// stored data from DataBase

            using IDbConnection DB = new SqlConnection(Connection.ConnectionString);
            var item = DB.Query<BlogModel>(GetData,new { BlogID=id }).FirstOrDefault();
            //if (item == null)
            if (item is null)

            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);


        }//End Edit
        public void Create(string title, string Author, string Content)//Start Create
        {
            
            string GetData = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
           @BlogAuthor
           ,@BlogContent)";// stored data from DataBase

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = Author,
                BlogContent = Content
            };

            using IDbConnection DB = new SqlConnection(Connection.ConnectionString);

            int result = DB.Execute(GetData, blog);


            string message = result > 0 ? "Creating Successful" : "Creating failed";
            Console.WriteLine(message);
        }//End Create
        public void Update(int id, string title, string Author, string Content)//Start Update
        {
         
            string GetData = @"UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle
         ,[BlogAuthor] = @BlogAuthor
        ,[BlogContent] = @BlogContent
    WHERE BlogId= @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId=id,
                BlogTitle = title,
                BlogAuthor = Author,
                BlogContent = Content
            };

            using IDbConnection DB = new SqlConnection(Connection.ConnectionString);

            int result = DB.Execute(GetData, blog);



            string message = result > 0 ? "Updating Successful" : "Updating failed";
            Console.WriteLine(message);
        }//End Update
        public void Delete(int id)//Start Delete
        {
            //data set (2 Table / 3 Table)/ data table/ data row / data column
            string GetData = @"Delete From [dbo].[Tbl_Blog] Where BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id
            };

            using IDbConnection DB = new SqlConnection(Connection.ConnectionString);

            int result = DB.Execute(GetData,blog);

            string message = result > 0 ? "Deleting Successful" : "Deleting failed";
            Console.WriteLine(message);
        }//End Delete

    }
}
