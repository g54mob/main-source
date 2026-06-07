namespace Newtonsoft.Json.Bson
{
	internal class BsonBinary : Newtonsoft.Json.Bson.BsonValue
	{
		public BsonBinaryType BinaryType { get; set; }

		public BsonBinary(byte[] value, BsonBinaryType binaryType)
			: base(null, default(Newtonsoft.Json.Bson.BsonType))
		{
		}
	}
}
