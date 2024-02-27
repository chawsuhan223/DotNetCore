//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DotNetCore.DapperExamples
//{
//    public class DapperExample
//    {
//        //need to create object
//        //DTO => Data Transfer Object
//        public void Read()//Start Read
//        {
//            SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();//Start Connectiion
//            Connection.DataSource = ".";//Server name
//            Connection.InitialCatalog = "TestDb";//Database
//            Connection.UserID = "sa";//UserName
//            Connection.Password = "sasa@123";//Password

//            Console.WriteLine("Connection String.." + Connection.ConnectionString);//ConnectionString => DataSource/InitialCatalog/UserID/Password

//            SqlConnection SQLConnection = new SqlConnection(Connection.ConnectionString);//Use Connection

//            Console.WriteLine("Connection Opening...");
//            SQLConnection.Open();
//            Console.WriteLine("Connection Opened...");

//            //data set (2 Table / 3 Table)/ data table/ data row / data column
//            string GetData = @"SELECT  [BlogId]
//              ,[BlogTitle]
//              ,[BlogAuthor]
//              ,[BlogContent]
//             FROM [TestDb].[dbo].[Tbl_Blog]";// stored data from DataBase

//            SqlCommand OpenDb = new SqlCommand(GetData, SQLConnection); //Open (SQLConnection => BlogId,BlogTitle,BlogAuthor,BlogContent)  Use Connection
//            SqlDataAdapter StoreDb = new SqlDataAdapter(OpenDb);//Get Data From OpenDb
//            DataTable NewDt = new DataTable();//Create New Data Table
//            StoreDb.Fill(NewDt);


//            Console.WriteLine("Connection Closing...");
//            SQLConnection.Close();
//            Console.WriteLine("Connection Closed...");

//            foreach (DataRow DR in NewDt.Rows)
//            {
//                Console.WriteLine("ID .." + DR["BlogId"]);
//                Console.WriteLine("Title .." + DR["BlogTitle"]);
//                Console.WriteLine("Author .." + DR["BlogAuthor"]);
//                Console.WriteLine("Content .." + DR["BlogContent"]);


//            }
//            Console.WriteLine();
//        }//End Read
//        public void Edit(int id)//Start Edit
//        {
//            SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();//Start Connectiion
//            Connection.DataSource = ".";//Server name
//            Connection.InitialCatalog = "TestDb";//Database
//            Connection.UserID = "sa";//UserName
//            Connection.Password = "sasa@123";//Password

//            Console.WriteLine("Connection String.." + Connection.ConnectionString);//ConnectionString => DataSource/InitialCatalog/UserID/Password

//            SqlConnection SQLConnection = new SqlConnection(Connection.ConnectionString);//Use Connection

//            SQLConnection.Open();

//            //data set (2 Table / 3 Table)/ data table/ data row / data column
//            string GetData = @"SELECT  [BlogId]
//              ,[BlogTitle]
//              ,[BlogAuthor]
//              ,[BlogContent]
//             FROM[dbo].[Tbl_Blog] Where BlogId = @BlogID";// stored data from DataBase

//            SqlCommand OpenDb = new SqlCommand(GetData, SQLConnection); //Open (SQLConnection => BlogId,BlogTitle,BlogAuthor,BlogContent)  Use Connection
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogId", id);
//            SqlDataAdapter StoreDb1 = new SqlDataAdapter(OpenDb);//Get Data From OpenDb

//            DataTable NewDt1 = new DataTable();//Create New Data Table
//            StoreDb1.Fill(NewDt1);


//            SQLConnection.Close();

//            if (NewDt1.Rows.Count == 0)
//            {
//                Console.WriteLine("No Data Found");
//                return;
//            }
//            DataRow DR = NewDt1.Rows[0];
//            Console.WriteLine("ID .." + DR["BlogId"]);
//            Console.WriteLine("Title .." + DR["BlogTitle"]);
//            Console.WriteLine("Author .." + DR["BlogAuthor"]);
//            Console.WriteLine("Content .." + DR["BlogContent"]);

//        }//End Edit
//        public void Create(string title, string Author, string Content)//Start Create
//        {
//            SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();//Start Connectiion
//            Connection.DataSource = ".";//Server name
//            Connection.InitialCatalog = "TestDb";//Database
//            Connection.UserID = "sa";//UserName
//            Connection.Password = "sasa@123";//Password

//            Console.WriteLine("Connection String.." + Connection.ConnectionString);//ConnectionString => DataSource/InitialCatalog/UserID/Password

//            SqlConnection SQLConnection = new SqlConnection(Connection.ConnectionString);//Use Connection

//            SQLConnection.Open();

//            //data set (2 Table / 3 Table)/ data table/ data row / data column
//            string GetData = @"INSERT INTO [dbo].[Tbl_Blog]
//           ([BlogTitle]
//           ,[BlogAuthor]
//           ,[BlogContent])
//     VALUES
//           (@BlogTitle,
//           @BlogAuthor
//           ,@BlogContent)";// stored data from DataBase

//            SqlCommand OpenDb = new SqlCommand(GetData, SQLConnection); //Open (SQLConnection => BlogId,BlogTitle,BlogAuthor,BlogContent)  Use Connection
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogTitle", title);
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogAuthor", Author);
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogContent", Content);

//            int result = OpenDb.ExecuteNonQuery();

//            SQLConnection.Close();

//            string message = result > 0 ? "Saving Successful" : "Saving failed";
//            Console.WriteLine(message);
//        }//End Create
//        public void Update(int id, string title, string Author, string Content)//Start Update
//        {
//            SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();//Start Connectiion
//            Connection.DataSource = ".";//Server name
//            Connection.InitialCatalog = "TestDb";//Database
//            Connection.UserID = "sa";//UserName
//            Connection.Password = "sasa@123";//Password

//            Console.WriteLine("Connection String.." + Connection.ConnectionString);//ConnectionString => DataSource/InitialCatalog/UserID/Password

//            SqlConnection SQLConnection = new SqlConnection(Connection.ConnectionString);//Use Connection

//            SQLConnection.Open();

//            //data set (2 Table / 3 Table)/ data table/ data row / data column
//            string GetData = @"UPDATE [dbo].[Tbl_Blog]
//        SET [BlogTitle] = @BlogTitle
//         ,[BlogAuthor] = @BlogAuthor
//        ,[BlogContent] = @BlogContent
//    WHERE BlogId= @BlogId";

//            SqlCommand OpenDb = new SqlCommand(GetData, SQLConnection); //Open (SQLConnection => BlogId,BlogTitle,BlogAuthor,BlogContent)  Use Connection
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogId", id);
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogTitle", title);
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogAuthor", Author);
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogContent", Content);

//            int result = OpenDb.ExecuteNonQuery();

//            SQLConnection.Close();

//            string message = result > 0 ? "Updating Successful" : "Updating failed";
//            Console.WriteLine(message);
//        }//End Update

//        public void Delete(int id)//Start Delete
//        {
//            SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();//Start Connectiion
//            Connection.DataSource = ".";//Server name
//            Connection.InitialCatalog = "TestDb";//Database
//            Connection.UserID = "sa";//UserName
//            Connection.Password = "sasa@123";//Password

//            Console.WriteLine("Connection String.." + Connection.ConnectionString);//ConnectionString => DataSource/InitialCatalog/UserID/Password

//            SqlConnection SQLConnection = new SqlConnection(Connection.ConnectionString);//Use Connection

//            SQLConnection.Open();

//            //data set (2 Table / 3 Table)/ data table/ data row / data column
//            string GetData = @"Delete From [dbo].[Tbl_Blog] Where BlogId = @BlogId";


//            SqlCommand OpenDb = new SqlCommand(GetData, SQLConnection); //Open (SQLConnection => BlogId,BlogTitle,BlogAuthor,BlogContent)  Use Connection
//            OpenDb.Parameters.AddWithValue(parameterName: "@BlogId", id);
//            ;

//            int result = OpenDb.ExecuteNonQuery();

//            SQLConnection.Close();

//            string message = result > 0 ? "Deleting Successful" : "Deleting failed";
//            Console.WriteLine(message);
//        }//End Delete
//    }

//}
//}
