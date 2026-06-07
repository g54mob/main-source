namespace Newtonsoft.Json.Bson
{
	internal class BsonRegex : Newtonsoft.Json.Bson.BsonToken
	{
		public Newtonsoft.Json.Bson.BsonString Pattern { get; set; }

		public Newtonsoft.Json.Bson.BsonString Options { get; set; }

		public override Newtonsoft.Json.Bson.BsonType Type => default(Newtonsoft.Json.Bson.BsonType);

		public BsonRegex(string pattern, string options)
		{
		}
	}
}
