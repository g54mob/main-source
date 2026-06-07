namespace Utf8Json.Formatters
{
	public sealed class SByteArrayFormatter : IJsonFormatter<sbyte[]>, IJsonFormatter
	{
		public static readonly SByteArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, sbyte[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public sbyte[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
