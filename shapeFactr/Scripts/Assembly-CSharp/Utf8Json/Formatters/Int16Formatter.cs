namespace Utf8Json.Formatters
{
	public sealed class Int16Formatter : IJsonFormatter<short>, IJsonFormatter, IObjectPropertyNameFormatter<short>
	{
		public static readonly Int16Formatter Default;

		public void Serialize(ref JsonWriter writer, short value, IJsonFormatterResolver formatterResolver)
		{
		}

		public short Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, short value, IJsonFormatterResolver formatterResolver)
		{
		}

		public short DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}
	}
}
