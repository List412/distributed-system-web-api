using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace distributed_system_web_api.Models
{
    public class Picture
    {
        public static string CollectionName = "pictures";

        public Picture()
        {
            
        }

        public Picture(string name, byte[] picture)
        {
            Name = name;
            File = picture;
        }

        [BsonId]
        public ObjectId Id{ get; set; }
        
        public string Name { get; set; }
        
        public byte[] File { get; set; }
    }
}