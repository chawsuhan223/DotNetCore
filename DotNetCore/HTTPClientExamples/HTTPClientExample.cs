﻿using DotNetCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore.HTTP_Client_Examples
{
    public class HTTPClientExample
    {
        public async Task Run()
        {
            await Read();
        }
       // private string jsonStr();
        
            private async Task Read()
            {
                HttpClient client = new HttpClient();
                //var response= await client.GetAsync("https://localhost:7283/api/Blog");//Task = Not do//await = do
                HttpResponseMessage response = await client.GetAsync("https://localhost:7283/api/Blog");//Task = Not do//await = do
                if (response.IsSuccessStatusCode)
                {
                    string jsonStr = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonStr);
                //JsonConvert.SerializeObject()//C# object to JSON
                //JsonConvert.DeserializeObject();//JSON to C# object
                //JsonConvert.SerializeObject();
                //get jsonStr to convert C# 

                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (BlogModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }

        }
        private async Task ReadJsonPlaceholder()
        {
            HttpClient client = new HttpClient();
            //var response= await client.GetAsync("https://localhost:7283/api/Blog");//Task = Not do//await = do
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");//Task = Not do//await = do
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                //JsonConvert.SerializeObject()//C# object to JSON
                //JsonConvert.DeserializeObject();//JSON to C# object
                //JsonConvert.SerializeObject();
                //get jsonStr to convert C# 

                List<jSonPlaceholder> lst = JsonConvert.DeserializeObject<List<jSonPlaceholder>>(jsonStr)!;
                foreach (jSonPlaceholder item in lst)
                {
                    Console.WriteLine(item.blogId);
                    Console.WriteLine(item.blogTitle);
                    Console.WriteLine(item.blogAuthor);
                    Console.WriteLine(item.blogContent);
                }
            }

        }
    }
            
}
//https://jsonplaceholder.typicode.com/
