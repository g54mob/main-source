namespace Utf8Json.Formatters
{
	public sealed class CharFormatter : IJsonFormatter<char>, IJsonFormatter
	{
		public static readonly CharFormatter Default;

		public void Serialize(ref JsonWriter writer, char value, IJsonFormatterResolver formatterResolver)
		{
		}

		public char Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return '\0';
		}
	}
}
