namespace Utf8Json.Formatters
{
	public sealed class NullableStringArrayFormatter : IJsonFormatter<string[]>, IJsonFormatter
	{
		public static readonly NullableStringArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, string[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public string[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
