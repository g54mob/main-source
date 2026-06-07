namespace Utf8Json.Formatters
{
	public sealed class SByteFormatter : IJsonFormatter<sbyte>, IJsonFormatter, IObjectPropertyNameFormatter<sbyte>
	{
		public static readonly SByteFormatter Default;

		public void Serialize(ref JsonWriter writer, sbyte value, IJsonFormatterResolver formatterResolver)
		{
		}

		public sbyte Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, sbyte value, IJsonFormatterResolver formatterResolver)
		{
		}

		public sbyte DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}
	}
}
