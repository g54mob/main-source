namespace Utf8Json.Formatters
{
	public sealed class ByteArrayFormatter : IJsonFormatter<byte[]>, IJsonFormatter
	{
		public static readonly IJsonFormatter<byte[]> Default;

		public void Serialize(ref JsonWriter writer, byte[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public byte[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
