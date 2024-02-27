// See https://aka.ms/new-console-template for more information
using DotNetCore.AdoDotNetExamples;
using DotNetCore.DapperExamples;
using System.Data;
using System.Data.SqlClient;

/*Console.WriteLine("Hello, World!");

//F5 Run
//Ctrl+k+c
//Ctrl+k+u
//Console.ReadLine();
//Ctrl + .
//Break point  F9
//Shift + F5  => stop
//F10 step by step run
//F11 => skip

#region Read
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";//Server name
sqlConnectionStringBuilder.InitialCatalog = "TestDb";//Database
sqlConnectionStringBuilder.UserID = "sa";//UserName
sqlConnectionStringBuilder.Password = "sasa@123";//Password

string query = "select * from Tbl_Blog";//Table
SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
sqlConnection.Open();

sqlConnection.Close();
SqlCommand cmd = new SqlCommand(query, sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
#endregion


SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();//Start Connectiion
Connection.DataSource = ".";//Server name
Connection.InitialCatalog = "TestDb";//Database
Connection.UserID = "sa";//UserName
Connection.Password = "sasa@123";//Password

Console.WriteLine("Connection String.." + Connection.ConnectionString);//ConnectionString => DataSource/InitialCatalog/UserID/Password

SqlConnection SQLConnection = new SqlConnection(Connection.ConnectionString);//Use Connection

Console.WriteLine("Connection Opening...");
SQLConnection.Open();
Console.WriteLine("Connection Opened...");

//data set (2 Table / 3 Table)/ data table/ data row / data column
string GetData = @"SELECT  [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [TestDb].[dbo].[Tbl_Blog]";// stored data from DataBase

SqlCommand OpenDb = new SqlCommand(GetData, SQLConnection); //Open (SQLConnection => BlogId,BlogTitle,BlogAuthor,BlogContent)  Use Connection
SqlDataAdapter StoreDb = new SqlDataAdapter(OpenDb);//Get Data From OpenDb
DataTable NewDt = new DataTable();//Create New Data Table
StoreDb.Fill(NewDt);


Console.WriteLine("Connection Closing...");
SQLConnection.Close();
Console.WriteLine("Connection Closed...");

foreach (DataRow DR in NewDt.Rows)
{
    Console.WriteLine("ID .." + DR["BlogId"]);
    Console.WriteLine("Title .." + DR["BlogTitle"]);
    Console.WriteLine("Author .." + DR["BlogAuthor"]);
    Console.WriteLine("Content .." + DR["BlogContent"]);


}
*/

//Testing For AdoDotNet
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(id:1);
//adoDotNetExample.Edit(id:13);
//adoDotNetExample.Create("Test Title","Test Author","Test Content");
//adoDotNetExample.Update(12,"Test Title2 ","Test Author2", "Test Content2");
//adoDotNetExample.Delete(11);

//Testing For Dapper
DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(id: 1);
//dapperExample.Edit(id: 13);
//dapperExample.Create("Test Title3","Test Author3","Test Content3");
//dapperExample.Update(5,"Test Title5 ","Test Author5", "Test Content5");
dapperExample.Delete(13);





Console.ReadKey();