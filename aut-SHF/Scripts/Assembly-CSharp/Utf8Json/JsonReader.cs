using System;

namespace Utf8Json
{
	public struct JsonReader
	{
		internal static class StringBuilderCache
		{
			[ThreadStatic]
			private static byte[] buffer;

			[ThreadStatic]
			private static char[] codePointStringBuffer;

			public static byte[] GetBuffer()
			{
				return null;
			}

			public static char[] GetCodePointStringBuffer()
			{
				return null;
			}
		}

		private static readonly ArraySegment<byte> nullTokenSegment;

		private static readonly byte[] bom;

		private readonly byte[] bytes;

		private int offset;

		private bool IsInRange => false;

		public JsonReader(byte[] bytes)
		{
			this.bytes = null;
			offset = 0;
		}

		public JsonReader(byte[] bytes, int offset)
		{
			this.bytes = null;
			this.offset = 0;
		}

		private JsonParsingException CreateParsingException(string expected)
		{
			return null;
		}

		private JsonParsingException CreateParsingExceptionMessage(string message)
		{
			return null;
		}

		public void AdvanceOffset(int offset)
		{
		}

		public byte[] GetBufferUnsafe()
		{
			return null;
		}

		public int GetCurrentOffsetUnsafe()
		{
			return 0;
		}

		public JsonToken GetCurrentJsonToken()
		{
			return default(JsonToken);
		}

		public void SkipWhiteSpace()
		{
		}

		public bool ReadIsNull()
		{
			return false;
		}

		public bool ReadIsBeginArray()
		{
			return false;
		}

		public void ReadIsBeginArrayWithVerify()
		{
		}

		public bool ReadIsEndArray()
		{
			return false;
		}

		public void ReadIsEndArrayWithVerify()
		{
		}

		public bool ReadIsEndArrayWithSkipValueSeparator(ref int count)
		{
			return false;
		}

		public bool ReadIsInArray(ref int count)
		{
			return false;
		}

		public bool ReadIsBeginObject()
		{
			return false;
		}

		public void ReadIsBeginObjectWithVerify()
		{
		}

		public bool ReadIsEndObject()
		{
			return false;
		}

		public void ReadIsEndObjectWithVerify()
		{
		}

		public bool ReadIsEndObjectWithSkipValueSeparator(ref int count)
		{
			return false;
		}

		public bool ReadIsInObject(ref int count)
		{
			return false;
		}

		public bool ReadIsValueSeparator()
		{
			return false;
		}

		public void ReadIsValueSeparatorWithVerify()
		{
		}

		public bool ReadIsNameSeparator()
		{
			return false;
		}

		public void ReadIsNameSeparatorWithVerify()
		{
		}

		private void ReadStringSegmentCore(out byte[] resultBytes, out int resultOffset, out int resultLength)
		{
			resultBytes = null;
			resultOffset = default(int);
			resultLength = default(int);
		}

		private static int GetCodePoint(char a, char b, char c, char d)
		{
			return 0;
		}

		private static int ToNumber(char x)
		{
			return 0;
		}

		public ArraySegment<byte> ReadStringSegmentUnsafe()
		{
			return default(ArraySegment<byte>);
		}

		public string ReadString()
		{
			return null;
		}

		public string ReadPropertyName()
		{
			return null;
		}

		public ArraySegment<byte> ReadStringSegmentRaw()
		{
			return default(ArraySegment<byte>);
		}

		public ArraySegment<byte> ReadPropertyNameSegmentRaw()
		{
			return default(ArraySegment<byte>);
		}

		public bool ReadBoolean()
		{
			return false;
		}

		private static bool IsWordBreak(byte c)
		{
			return false;
		}

		public void ReadNext()
		{
		}

		private void ReadNextCore(JsonToken token)
		{
		}

		public void ReadNextBlock()
		{
		}

		private void ReadNextBlockCore(int stack)
		{
		}

		public ArraySegment<byte> ReadNextBlockSegment()
		{
			return default(ArraySegment<byte>);
		}

		public sbyte ReadSByte()
		{
			return 0;
		}

		public short ReadInt16()
		{
			return 0;
		}

		public int ReadInt32()
		{
			return 0;
		}

		public long ReadInt64()
		{
			return 0L;
		}

		public byte ReadByte()
		{
			return 0;
		}

		public ushort ReadUInt16()
		{
			return 0;
		}

		public uint ReadUInt32()
		{
			return 0u;
		}

		public ulong ReadUInt64()
		{
			return 0uL;
		}

		public float ReadSingle()
		{
			return 0f;
		}

		public double ReadDouble()
		{
			return 0.0;
		}

		public ArraySegment<byte> ReadNumberSegment()
		{
			return default(ArraySegment<byte>);
		}

		private static int ReadComment(byte[] bytes, int offset)
		{
			return 0;
		}
	}
}
