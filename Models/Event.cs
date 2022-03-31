using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlphaOmegaAppServiceAPI.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EventDate { get; set; }
        public string LocationAddress { get; set; }
    }
}
