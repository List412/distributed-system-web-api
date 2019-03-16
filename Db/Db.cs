using System.Collections.Generic;
using System.Linq;
using distributed_system_web_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace distributed_system_web_api.Db
{
    public class Db
    {
        private const string ConnectionString = "mongodb+srv://list412:List_412@distributed-system-ejqle.azure.mongodb.net/test?retryWrites=true";
//        private const string ConnectionString = "mongodb+srv://list412:List_412@parser-data-gammo.mongodb.net/test?retryWrites=true";
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Picture> _collection;
        
        public Db()
        {
            _client = new MongoClient(ConnectionString);
            _db = _client.GetDatabase("distributed");
//            _db = _client.GetDatabase("parser");
            _collection = _db.GetCollection<Picture>(Picture.CollectionName);
//            _collection = _db.GetCollection<Picture>("zakupki");
        }


        public ObjectId Add(Picture picture)
        {
           _collection.InsertOne(picture);
           return picture.Id;
        }

        public Picture Get(ObjectId id)
        {
            return _collection.Find(x => x.Id == id).ToList().First();
        }

        public List<Picture> GetAll()
        {
            var res = _collection.Find(_ => true).ToEnumerable();
            foreach (var re in res)
            {
                var a = re;               
            }
             return res.ToList();
        }
        
        
        
        //TODO Get, GetAll, Delete
    }
}
