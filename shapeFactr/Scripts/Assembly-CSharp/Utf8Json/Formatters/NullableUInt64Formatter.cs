namespace Utf8Json.Formatters
{
	public sealed class NullableUInt64Formatter : IJsonFormatter<ulong?>, IJsonFormatter, IObjectPropertyNameFormatter<ulong?>
	{
		public static readonly NullableUInt64Formatter Default;

		public void Serialize(ref JsonWriter writer, ulong? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ulong? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, ulong? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ulong? DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
