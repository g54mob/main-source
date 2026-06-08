using System;

namespace K4os.Compression.LZ4.Encoders
{
	public static class LZ4EncoderExtensions
	{
		public unsafe static bool Topup(this ILZ4Encoder encoder, ref byte* source, int length)
		{
			return false;
		}

		public static int Topup(this ILZ4Encoder encoder, byte[] source, int offset, int length)
		{
			return 0;
		}

		public static bool Topup(this ILZ4Encoder encoder, byte[] source, ref int offset, int length)
		{
			return false;
		}

		public static int Encode(this ILZ4Encoder encoder, byte[] target, int offset, int length, bool allowCopy)
		{
			return 0;
		}

		public static EncoderAction Encode(this ILZ4Encoder encoder, byte[] target, ref int offset, int length, bool allowCopy)
		{
			return default(EncoderAction);
		}

		public unsafe static EncoderAction Encode(this ILZ4Encoder encoder, ref byte* target, int length, bool allowCopy)
		{
			return default(EncoderAction);
		}

		public unsafe static EncoderAction TopupAndEncode(this ILZ4Encoder encoder, byte* source, int sourceLength, byte* target, int targetLength, bool forceEncode, bool allowCopy, out int loaded, out int encoded)
		{
			loaded = default(int);
			encoded = default(int);
			return default(EncoderAction);
		}

		public static EncoderAction TopupAndEncode(this ILZ4Encoder encoder, byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, bool forceEncode, bool allowCopy, out int loaded, out int encoded)
		{
			loaded = default(int);
			encoded = default(int);
			return default(EncoderAction);
		}

		public static EncoderAction TopupAndEncode(this ILZ4Encoder encoder, ReadOnlySpan<byte> source, Span<byte> target, bool forceEncode, bool allowCopy, out int loaded, out int encoded)
		{
			loaded = default(int);
			encoded = default(int);
			return default(EncoderAction);
		}

		private unsafe static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, byte* target, int targetLength, bool forceEncode, bool allowCopy, int loaded, out int encoded)
		{
			encoded = default(int);
			return default(EncoderAction);
		}

		public unsafe static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, byte* target, int targetLength, bool allowCopy, out int encoded)
		{
			encoded = default(int);
			return default(EncoderAction);
		}

		public static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, byte[] target, int targetOffset, int targetLength, bool allowCopy, out int encoded)
		{
			encoded = default(int);
			return default(EncoderAction);
		}

		public static EncoderAction FlushAndEncode(this ILZ4Encoder encoder, Span<byte> target, bool allowCopy, out int encoded)
		{
			encoded = default(int);
			return default(EncoderAction);
		}

		public static void Drain(this ILZ4Decoder decoder, byte[] target, int targetOffset, int offset, int length)
		{
		}

		public static void Drain(this ILZ4Decoder decoder, Span<byte> target, int offset, int length)
		{
		}

		public unsafe static bool DecodeAndDrain(this ILZ4Decoder decoder, byte* source, int sourceLength, byte* target, int targetLength, out int decoded)
		{
			decoded = default(int);
			return false;
		}

		public static bool DecodeAndDrain(this ILZ4Decoder decoder, byte[] source, int sourceOffset, int sourceLength, byte[] target, int targetOffset, int targetLength, out int decoded)
		{
			decoded = default(int);
			return false;
		}

		public static bool DecodeAndDrain(this ILZ4Decoder decoder, ReadOnlySpan<byte> source, Span<byte> target, out int decoded)
		{
			decoded = default(int);
			return false;
		}

		public static int Inject(this ILZ4Decoder decoder, byte[] buffer, int offset, int length)
		{
			return 0;
		}

		public static int Decode(this ILZ4Decoder decoder, byte[] buffer, int offset, int length, int blockSize = 0)
		{
			return 0;
		}
	}
}
