namespace Utf8Json.Formatters
{
	public sealed class NullableCharFormatter : IJsonFormatter<char?>, IJsonFormatter
	{
		public static readonly NullableCharFormatter Default;

		public void Serialize(ref JsonWriter writer, char? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public char? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
