namespace Utf8Json.Formatters
{
	public sealed class Int64Formatter : IJsonFormatter<long>, IJsonFormatter, IObjectPropertyNameFormatter<long>
	{
		public static readonly Int64Formatter Default;

		public void Serialize(ref JsonWriter writer, long value, IJsonFormatterResolver formatterResolver)
		{
		}

		public long Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0L;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, long value, IJsonFormatterResolver formatterResolver)
		{
		}

		public long DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0L;
		}
	}
}
