namespace Utf8Json.Formatters
{
	public sealed class UInt16Formatter : IJsonFormatter<ushort>, IJsonFormatter, IObjectPropertyNameFormatter<ushort>
	{
		public static readonly UInt16Formatter Default;

		public void Serialize(ref JsonWriter writer, ushort value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ushort Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, ushort value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ushort DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0;
		}
	}
}
