namespace Newtonsoft.Json.Bson
{
	internal class BsonValue : Newtonsoft.Json.Bson.BsonToken
	{
		private readonly object _value;

		private readonly Newtonsoft.Json.Bson.BsonType _type;

		public object Value => null;

		public override Newtonsoft.Json.Bson.BsonType Type => default(Newtonsoft.Json.Bson.BsonType);

		public BsonValue(object value, Newtonsoft.Json.Bson.BsonType type)
		{
		}
	}
}
