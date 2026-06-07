using System.IO;
using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;

namespace SevenZip.Compression.LZMA
{
	public class Decoder : ICoder, ISetDecoderProperties
	{
		private class LenDecoder
		{
			private BitDecoder m_Choice;

			private BitDecoder m_Choice2;

			private BitTreeDecoder[] m_LowCoder;

			private BitTreeDecoder[] m_MidCoder;

			private BitTreeDecoder m_HighCoder;

			private uint m_NumPosStates;

			public void Create(uint numPosStates)
			{
			}

			public void Init()
			{
			}

			public uint Decode(SevenZip.Compression.RangeCoder.Decoder rangeDecoder, uint posState)
			{
				return 0u;
			}
		}

		private class LiteralDecoder
		{
			private struct Decoder2
			{
				private BitDecoder[] m_Decoders;

				public void Create()
				{
				}

				public void Init()
				{
				}

				public byte DecodeNormal(SevenZip.Compression.RangeCoder.Decoder rangeDecoder)
				{
					return 0;
				}

				public byte DecodeWithMatchByte(SevenZip.Compression.RangeCoder.Decoder rangeDecoder, byte matchByte)
				{
					return 0;
				}
			}

			private Decoder2[] m_Coders;

			private int m_NumPrevBits;

			private int m_NumPosBits;

			private uint m_PosMask;

			public void Create(int numPosBits, int numPrevBits)
			{
			}

			public void Init()
			{
			}

			private uint GetState(uint pos, byte prevByte)
			{
				return 0u;
			}

			public byte DecodeNormal(SevenZip.Compression.RangeCoder.Decoder rangeDecoder, uint pos, byte prevByte)
			{
				return 0;
			}

			public byte DecodeWithMatchByte(SevenZip.Compression.RangeCoder.Decoder rangeDecoder, uint pos, byte prevByte, byte matchByte)
			{
				return 0;
			}
		}

		private OutWindow m_OutWindow;

		private SevenZip.Compression.RangeCoder.Decoder m_RangeDecoder;

		private BitDecoder[] m_IsMatchDecoders;

		private BitDecoder[] m_IsRepDecoders;

		private BitDecoder[] m_IsRepG0Decoders;

		private BitDecoder[] m_IsRepG1Decoders;

		private BitDecoder[] m_IsRepG2Decoders;

		private BitDecoder[] m_IsRep0LongDecoders;

		private BitTreeDecoder[] m_PosSlotDecoder;

		private BitDecoder[] m_PosDecoders;

		private BitTreeDecoder m_PosAlignDecoder;

		private LenDecoder m_LenDecoder;

		private LenDecoder m_RepLenDecoder;

		private LiteralDecoder m_LiteralDecoder;

		private uint m_DictionarySize;

		private uint m_DictionarySizeCheck;

		private uint m_PosStateMask;

		private void SetDictionarySize(uint dictionarySize)
		{
		}

		private void SetLiteralProperties(int lp, int lc)
		{
		}

		private void SetPosBitsProperties(int pb)
		{
		}

		private void Init(Stream inStream, Stream outStream)
		{
		}

		public void Code(Stream inStream, Stream outStream, long inSize, long outSize, ICodeProgress progress)
		{
		}

		public void SetDecoderProperties(byte[] properties)
		{
		}
	}
}
