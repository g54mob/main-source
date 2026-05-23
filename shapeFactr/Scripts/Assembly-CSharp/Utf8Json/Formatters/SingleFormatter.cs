namespace Utf8Json.Formatters
{
	public sealed class SingleFormatter : IJsonFormatter<float>, IJsonFormatter, IObjectPropertyNameFormatter<float>
	{
		public static readonly SingleFormatter Default;

		public void Serialize(ref JsonWriter writer, float value, IJsonFormatterResolver formatterResolver)
		{
		}

		public float Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0f;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, float value, IJsonFormatterResolver formatterResolver)
		{
		}

		public float DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0f;
		}
	}
}
