namespace Utf8Json.Formatters
{
	public sealed class NullableStringFormatter : IJsonFormatter<string>, IJsonFormatter, IObjectPropertyNameFormatter<string>
	{
		public static readonly IJsonFormatter<string> Default;

		public void Serialize(ref JsonWriter writer, string value, IJsonFormatterResolver formatterResolver)
		{
		}

		public string Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, string value, IJsonFormatterResolver formatterResolver)
		{
		}

		public string DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
