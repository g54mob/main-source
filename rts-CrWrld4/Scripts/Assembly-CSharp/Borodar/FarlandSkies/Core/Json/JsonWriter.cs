using System.IO;
using System.Text;
using Borodar.FarlandSkies.Core.Json.Internal;

namespace Borodar.FarlandSkies.Core.Json
{
	public sealed class JsonWriter : IJsonWriter
	{
		private enum WriteContext
		{
			Root = 0,
			Object = 1,
			Array = 2
		}

		private readonly TextWriter writer;

		private SimpleStack<WriteContext> writeContextStack;

		private bool isWriteContextEmpty;

		public JsonWriterSettings Settings { get; private set; }

		public static JsonWriter Create()
		{
			return null;
		}

		public static JsonWriter Create(JsonWriterSettings settings)
		{
			return null;
		}

		public static JsonWriter Create(StringBuilder builder)
		{
			return null;
		}

		public static JsonWriter Create(StringBuilder builder, JsonWriterSettings settings)
		{
			return null;
		}

		public static JsonWriter Create(Stream stream)
		{
			return null;
		}

		public static JsonWriter Create(Stream stream, JsonWriterSettings settings)
		{
			return null;
		}

		public static JsonWriter Create(TextWriter textWriter)
		{
			return null;
		}

		public static JsonWriter Create(TextWriter textWriter, JsonWriterSettings settings)
		{
			return null;
		}

		private JsonWriter(TextWriter textWriter, JsonWriterSettings settings)
		{
		}

		private void WriteIndent()
		{
		}

		private void WriteLine()
		{
		}

		private void WriteSpace()
		{
		}

		private void WriteEscapedLiteral(string value)
		{
		}

		private void DoBeginValue()
		{
		}

		private void DoEndValue()
		{
		}

		private void WriteValueRaw(string content)
		{
		}

		public void WriteStartObject(int propertyCount)
		{
		}

		public void WriteStartObject()
		{
		}

		public void WritePropertyKey(string key)
		{
		}

		public void WriteEndObject()
		{
		}

		public void WriteStartArray(int arrayLength)
		{
		}

		public void WriteStartArray()
		{
		}

		public void WriteEndArray()
		{
		}

		public void WriteNull()
		{
		}

		public void WriteInteger(long value)
		{
		}

		public void WriteDouble(double value)
		{
		}

		public void WriteString(string value)
		{
		}

		public void WriteBoolean(bool value)
		{
		}

		public void WriteBinary(byte[] value)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
