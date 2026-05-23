using System;

namespace Utf8Json
{
	public struct JsonWriter
	{
		private static readonly byte[] emptyBytes;

		private byte[] buffer;

		private int offset;

		public int CurrentOffset => 0;

		public void AdvanceOffset(int offset)
		{
		}

		public static byte[] GetEncodedPropertyName(string propertyName)
		{
			return null;
		}

		public static byte[] GetEncodedPropertyNameWithPrefixValueSeparator(string propertyName)
		{
			return null;
		}

		public static byte[] GetEncodedPropertyNameWithBeginObject(string propertyName)
		{
			return null;
		}

		public static byte[] GetEncodedPropertyNameWithoutQuotation(string propertyName)
		{
			return null;
		}

		public JsonWriter(byte[] initialBuffer)
		{
			buffer = null;
			offset = 0;
		}

		public ArraySegment<byte> GetBuffer()
		{
			return default(ArraySegment<byte>);
		}

		public byte[] ToUtf8ByteArray()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public void EnsureCapacity(int appendLength)
		{
		}

		public void WriteRaw(byte rawValue)
		{
		}

		public void WriteRaw(byte[] rawValue)
		{
		}

		public void WriteRawUnsafe(byte rawValue)
		{
		}

		public void WriteBeginArray()
		{
		}

		public void WriteEndArray()
		{
		}

		public void WriteBeginObject()
		{
		}

		public void WriteEndObject()
		{
		}

		public void WriteValueSeparator()
		{
		}

		public void WriteNameSeparator()
		{
		}

		public void WritePropertyName(string propertyName)
		{
		}

		public void WriteQuotation()
		{
		}

		public void WriteNull()
		{
		}

		public void WriteBoolean(bool value)
		{
		}

		public void WriteTrue()
		{
		}

		public void WriteFalse()
		{
		}

		public void WriteSingle(float value)
		{
		}

		public void WriteDouble(double value)
		{
		}

		public void WriteByte(byte value)
		{
		}

		public void WriteUInt16(ushort value)
		{
		}

		public void WriteUInt32(uint value)
		{
		}

		public void WriteUInt64(ulong value)
		{
		}

		public void WriteSByte(sbyte value)
		{
		}

		public void WriteInt16(short value)
		{
		}

		public void WriteInt32(int value)
		{
		}

		public void WriteInt64(long value)
		{
		}

		public void WriteString(string value)
		{
		}
	}
}
