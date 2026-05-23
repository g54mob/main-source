namespace Utf8Json.Formatters
{
	public sealed class Int16ArrayFormatter : IJsonFormatter<short[]>, IJsonFormatter
	{
		public static readonly Int16ArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, short[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public short[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
