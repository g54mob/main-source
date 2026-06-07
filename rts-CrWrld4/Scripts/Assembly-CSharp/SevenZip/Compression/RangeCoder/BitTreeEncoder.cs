namespace SevenZip.Compression.RangeCoder
{
	internal struct BitTreeEncoder
	{
		private BitEncoder[] Models;

		private int NumBitLevels;

		public BitTreeEncoder(int numBitLevels)
		{
			Models = null;
			NumBitLevels = 0;
		}

		public void Init()
		{
		}

		public void Encode(Encoder rangeEncoder, uint symbol)
		{
		}

		public void ReverseEncode(Encoder rangeEncoder, uint symbol)
		{
		}

		public uint GetPrice(uint symbol)
		{
			return 0u;
		}

		public uint ReverseGetPrice(uint symbol)
		{
			return 0u;
		}

		public static uint ReverseGetPrice(BitEncoder[] Models, uint startIndex, int NumBitLevels, uint symbol)
		{
			return 0u;
		}

		public static void ReverseEncode(BitEncoder[] Models, uint startIndex, Encoder rangeEncoder, int NumBitLevels, uint symbol)
		{
		}
	}
}
