using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shopping.API.Model
{
    public class Product
    {
        [BsonId] // This attribute indicates that the Id property is the primary key in MongoDB.
        [BsonRepresentation(BsonType.ObjectId)] // This attribute indicates that the Id property should be treated as an ObjectId in MongoDB.
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
