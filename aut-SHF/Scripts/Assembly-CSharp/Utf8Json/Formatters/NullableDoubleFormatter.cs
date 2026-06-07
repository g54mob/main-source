namespace Utf8Json.Formatters
{
	public sealed class NullableDoubleFormatter : IJsonFormatter<double?>, IJsonFormatter, IObjectPropertyNameFormatter<double?>
	{
		public static readonly NullableDoubleFormatter Default;

		public void Serialize(ref JsonWriter writer, double? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public double? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, double? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public double? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
