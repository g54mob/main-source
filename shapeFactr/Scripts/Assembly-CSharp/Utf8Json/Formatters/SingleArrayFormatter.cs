namespace Utf8Json.Formatters
{
	public sealed class SingleArrayFormatter : IJsonFormatter<float[]>, IJsonFormatter
	{
		public static readonly SingleArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, float[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public float[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
