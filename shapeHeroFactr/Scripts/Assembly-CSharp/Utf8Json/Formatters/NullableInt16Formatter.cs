namespace Utf8Json.Formatters
{
	public sealed class NullableInt16Formatter : IJsonFormatter<short?>, IJsonFormatter, IObjectPropertyNameFormatter<short?>
	{
		public static readonly NullableInt16Formatter Default;

		public void Serialize(ref JsonWriter writer, short? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public short? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, short? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public short? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
