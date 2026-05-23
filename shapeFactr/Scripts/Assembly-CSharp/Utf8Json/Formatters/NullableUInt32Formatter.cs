namespace Utf8Json.Formatters
{
	public sealed class NullableUInt32Formatter : IJsonFormatter<uint?>, IJsonFormatter, IObjectPropertyNameFormatter<uint?>
	{
		public static readonly NullableUInt32Formatter Default;

		public void Serialize(ref JsonWriter writer, uint? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public uint? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, uint? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public uint? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
