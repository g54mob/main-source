namespace Utf8Json.Formatters
{
	public sealed class NullableInt32Formatter : IJsonFormatter<int?>, IJsonFormatter, IObjectPropertyNameFormatter<int?>
	{
		public static readonly NullableInt32Formatter Default;

		public void Serialize(ref JsonWriter writer, int? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public int? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, int? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public int? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
