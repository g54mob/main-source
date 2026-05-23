namespace Utf8Json.Formatters
{
	public sealed class UInt32ArrayFormatter : IJsonFormatter<uint[]>, IJsonFormatter
	{
		public static readonly UInt32ArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, uint[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public uint[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
