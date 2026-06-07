namespace Utf8Json.Formatters
{
	public sealed class BooleanFormatter : IJsonFormatter<bool>, IJsonFormatter, IObjectPropertyNameFormatter<bool>
	{
		public static readonly BooleanFormatter Default;

		public void Serialize(ref JsonWriter writer, bool value, IJsonFormatterResolver formatterResolver)
		{
		}

		public bool Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return false;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, bool value, IJsonFormatterResolver formatterResolver)
		{
		}

		public bool DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return false;
		}
	}
}
