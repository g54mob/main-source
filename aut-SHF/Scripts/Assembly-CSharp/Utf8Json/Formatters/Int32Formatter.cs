namespace Utf8Json.Formatters
{
	public sealed class Int32Formatter : IJsonFormatter<int>, IJsonFormatter, IObjectPropertyNameFormatter<int>
	{
		public static readonly Int32Formatter Default;

		public void Serialize(ref JsonWriter writer, int value, IJsonFormatterResolver formatterResolver)
		{
		}

		public int Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, int value, IJsonFormatterResolver formatterResolver)
		{
		}

		public int DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}
	}
}
