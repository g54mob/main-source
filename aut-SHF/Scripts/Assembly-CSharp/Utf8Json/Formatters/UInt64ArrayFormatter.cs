namespace Utf8Json.Formatters
{
	public sealed class UInt64ArrayFormatter : IJsonFormatter<ulong[]>, IJsonFormatter
	{
		public static readonly UInt64ArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, ulong[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ulong[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
