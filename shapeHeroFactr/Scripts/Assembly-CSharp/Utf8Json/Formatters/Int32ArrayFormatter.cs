namespace Utf8Json.Formatters
{
	public sealed class Int32ArrayFormatter : IJsonFormatter<int[]>, IJsonFormatter
	{
		public static readonly Int32ArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, int[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public int[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
