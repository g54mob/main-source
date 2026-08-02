using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace K4os.Compression.LZ4.Engine
{
	internal class LL
	{
		public struct LZ4_stream_t
		{
			public unsafe fixed uint hashTable[4096];

			public uint currentOffset;

			public bool dirty;

			public tableType_t tableType;

			public unsafe byte* dictionary;

			public unsafe LZ4_stream_t* dictCtx;

			public uint dictSize;
		}

		public struct LZ4_streamDecode_t
		{
			public unsafe byte* externalDict;

			public uint extDictSize;

			public unsafe byte* prefixEnd;

			public uint prefixSize;
		}

		public enum limitedOutput_directive
		{
			notLimited = 0,
			limitedOutput = 1,
			fillOutput = 2
		}

		public enum tableType_t
		{
			clearedTable = 0,
			byPtr = 1,
			byU32 = 2,
			byU16 = 3
		}

		public enum dict_directive
		{
			noDict = 0,
			withPrefix64k = 1,
			usingExtDict = 2,
			usingDictCtx = 3
		}

		public enum dictIssue_directive
		{
			noDictIssue = 0,
			dictSmall = 1
		}

		public enum endCondition_directive
		{
			endOnOutputSize = 0,
			endOnInputSize = 1
		}

		public enum earlyEnd_directive
		{
			full = 0,
			partial = 1
		}

		protected enum variable_length_error
		{
			loop_error = -2,
			initial_error = -1,
			ok = 0
		}

		public enum dictCtx_directive
		{
			noDictCtx = 0,
			usingDictCtxHc = 1
		}

		public struct LZ4_streamHC_t
		{
			public unsafe fixed uint hashTable[32768];

			public unsafe fixed ushort chainTable[65536];

			public unsafe byte* end;

			public unsafe byte* @base;

			public unsafe byte* dictBase;

			public uint dictLimit;

			public uint lowLimit;

			public uint nextToUpdate;

			public short compressionLevel;

			public bool favorDecSpeed;

			public bool dirty;

			public unsafe LZ4_streamHC_t* dictCtx;
		}

		protected enum repeat_state_e
		{
			rep_untested = 0,
			rep_not = 1,
			rep_confirmed = 2
		}

		public enum HCfavor_e
		{
			favorCompressionRatio = 0,
			favorDecompressionSpeed = 1
		}

		public struct LZ4HC_match_t
		{
			public int off;

			public int len;
		}

		public struct LZ4HC_optimal_t
		{
			public int price;

			public int off;

			public int mlen;

			public int litlen;
		}

		public enum lz4hc_strat_e
		{
			lz4hc = 0,
			lz4opt = 1
		}

		public struct cParams_t
		{
			public lz4hc_strat_e strat;

			public uint nbSearches;

			public uint targetLength;

			public cParams_t(lz4hc_strat_e strat, uint nbSearches, uint targetLength)
			{
				this.strat = default(lz4hc_strat_e);
				this.nbSearches = 0u;
				this.targetLength = 0u;
			}
		}

		private static readonly uint[] _inc32table;

		private static readonly int[] _dec64table;

		protected unsafe static readonly uint* inc32table;

		protected unsafe static readonly int* dec64table;

		protected const int LZ4_MEMORY_USAGE = 14;

		protected const int LZ4_MAX_INPUT_SIZE = 2113929216;

		protected const int LZ4_DISTANCE_MAX = 65535;

		protected const int LZ4_DISTANCE_ABSOLUTE_MAX = 65535;

		protected const int LZ4_HASHLOG = 12;

		protected const int LZ4_HASHTABLESIZE = 16384;

		protected const int LZ4_HASH_SIZE_U32 = 4096;

		protected const int ACCELERATION_DEFAULT = 1;

		protected const int MINMATCH = 4;

		protected const int WILDCOPYLENGTH = 8;

		protected const int LASTLITERALS = 5;

		protected const int MFLIMIT = 12;

		protected const int MATCH_SAFEGUARD_DISTANCE = 12;

		protected const int FASTLOOP_SAFE_DISTANCE = 64;

		protected const int LZ4_minLength = 13;

		protected const int KB = 1024;

		protected const int MB = 1048576;

		protected const uint GB = 1073741824u;

		protected const int ML_BITS = 4;

		protected const uint ML_MASK = 15u;

		protected const int RUN_BITS = 4;

		protected const uint RUN_MASK = 15u;

		protected const int OPTIMAL_ML = 18;

		protected const int LZ4_OPT_NUM = 4096;

		protected const int LZ4_64Klimit = 65547;

		protected const int LZ4_skipTrigger = 6;

		protected const int LZ4HC_DICTIONARY_LOGSIZE = 16;

		protected const int LZ4HC_MAXD = 65536;

		protected const int LZ4HC_MAXD_MASK = 65535;

		protected const int LZ4HC_HASH_LOG = 15;

		protected const int LZ4HC_HASHTABLESIZE = 32768;

		protected const int LZ4HC_HASH_MASK = 32767;

		protected const int LZ4HC_CLEVEL_MIN = 3;

		protected const int LZ4HC_CLEVEL_DEFAULT = 9;

		protected const int LZ4HC_CLEVEL_OPT_MIN = 10;

		protected const int LZ4HC_CLEVEL_MAX = 12;

		public static bool Enforce32 { get; set; }

		public static Algorithm Algorithm
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(Algorithm);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int LZ4_sizeofStateHC()
		{
			return 0;
		}

		public unsafe static void LZ4_setCompressionLevel(LZ4_streamHC_t* LZ4_streamHCPtr, int compressionLevel)
		{
		}

		public unsafe static void LZ4_favorDecompressionSpeed(LZ4_streamHC_t* LZ4_streamHCPtr, int favor)
		{
		}

		public unsafe static LZ4_streamHC_t* LZ4_initStreamHC(void* buffer, int size)
		{
			return null;
		}

		public unsafe static LZ4_streamHC_t* LZ4_initStreamHC(LZ4_streamHC_t* stream)
		{
			return null;
		}

		public unsafe static void LZ4_resetStreamHC_fast(LZ4_streamHC_t* LZ4_streamHCPtr, int compressionLevel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint HASH_FUNCTION(uint value)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static ref ushort DELTANEXTU16(ushort* table, uint pos)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint LZ4HC_hashPtr(void* ptr)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void LZ4HC_Insert(LZ4_streamHC_t* hc4, byte* ip)
		{
		}

		public unsafe static void LZ4HC_setExternalDict(LZ4_streamHC_t* ctxPtr, byte* newBlock)
		{
		}

		public unsafe static void LZ4HC_clearTables(LZ4_streamHC_t* hc4)
		{
		}

		public unsafe static void LZ4HC_init_internal(LZ4_streamHC_t* hc4, byte* start)
		{
		}

		public unsafe static int LZ4_saveDictHC(LZ4_streamHC_t* LZ4_streamHCPtr, byte* safeBuffer, int dictSize)
		{
			return 0;
		}

		public unsafe static int LZ4_loadDictHC(LZ4_streamHC_t* LZ4_streamHCPtr, byte* dictionary, int dictSize)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint LZ4HC_rotl32(uint x, int r)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool LZ4HC_protectDictEnd(uint dictLimit, uint matchIndex)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int LZ4HC_countBack(byte* ip, byte* match, byte* iMin, byte* mMin)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint LZ4HC_reverseCountPattern(byte* ip, byte* iLow, uint pattern)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint LZ4HC_rotatePattern(uint rotate, uint pattern)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int LZ4HC_literalsPrice(int litlen)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int LZ4HC_sequencePrice(int litlen, int mlen)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public static void Assert(bool value, [CallerArgumentExpression("value")] string message = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int LZ4_compressBound(int isize)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int LZ4_decoderRingBufferSize(int isize)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static uint LZ4_hash4(uint sequence, tableType_t tableType)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static uint LZ4_hash5(ulong sequence, tableType_t tableType)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_clearHash(uint h, void* tableBase, tableType_t tableType)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_putIndexOnHash(uint idx, uint h, void* tableBase, tableType_t tableType)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static void LZ4_putPositionOnHash(byte* p, uint h, void* tableBase, tableType_t tableType, byte* srcBase)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_getIndexOnHash(uint h, void* tableBase, tableType_t tableType)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static byte* LZ4_getPositionOnHash(uint h, void* tableBase, tableType_t tableType, byte* srcBase)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int MIN(int a, int b)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint MIN(uint a, uint b)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint MAX(uint a, uint b)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long MAX(long a, long b)
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long MIN(long a, long b)
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected unsafe static uint LZ4_readVLE(byte** ip, byte* lencheck, bool loop_check, bool initial_check, variable_length_error* error)
		{
			return 0u;
		}

		public unsafe static int LZ4_saveDict(LZ4_stream_t* LZ4_dict, byte* safeBuffer, int dictSize)
		{
			return 0;
		}

		public unsafe static LZ4_stream_t* LZ4_initStream(LZ4_stream_t* buffer)
		{
			return null;
		}

		public unsafe static void LZ4_setStreamDecode(LZ4_streamDecode_t* LZ4_streamDecode, byte* dictionary, int dictSize)
		{
		}
	}
}
