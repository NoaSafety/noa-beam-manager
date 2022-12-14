using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noa.BeamManager.Repository.Model
{
    public class Measure
    {
        [BsonId]
        public ObjectId MeasureId { get; set; }
        public Guid BeamId { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
