namespace Newtonsoft.Json.Bson
{
	internal class BsonEmpty : Newtonsoft.Json.Bson.BsonToken
	{
		public override Newtonsoft.Json.Bson.BsonType Type { get; }

		public BsonEmpty(Newtonsoft.Json.Bson.BsonType type)
		{
		}
	}
}
