using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using ASP_DotNet_Core_Web_API.Models;

namespace ASP_DotNet_Core_Web_API.EFCoreExamples
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder()//Start Connectiion
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate=true,
            };
            optionsBuilder.UseSqlServer(Connection.ConnectionString);
            
        }
        public DbSet<BlogModel> Blogs { get; set; }//Create mapping
    }
}
