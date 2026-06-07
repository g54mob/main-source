namespace Newtonsoft.Json.Bson
{
	internal abstract class BsonToken
	{
		public abstract Newtonsoft.Json.Bson.BsonType Type { get; }

		public Newtonsoft.Json.Bson.BsonToken Parent { get; set; }

		public int CalculatedSize { get; set; }
	}
}
