namespace Utf8Json.Formatters
{
	public sealed class NullableUInt16Formatter : IJsonFormatter<ushort?>, IJsonFormatter, IObjectPropertyNameFormatter<ushort?>
	{
		public static readonly NullableUInt16Formatter Default;

		public void Serialize(ref JsonWriter writer, ushort? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ushort? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, ushort? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ushort? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
