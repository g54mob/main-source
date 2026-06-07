namespace Utf8Json.Formatters
{
	public sealed class BooleanArrayFormatter : IJsonFormatter<bool[]>, IJsonFormatter
	{
		public static readonly BooleanArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, bool[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public bool[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
