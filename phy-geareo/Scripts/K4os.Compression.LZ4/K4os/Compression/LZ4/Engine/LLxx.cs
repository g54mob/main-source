using System;
using System.Runtime.CompilerServices;

namespace K4os.Compression.LZ4.Engine
{
	internal static class LLxx
	{
		private static NotImplementedException AlgorithmNotImplemented(string action)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe(byte* source, byte* target, int sourceLength, int targetLength)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe_partial(byte* source, byte* target, int sourceLength, int targetLength)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe_usingDict(byte* source, byte* target, int sourceLength, int targetLength, byte* dictionary, int dictionaryLength)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_decompress_safe_continue(LL.LZ4_streamDecode_t* context, byte* source, byte* target, int sourceLength, int targetLength)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_fast(byte* source, byte* target, int sourceLength, int targetLength, int acceleration)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_fast_continue(LL.LZ4_stream_t* context, byte* source, byte* target, int sourceLength, int targetLength, int acceleration)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_HC(byte* source, byte* target, int sourceLength, int targetLength, int level)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static int LZ4_compress_HC_continue(LL.LZ4_streamHC_t* context, byte* source, byte* target, int sourceLength, int targetLength)
		{
			return 0;
		}
	}
}
