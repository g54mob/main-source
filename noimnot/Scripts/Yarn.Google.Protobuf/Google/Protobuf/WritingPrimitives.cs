using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Google.Protobuf
{
	internal static class WritingPrimitives
	{
		internal static readonly Encoding Utf8Encoding;

		public static void WriteDouble(ref Span<byte> buffer, ref WriterInternalState state, double value)
		{
		}

		public static void WriteFloat(ref Span<byte> buffer, ref WriterInternalState state, float value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void WriteFloatSlowPath(ref Span<byte> buffer, ref WriterInternalState state, float value)
		{
		}

		public static void WriteUInt64(ref Span<byte> buffer, ref WriterInternalState state, ulong value)
		{
		}

		public static void WriteInt64(ref Span<byte> buffer, ref WriterInternalState state, long value)
		{
		}

		public static void WriteInt32(ref Span<byte> buffer, ref WriterInternalState state, int value)
		{
		}

		public static void WriteFixed64(ref Span<byte> buffer, ref WriterInternalState state, ulong value)
		{
		}

		public static void WriteFixed32(ref Span<byte> buffer, ref WriterInternalState state, uint value)
		{
		}

		public static void WriteBool(ref Span<byte> buffer, ref WriterInternalState state, bool value)
		{
		}

		public static void WriteString(ref Span<byte> buffer, ref WriterInternalState state, string value)
		{
		}

		private static void WriteAsciiStringToBuffer(Span<byte> buffer, ref WriterInternalState state, string value, int length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void NarrowFourUtf16CharsToAsciiAndWriteToBuffer(ref byte outputBuffer, ulong value)
		{
		}

		private static int WriteStringToBuffer(Span<byte> buffer, ref WriterInternalState state, string value)
		{
			return 0;
		}

		public static void WriteBytes(ref Span<byte> buffer, ref WriterInternalState state, ByteString value)
		{
		}

		public static void WriteUInt32(ref Span<byte> buffer, ref WriterInternalState state, uint value)
		{
		}

		public static void WriteEnum(ref Span<byte> buffer, ref WriterInternalState state, int value)
		{
		}

		public static void WriteSFixed32(ref Span<byte> buffer, ref WriterInternalState state, int value)
		{
		}

		public static void WriteSFixed64(ref Span<byte> buffer, ref WriterInternalState state, long value)
		{
		}

		public static void WriteSInt32(ref Span<byte> buffer, ref WriterInternalState state, int value)
		{
		}

		public static void WriteSInt64(ref Span<byte> buffer, ref WriterInternalState state, long value)
		{
		}

		public static void WriteLength(ref Span<byte> buffer, ref WriterInternalState state, int length)
		{
		}

		public static void WriteRawVarint32(ref Span<byte> buffer, ref WriterInternalState state, uint value)
		{
		}

		public static void WriteRawVarint64(ref Span<byte> buffer, ref WriterInternalState state, ulong value)
		{
		}

		public static void WriteRawLittleEndian32(ref Span<byte> buffer, ref WriterInternalState state, uint value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void WriteRawLittleEndian32SlowPath(ref Span<byte> buffer, ref WriterInternalState state, uint value)
		{
		}

		public static void WriteRawLittleEndian64(ref Span<byte> buffer, ref WriterInternalState state, ulong value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteRawLittleEndian64SlowPath(ref Span<byte> buffer, ref WriterInternalState state, ulong value)
		{
		}

		private static void WriteRawByte(ref Span<byte> buffer, ref WriterInternalState state, byte value)
		{
		}

		public static void WriteRawBytes(ref Span<byte> buffer, ref WriterInternalState state, byte[] value)
		{
		}

		public static void WriteRawBytes(ref Span<byte> buffer, ref WriterInternalState state, byte[] value, int offset, int length)
		{
		}

		public static void WriteRawBytes(ref Span<byte> buffer, ref WriterInternalState state, ReadOnlySpan<byte> value)
		{
		}

		public static void WriteTag(ref Span<byte> buffer, ref WriterInternalState state, int fieldNumber, WireFormat.WireType type)
		{
		}

		public static void WriteTag(ref Span<byte> buffer, ref WriterInternalState state, uint tag)
		{
		}

		public static void WriteRawTag(ref Span<byte> buffer, ref WriterInternalState state, byte b1)
		{
		}

		public static void WriteRawTag(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void WriteRawTagSlowPath(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2)
		{
		}

		public static void WriteRawTag(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2, byte b3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void WriteRawTagSlowPath(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2, byte b3)
		{
		}

		public static void WriteRawTag(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2, byte b3, byte b4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void WriteRawTagSlowPath(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2, byte b3, byte b4)
		{
		}

		public static void WriteRawTag(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2, byte b3, byte b4, byte b5)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void WriteRawTagSlowPath(ref Span<byte> buffer, ref WriterInternalState state, byte b1, byte b2, byte b3, byte b4, byte b5)
		{
		}

		public static uint EncodeZigZag32(int n)
		{
			return 0u;
		}

		public static ulong EncodeZigZag64(long n)
		{
			return 0uL;
		}
	}
}
