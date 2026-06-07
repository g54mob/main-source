namespace Utf8Json.Formatters
{
	public sealed class DoubleFormatter : IJsonFormatter<double>, IJsonFormatter, IObjectPropertyNameFormatter<double>
	{
		public static readonly DoubleFormatter Default;

		public void Serialize(ref JsonWriter writer, double value, IJsonFormatterResolver formatterResolver)
		{
		}

		public double Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0.0;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, double value, IJsonFormatterResolver formatterResolver)
		{
		}

		public double DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0.0;
		}
	}
}
