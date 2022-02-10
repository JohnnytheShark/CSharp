using projects.Models; // Usually all of these Visual Studio adds in for you
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;


namespace projects.Controllers{
    [ApiController]
    public class ControllerExample : ControllerBase
    {
        private readonly WebsiteContext _db;
        public ControllerExample(WebsiteContext db){
            _db = db;
        }
        // This is whatever you called your db context file. For simplicity I'm calling  it WebsiteContext

        [HttpGet]
        [Route("[controller]")] // When calling the API you literally can just specify the name of the controller and on the frontend (REACT)
        // You would use 
        public IEnumerable<Class> Get()=> _db.table.ToList(); // Make sure to specify the table name.


        [HttpPost]
        [Route("[controller]")]
        public IEnumerable<Class> insertIntoTable(object formData)
        {
            if (formData != null){
                dynamic result = JObject.Parse(formData.ToString()); // The only time this will ever be needed is if you have to map out the fields specifically if they don't have the same field names to the models.
                var items = result.SelectToken("Token"); // <JPATH is used to search through a JSON object. Google JPAth Syntax its basically the query language something to the sort of XML querying
                List<Class2> namehere = new List<Class2>();
                foreach (JObject item in items){
                    Class2 variablenamehere = new Class2(){
                        Class2Variable = item.SelectToken("TokenSomething").ToString()
                        //Repeat process for variabls
                    };
                    namehere.Add(variablenamehere);
                }
                    Class test = new Class(){
                        token = result.Token,
                        //Map the rest below
                        tokens = namehere
                    };
                    _db.Add(test);
                    _db.SaveChanges();
                    yield return test;
            }
            
        yield return null;



        }



    }

}