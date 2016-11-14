using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudWithASPWebAPIAndAngularJSMVC.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CrudWithASPWebAPIAndAngularJSMVC.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private DemoEntities de = new DemoEntities();

        [HttpGet]
        public HttpResponseMessage findAll()
        {
            var serializedData = JsonConvert.SerializeObject(de.Products.ToList());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializedData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage find(int id)
        {
            var serializedData = JsonConvert.SerializeObject(de.Products.Find(id));
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializedData);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        [HttpPost]
        public void create(Product product)
        {
            de.Products.Add(product);
            de.SaveChanges();
        }

        [HttpPut]
        public void update(Product product)
        {
            de.Entry<Product>(product).State = System.Data.EntityState.Modified;
            de.SaveChanges();
        }

        [HttpDelete]
        [Route("{id}")]
        public void delete(int id)
        {
            de.Products.Remove(de.Products.Find(id));
            de.SaveChanges();
        }
    }
}
