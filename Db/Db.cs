using distributed_system_web_api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace distributed_system_web_api.Db
{
    public class Db
    {
        private const string ConnectionString = "mongodb+srv://list412:List_412@distributed-system-ejqle.azure.mongodb.net/test?retryWrites=true";
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Picture> _collection;
        
        public Db()
        {
            _client = new MongoClient(ConnectionString);
            _db = _client.GetDatabase("distributed");
            _collection = _db.GetCollection<Picture>(Picture.CollectionName);
        }


        public ObjectId Add(Picture picture)
        {
           _collection.InsertOne(picture);
           return picture.Id;
        }
        
        //TODO Get, GetAll, Delete
    }
}
