using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodEF;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    public class FoodController : ApiController
    {
        FoodDAO fd = new FoodDAO();

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            List<Food> results = fd.GetAll();
            if (results.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            Food f = fd.GetFoodById(id);
            if (f == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);
                return Request.CreateResponse(HttpStatusCode.OK, f);
         
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Food f)
        {
            if (f == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
            {
                fd.AddFood(f);
                return Request.CreateResponse(HttpStatusCode.Created, f);
            }
            
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(Food f)
        {
            if (f == null)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
            {
                fd.UpdateFood(f);
                return Request.CreateResponse(HttpStatusCode.OK, f);
            }
            
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            if (id == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
            {
                fd.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
        }

        //GetByName api/food/ByName
        [Route("api/food/ByName/{name}")]
        [HttpGet]
        public HttpResponseMessage GetByName (string name)
        {
           List<Food> foods =  fd.GetByName(name);
            if (foods.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }

        //BiggetThanCalories api/food/BiggerThan
        [Route("api/food/BiggerThan/{calories}")]
        [HttpGet]
        public HttpResponseMessage BiggerThan (int calories)
        {
            List<Food> foods = fd.BiggetThanCalories(calories);
            if (foods.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }

        //Search api/food/search
        [Route("api/food/search")]
        [HttpGet]
        public HttpResponseMessage Search (string name ="", int grade = 0, int calories = 0, int maxCalories = int.MaxValue)
        {
            List<Food> foods = fd.GetAllBySearch(maxCalories, name, grade, calories);
            if (foods.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NoContent);
            return Request.CreateResponse(HttpStatusCode.OK, foods);
        }
    }
}