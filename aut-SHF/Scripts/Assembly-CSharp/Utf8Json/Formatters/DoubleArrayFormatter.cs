namespace Utf8Json.Formatters
{
	public sealed class DoubleArrayFormatter : IJsonFormatter<double[]>, IJsonFormatter
	{
		public static readonly DoubleArrayFormatter Default;

		public void Serialize(ref JsonWriter writer, double[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public double[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
