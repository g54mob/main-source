namespace Utf8Json.Formatters
{
	public sealed class NullableSByteFormatter : IJsonFormatter<sbyte?>, IJsonFormatter, IObjectPropertyNameFormatter<sbyte?>
	{
		public static readonly NullableSByteFormatter Default;

		public void Serialize(ref JsonWriter writer, sbyte? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public sbyte? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, sbyte? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public sbyte? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
