namespace Utf8Json.Formatters
{
	public sealed class NullableBooleanFormatter : IJsonFormatter<bool?>, IJsonFormatter, IObjectPropertyNameFormatter<bool?>
	{
		public static readonly NullableBooleanFormatter Default;

		public void Serialize(ref JsonWriter writer, bool? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public bool? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, bool? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public bool? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
