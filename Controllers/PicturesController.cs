using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Web.Http.Cors;
using distributed_system_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace distributed_system_web_api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private Db.Db _db;

        public PicturesController()
        {
            _db = new Db.Db();
        }
        
        // GET api/values
        [HttpGet]
        public List<Picture> Get()
        {
            var res = _db.GetAll();
            return res;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Picture Get(string id)
        {
            return _db.Get(new ObjectId(id));         
        }

        // POST api/values
        [HttpPost]
        public ObjectId Post(PictureJson value)
        {
            var picture = new Picture(value.Name, value.File);
            return _db.Add(picture);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

public class PictureJson
{
    public string Name { get; set; }
    public string File { get; set; }
}
