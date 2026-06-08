using System.Runtime.CompilerServices;

namespace K4os.Compression.LZ4.Engine
{
	internal class LL32 : LL
	{
		protected static cParams_t[] clTable;

		protected const int ALGORITHM_ARCH = 4;

		private static readonly uint[] _DeBruijnBytePos;

		private unsafe static readonly uint* DeBruijnBytePos;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4_decompress_generic(byte* src, byte* dst, int srcSize, int outputSize, endCondition_directive endOnInput, earlyEnd_directive partialDecoding, dict_directive dict, byte* lowPrefix, byte* dictStart, uint dictSize)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4_decompress_generic(byte* src, byte* dst, int srcSize, int outputSize, bool endOnInput, bool partialDecoding, dict_directive dict, byte* lowPrefix, byte* dictStart, uint dictSize)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe(byte* source, byte* dest, int compressedSize, int maxDecompressedSize)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe_withPrefix64k(byte* source, byte* dest, int compressedSize, int maxOutputSize)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe_withSmallPrefix(byte* source, byte* dest, int compressedSize, int maxOutputSize, uint prefixSize)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe_doubleDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, uint prefixSize, void* dictStart, uint dictSize)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe_forceExtDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, void* dictStart, uint dictSize)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe_usingDict(byte* source, byte* dest, int compressedSize, int maxOutputSize, byte* dictStart, int dictSize)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe_partial(byte* src, byte* dst, int compressedSize, int targetOutputSize, int dstCapacity)
		{
			return 0;
		}

		public unsafe static int LZ4_decompress_safe_continue(LZ4_streamDecode_t* LZ4_streamDecode, byte* source, byte* dest, int compressedSize, int maxOutputSize)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static int LZ4_compress_generic(LZ4_stream_t* cctx, byte* source, byte* dest, int inputSize, int* inputConsumed, int maxOutputSize, limitedOutput_directive outputDirective, tableType_t tableType, dict_directive dictDirective, dictIssue_directive dictIssue, int acceleration)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_fast_extState(LZ4_stream_t* state, byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_fast(byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_default(byte* src, byte* dst, int srcSize, int maxOutputSize)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_fast_continue(LZ4_stream_t* LZ4_stream, byte* source, byte* dest, int inputSize, int maxOutputSize, int acceleration)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint LZ4HC_countPattern(byte* ip, byte* iEnd, uint pattern32)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_InsertAndGetWiderMatch(LZ4_streamHC_t* hc4, byte* ip, byte* iLowLimit, byte* iHighLimit, int longest, byte** matchpos, byte** startpos, int maxNbAttempts, bool patternAnalysis, bool chainSwap, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_InsertAndFindBestMatch(LZ4_streamHC_t* hc4, byte* ip, byte* iLimit, byte** matchpos, int maxNbAttempts, bool patternAnalysis, dictCtx_directive dict)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static LZ4HC_match_t LZ4HC_FindLongerMatch(LZ4_streamHC_t* ctx, byte* ip, byte* iHighLimit, int minLen, int nbSearches, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			return default(LZ4HC_match_t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_encodeSequence(byte** ip, byte** op, byte** anchor, int matchLength, byte* match, limitedOutput_directive limit, byte* oend)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_hashChain(LZ4_streamHC_t* ctx, byte* source, byte* dest, int* srcSizePtr, int maxOutputSize, int maxNbAttempts, limitedOutput_directive limit, dictCtx_directive dict)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_optimal(LZ4_streamHC_t* ctx, byte* source, byte* dst, int* srcSizePtr, int dstCapacity, int nbSearches, uint sufficient_len, limitedOutput_directive limit, bool fullUpdate, dictCtx_directive dict, HCfavor_e favorDecSpeed)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_compress_generic_internal(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit, dictCtx_directive dict)
		{
			return 0;
		}

		public unsafe static int LZ4HC_compress_generic_noDictCtx(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			return 0;
		}

		public unsafe static int LZ4HC_compress_generic_dictCtx(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			return 0;
		}

		public unsafe static int LZ4HC_compress_generic(LZ4_streamHC_t* ctx, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, int cLevel, limitedOutput_directive limit)
		{
			return 0;
		}

		public unsafe static int LZ4_compressHC_continue_generic(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int* srcSizePtr, int dstCapacity, limitedOutput_directive limit)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_HC_continue(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int srcSize, int dstCapacity)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_HC_continue_destSize(LZ4_streamHC_t* LZ4_streamHCPtr, byte* src, byte* dst, int* srcSizePtr, int targetDestSize)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_HC_destSize(LZ4_streamHC_t* state, byte* source, byte* dest, int* sourceSizePtr, int targetDestSize, int cLevel)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_HC_extStateHC_fastReset(LZ4_streamHC_t* state, byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_HC_extStateHC(LZ4_streamHC_t* state, byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			return 0;
		}

		public unsafe static int LZ4_compress_HC(byte* src, byte* dst, int srcSize, int dstCapacity, int compressionLevel)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static uint LZ4_NbCommonBytes(uint val)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_count(byte* pIn, byte* pMatch, byte* pInLimit)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_hashPosition(void* p, tableType_t tableType)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_putPosition(byte* p, void* tableBase, tableType_t tableType, byte* srcBase)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static byte* LZ4_getPosition(byte* p, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			return null;
		}

		protected unsafe static void LZ4_renormDictT(LZ4_stream_t* LZ4_dict, int nextSize)
		{
		}

		public unsafe int LZ4_loadDict(LZ4_stream_t* LZ4_dict, byte* dictionary, int dictSize)
		{
			return 0;
		}
	}
}
