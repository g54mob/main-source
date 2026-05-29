using System;

namespace Utf8Json.Formatters
{
	public sealed class ByteArraySegmentFormatter : IJsonFormatter<ArraySegment<byte>>, IJsonFormatter
	{
		public static readonly IJsonFormatter<ArraySegment<byte>> Default;

		public void Serialize(ref JsonWriter writer, ArraySegment<byte> value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ArraySegment<byte> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(ArraySegment<byte>);
		}
	}
}
