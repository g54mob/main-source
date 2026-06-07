using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Google.Protobuf
{
	internal static class ParsingPrimitives
	{
		private const int StackallocThreshold = 256;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ParseLength(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0;
		}

		public static uint ParseTag(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0u;
		}

		public static bool MaybeConsumeTag(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, uint tag)
		{
			return false;
		}

		public static uint PeekTag(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0u;
		}

		public static ulong ParseRawVarint64(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0uL;
		}

		private static ulong ParseRawVarint64SlowPath(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0uL;
		}

		public static uint ParseRawVarint32(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0u;
		}

		private static uint ParseRawVarint32SlowPath(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0u;
		}

		public static uint ParseRawLittleEndian32(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0u;
		}

		private static uint ParseRawLittleEndian32SlowPath(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0u;
		}

		public static ulong ParseRawLittleEndian64(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0uL;
		}

		private static ulong ParseRawLittleEndian64SlowPath(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0uL;
		}

		public static double ParseDouble(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0.0;
		}

		public static float ParseFloat(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0f;
		}

		private static float ParseFloatSlow(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0f;
		}

		public static byte[] ReadRawBytes(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, int size)
		{
			return null;
		}

		private static byte[] ReadRawBytesSlow(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, int size)
		{
			return null;
		}

		public static void SkipRawBytes(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, int size)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string ReadString(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ByteString ReadBytes(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return null;
		}

		public static string ReadRawString(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, int length)
		{
			return null;
		}

		private static string ReadStringSlow(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, int length)
		{
			return null;
		}

		private static void ValidateCurrentLimit(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, int size)
		{
		}

		private static byte ReadRawByte(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state)
		{
			return 0;
		}

		public static uint ReadRawVarint32(Stream input)
		{
			return 0u;
		}

		public static int DecodeZigZag32(uint n)
		{
			return 0;
		}

		public static long DecodeZigZag64(ulong n)
		{
			return 0L;
		}

		public static bool IsDataAvailable(ref ParserInternalState state, int size)
		{
			return false;
		}

		private static bool IsDataAvailableInSource(ref ParserInternalState state, int size)
		{
			return false;
		}

		private static void ReadRawBytesIntoSpan(ref ReadOnlySpan<byte> buffer, ref ParserInternalState state, int length, Span<byte> byteSpan)
		{
		}
	}
}
