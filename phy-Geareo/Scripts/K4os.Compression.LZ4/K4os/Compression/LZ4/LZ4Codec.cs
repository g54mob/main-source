using System;

namespace K4os.Compression.LZ4
{
	public static class LZ4Codec
	{
		public const int Version = 192;

		public static bool Enforce32
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static int MaximumOutputSize(int length)
		{
			return 0;
		}

		public unsafe static int Encode(byte* source, int sourceLength, byte* target, int targetLength, LZ4Level level = LZ4Level.L00_FAST)
		{
			return 0;
		}

		public static int Encode(ReadOnlySpan<byte> source, Span<byte> target, LZ4Level level = LZ4Level.L00_FAST)
		{
			return 0;
		}

		public static int Encode(byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, LZ4Level level = LZ4Level.L00_FAST)
		{
			return 0;
		}

		public unsafe static int Decode(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return 0;
		}

		public unsafe static int PartialDecode(byte* source, int sourceLength, byte* target, int targetLength)
		{
			return 0;
		}

		public unsafe static int Decode(byte* source, int sourceLength, byte* target, int targetLength, byte* dictionary, int dictionaryLength)
		{
			return 0;
		}

		public static int PartialDecode(ReadOnlySpan<byte> source, Span<byte> target)
		{
			return 0;
		}

		public static int Decode(ReadOnlySpan<byte> source, Span<byte> target)
		{
			return 0;
		}

		public static int Decode(ReadOnlySpan<byte> source, Span<byte> target, ReadOnlySpan<byte> dictionary)
		{
			return 0;
		}

		public static int Decode(byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength)
		{
			return 0;
		}

		public static int Decode(byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, byte[]? dictionary, int dictionaryOffset, int dictionaryLength)
		{
			return 0;
		}
	}
}
