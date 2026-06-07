namespace Utf8Json.Formatters
{
	public sealed class CharArrayFormatter : IJsonFormatter<char[]>, IJsonFormatter
	{
		public static readonly CharArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, char[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public char[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
