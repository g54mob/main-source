using System.IO;
using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;

namespace SevenZip.Compression.LZMA
{
	public class Encoder : ICoder, ISetCoderProperties, IWriteCoderProperties
	{
		private enum EMatchFinderType
		{
			BT2 = 0,
			BT4 = 1
		}

		private class LiteralEncoder
		{
			public struct Encoder2
			{
				private BitEncoder[] m_Encoders;

				public void Create()
				{
				}

				public void Init()
				{
				}

				public void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, byte symbol)
				{
				}

				public void EncodeMatched(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, byte matchByte, byte symbol)
				{
				}

				public uint GetPrice(bool matchMode, byte matchByte, byte symbol)
				{
					return 0u;
				}
			}

			private Encoder2[] m_Coders;

			private int m_NumPrevBits;

			private int m_NumPosBits;

			private uint m_PosMask;

			public void Create(int numPosBits, int numPrevBits)
			{
			}

			public void Init()
			{
			}

			public Encoder2 GetSubCoder(uint pos, byte prevByte)
			{
				return default(Encoder2);
			}
		}

		private class LenEncoder
		{
			private BitEncoder _choice;

			private BitEncoder _choice2;

			private BitTreeEncoder[] _lowCoder;

			private BitTreeEncoder[] _midCoder;

			private BitTreeEncoder _highCoder;

			public void Init(uint numPosStates)
			{
			}

			public void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, uint symbol, uint posState)
			{
			}

			public void SetPrices(uint posState, uint numSymbols, uint[] prices, uint st)
			{
			}
		}

		private class LenPriceTableEncoder : LenEncoder
		{
			private uint[] _prices;

			private uint _tableSize;

			private uint[] _counters;

			public void SetTableSize(uint tableSize)
			{
			}

			public uint GetPrice(uint symbol, uint posState)
			{
				return 0u;
			}

			private void UpdateTable(uint posState)
			{
			}

			public void UpdateTables(uint numPosStates)
			{
			}

			public new void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, uint symbol, uint posState)
			{
			}
		}

		private class Optimal
		{
			public Base.State State;

			public bool Prev1IsChar;

			public bool Prev2;

			public uint PosPrev2;

			public uint BackPrev2;

			public uint Price;

			public uint PosPrev;

			public uint BackPrev;

			public uint Backs0;

			public uint Backs1;

			public uint Backs2;

			public uint Backs3;

			public void MakeAsChar()
			{
			}

			public void MakeAsShortRep()
			{
			}

			public bool IsShortRep()
			{
				return false;
			}
		}

		private const uint kIfinityPrice = 268435455u;

		private static byte[] g_FastPos;

		private Base.State _state;

		private byte _previousByte;

		private uint[] _repDistances;

		private const int kDefaultDictionaryLogSize = 22;

		private const uint kNumFastBytesDefault = 32u;

		private const uint kNumLenSpecSymbols = 16u;

		private const uint kNumOpts = 4096u;

		private Optimal[] _optimum;

		private IMatchFinder _matchFinder;

		private SevenZip.Compression.RangeCoder.Encoder _rangeEncoder;

		private BitEncoder[] _isMatch;

		private BitEncoder[] _isRep;

		private BitEncoder[] _isRepG0;

		private BitEncoder[] _isRepG1;

		private BitEncoder[] _isRepG2;

		private BitEncoder[] _isRep0Long;

		private BitTreeEncoder[] _posSlotEncoder;

		private BitEncoder[] _posEncoders;

		private BitTreeEncoder _posAlignEncoder;

		private LenPriceTableEncoder _lenEncoder;

		private LenPriceTableEncoder _repMatchLenEncoder;

		private LiteralEncoder _literalEncoder;

		private uint[] _matchDistances;

		private uint _numFastBytes;

		private uint _longestMatchLength;

		private uint _numDistancePairs;

		private uint _additionalOffset;

		private uint _optimumEndIndex;

		private uint _optimumCurrentIndex;

		private bool _longestMatchWasFound;

		private uint[] _posSlotPrices;

		private uint[] _distancesPrices;

		private uint[] _alignPrices;

		private uint _alignPriceCount;

		private uint _distTableSize;

		private int _posStateBits;

		private uint _posStateMask;

		private int _numLiteralPosStateBits;

		private int _numLiteralContextBits;

		private uint _dictionarySize;

		private uint _dictionarySizePrev;

		private uint _numFastBytesPrev;

		private long nowPos64;

		private bool _finished;

		private Stream _inStream;

		private EMatchFinderType _matchFinderType;

		private bool _writeEndMark;

		private bool _needReleaseMFStream;

		private uint[] reps;

		private uint[] repLens;

		private const int kPropSize = 5;

		private byte[] properties;

		private uint[] tempPrices;

		private uint _matchPriceCount;

		private static string[] kMatchFinderIDs;

		static Encoder()
		{
		}

		private static uint GetPosSlot(uint pos)
		{
			return 0u;
		}

		private static uint GetPosSlot2(uint pos)
		{
			return 0u;
		}

		private void BaseInit()
		{
		}

		private void Create()
		{
		}

		private void SetWriteEndMarkerMode(bool writeEndMarker)
		{
		}

		private void Init()
		{
		}

		private void ReadMatchDistances(out uint lenRes, out uint numDistancePairs)
		{
			lenRes = default(uint);
			numDistancePairs = default(uint);
		}

		private void MovePos(uint num)
		{
		}

		private uint GetRepLen1Price(Base.State state, uint posState)
		{
			return 0u;
		}

		private uint GetPureRepPrice(uint repIndex, Base.State state, uint posState)
		{
			return 0u;
		}

		private uint GetRepPrice(uint repIndex, uint len, Base.State state, uint posState)
		{
			return 0u;
		}

		private uint GetPosLenPrice(uint pos, uint len, uint posState)
		{
			return 0u;
		}

		private uint Backward(out uint backRes, uint cur)
		{
			backRes = default(uint);
			return 0u;
		}

		private uint GetOptimum(uint position, out uint backRes)
		{
			backRes = default(uint);
			return 0u;
		}

		private bool ChangePair(uint smallDist, uint bigDist)
		{
			return false;
		}

		private void WriteEndMarker(uint posState)
		{
		}

		private void Flush(uint nowPos)
		{
		}

		public void CodeOneBlock(out long inSize, out long outSize, out bool finished)
		{
			inSize = default(long);
			outSize = default(long);
			finished = default(bool);
		}

		private void ReleaseMFStream()
		{
		}

		private void SetOutStream(Stream outStream)
		{
		}

		private void ReleaseOutStream()
		{
		}

		private void ReleaseStreams()
		{
		}

		private void SetStreams(Stream inStream, Stream outStream, long inSize, long outSize)
		{
		}

		public void Code(Stream inStream, Stream outStream, long inSize, long outSize, ICodeProgress progress)
		{
		}

		public void WriteCoderProperties(Stream outStream)
		{
		}

		private void FillDistancesPrices()
		{
		}

		private void FillAlignPrices()
		{
		}

		private static int FindMatchFinder(string s)
		{
			return 0;
		}

		public void SetCoderProperties(CoderPropID[] propIDs, object[] properties)
		{
		}
	}
}
