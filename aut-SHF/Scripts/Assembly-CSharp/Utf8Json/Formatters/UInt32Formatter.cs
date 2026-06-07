namespace Utf8Json.Formatters
{
	public sealed class UInt32Formatter : IJsonFormatter<uint>, IJsonFormatter, IObjectPropertyNameFormatter<uint>
	{
		public static readonly UInt32Formatter Default;

		public void Serialize(ref JsonWriter writer, uint value, IJsonFormatterResolver formatterResolver)
		{
		}

		public uint Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0u;
		}

		public void SerializeToPropertyName(ref JsonWriter writer, uint value, IJsonFormatterResolver formatterResolver)
		{
		}

		public uint DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return 0u;
		}
	}
}
