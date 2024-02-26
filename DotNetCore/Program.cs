// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//F5 Run
//Ctrl+k+c
//Ctrl+k+u
//Console.ReadLine();
//Ctrl + .
//Break point  F9
//Shift + F5  => stop

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

Console.WriteLine("Connection Closing...");
SQLConnection.Close();
Console.WriteLine("Connection Closed...");

Console.ReadKey();