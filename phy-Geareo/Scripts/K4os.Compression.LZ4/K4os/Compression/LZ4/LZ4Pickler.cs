using System;
using System.Buffers;

namespace K4os.Compression.LZ4
{
	public static class LZ4Pickler
	{
		private const int MAX_STACKALLOC = 1024;

		private const byte VersionMask = 7;

		public static byte[] Pickle(byte[] source, LZ4Level level = LZ4Level.L00_FAST)
		{
			return null;
		}

		public static byte[] Pickle(byte[] source, int sourceIndex, int sourceLength, LZ4Level level = LZ4Level.L00_FAST)
		{
			return null;
		}

		public unsafe static byte[] Pickle(byte* source, int length, LZ4Level level = LZ4Level.L00_FAST)
		{
			return null;
		}

		public static byte[] Pickle(ReadOnlySpan<byte> source, LZ4Level level = LZ4Level.L00_FAST)
		{
			return null;
		}

		private static byte[] PickleWithBuffer(ReadOnlySpan<byte> source, LZ4Level level, Span<byte> buffer)
		{
			return null;
		}

		public static void Pickle<TBufferWriter>(ReadOnlySpan<byte> source, TBufferWriter writer, LZ4Level level = LZ4Level.L00_FAST) where TBufferWriter : IBufferWriter<byte>
		{
		}

		public static void Pickle(ReadOnlySpan<byte> source, IBufferWriter<byte> writer, LZ4Level level = LZ4Level.L00_FAST)
		{
		}

		private static int GetPessimisticHeaderSize(int version, int sourceLength)
		{
			return 0;
		}

		private static int GetUncompressedHeaderSize(int version, int sourceLength)
		{
			return 0;
		}

		private static int GetCompressedHeaderSize(int version, int sourceLength, int encodedLength)
		{
			return 0;
		}

		private static int EncodeUncompressedHeader(Span<byte> target, int version, int sourceLength)
		{
			return 0;
		}

		private static int EncodeUncompressedHeaderV0(Span<byte> target)
		{
			return 0;
		}

		private static int EncodeCompressedHeader(Span<byte> target, int version, int headerSize, int sourceLength, int encodedLength)
		{
			return 0;
		}

		private static int EncodeCompressedHeaderV0(Span<byte> target, int headerSize, int sourceLength, int encodedLength)
		{
			return 0;
		}

		private static void PokeN(Span<byte> target, int value, int size)
		{
		}

		private static byte EncodeHeaderByteV0(int sizeOfDiff)
		{
			return 0;
		}

		private static int EffectiveSizeOf(int value)
		{
			return 0;
		}

		private static int EncodeSizeOf(int size)
		{
			return 0;
		}

		private static Exception UnexpectedVersion(int version)
		{
			return null;
		}

		public static byte[] Unpickle(byte[] source)
		{
			return null;
		}

		public static byte[] Unpickle(byte[] source, int index, int count)
		{
			return null;
		}

		public unsafe static byte[] Unpickle(byte* source, int count)
		{
			return null;
		}

		public static byte[] Unpickle(ReadOnlySpan<byte> source)
		{
			return null;
		}

		public static void Unpickle<TBufferWriter>(ReadOnlySpan<byte> source, TBufferWriter writer) where TBufferWriter : IBufferWriter<byte>
		{
		}

		public static void Unpickle(ReadOnlySpan<byte> source, IBufferWriter<byte> writer)
		{
		}

		public static int UnpickledSize(ReadOnlySpan<byte> source)
		{
			return 0;
		}

		private static int UnpickledSize(in PickleHeader header)
		{
			return 0;
		}

		public static void Unpickle(ReadOnlySpan<byte> source, Span<byte> output)
		{
		}

		private static void UnpickleCore(in PickleHeader header, ReadOnlySpan<byte> source, Span<byte> target)
		{
		}

		private static PickleHeader DecodeHeader(ReadOnlySpan<byte> source)
		{
			return default(PickleHeader);
		}

		private static PickleHeader DecodeHeaderV0(ReadOnlySpan<byte> source)
		{
			return default(PickleHeader);
		}

		private static int PeekN(ReadOnlySpan<byte> bytes, int size)
		{
			return 0;
		}

		private static Exception CorruptedPickle(string message)
		{
			return null;
		}
	}
}
