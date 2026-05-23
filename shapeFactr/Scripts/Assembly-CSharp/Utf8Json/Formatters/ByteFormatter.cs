namespace Utf8Json.Formatters
{
	public sealed class ByteFormatter : IJsonFormatter<byte>, IJsonFormatter, IObjectPropertyNameFormatter<byte>
	{
		public static readonly ByteFormatter Default;

		public void Serialize(ref JsonWriter writer, byte value, IJsonFormatterResolver formatterResolver)
		{
		}

		public byte Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, byte value, IJsonFormatterResolver formatterResolver)
		{
		}

		public byte DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}
	}
}
