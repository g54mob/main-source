using System.Buffers;

namespace System.Text.Json
{
	public class Utf8JsonWriter
	{
		public Utf8JsonWriter(IBufferWriter<byte> writer, JsonWriterOptions options)
		{
		}

		public void Flush()
		{
		}

		public void Reset()
		{
		}

		public void Reset(IBufferWriter<byte> writer)
		{
		}

		public void WriteString(JsonEncodedText text, ReadOnlySpan<byte> span)
		{
		}

		public void WriteString(JsonEncodedText text, JsonEncodedText value)
		{
		}

		public void WriteString(JsonEncodedText text, DateTimeOffset timestamp)
		{
		}

		public void WriteString(JsonEncodedText text, string str)
		{
		}

		public void WritePropertyName(JsonEncodedText text)
		{
		}

		public void WriteNumber(JsonEncodedText text, int x)
		{
		}

		public void WriteNullValue()
		{
		}

		public void WriteStartObject()
		{
		}

		public void WriteEndObject()
		{
		}

		public void WriteNull(JsonEncodedText text)
		{
		}
	}
}
