using MongoDB.Bson.Serialization.Attributes;

namespace AccountService.Data.Entites
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Firstname { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Lastname { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Username { get; set; } = null!;

        //[BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        //public int Point { get; set; } = 0;
    }
}
