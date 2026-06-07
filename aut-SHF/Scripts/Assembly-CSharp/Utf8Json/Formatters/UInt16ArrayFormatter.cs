namespace Utf8Json.Formatters
{
	public sealed class UInt16ArrayFormatter : IJsonFormatter<ushort[]>, IJsonFormatter
	{
		public static readonly UInt16ArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, ushort[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ushort[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
