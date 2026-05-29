namespace Utf8Json.Formatters
{
	public sealed class NullableSingleFormatter : IJsonFormatter<float?>, IJsonFormatter, IObjectPropertyNameFormatter<float?>
	{
		public static readonly NullableSingleFormatter Default;

		public void Serialize(ref JsonWriter writer, float? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public float? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, float? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public float? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
