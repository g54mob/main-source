namespace Utf8Json.Formatters
{
	public sealed class NullableByteFormatter : IJsonFormatter<byte?>, IJsonFormatter, IObjectPropertyNameFormatter<byte?>
	{
		public static readonly NullableByteFormatter Default;

		public void Serialize(ref JsonWriter writer, byte? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public byte? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, byte? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public byte? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
