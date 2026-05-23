using System.Collections;

namespace Utf8Json.Formatters
{
	public sealed class BitArrayFormatter : IJsonFormatter<BitArray>, IJsonFormatter
	{
		public static readonly IJsonFormatter<BitArray> Default;

		public void Serialize(ref JsonWriter writer, BitArray value, IJsonFormatterResolver formatterResolver)
		{
		}

		public BitArray Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
