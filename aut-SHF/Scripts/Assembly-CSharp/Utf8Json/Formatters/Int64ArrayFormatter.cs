namespace Utf8Json.Formatters
{
	public sealed class Int64ArrayFormatter : IJsonFormatter<long[]>, IJsonFormatter
	{
		public static readonly Int64ArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, long[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public long[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
