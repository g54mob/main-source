namespace SevenZip.Compression.RangeCoder
{
	internal struct BitEncoder
	{
		public const int kNumBitModelTotalBits = 11;

		public const uint kBitModelTotal = 2048u;

		private const int kNumMoveBits = 5;

		private const int kNumMoveReducingBits = 2;

		public const int kNumBitPriceShiftBits = 6;

		private uint Prob;

		private static uint[] ProbPrices;

		public void Init()
		{
		}

		public void UpdateModel(uint symbol)
		{
		}

		public void Encode(Encoder encoder, uint symbol)
		{
		}

		static BitEncoder()
		{
		}

		public uint GetPrice(uint symbol)
		{
			return 0u;
		}

		public uint GetPrice0()
		{
			return 0u;
		}

		public uint GetPrice1()
		{
			return 0u;
		}
	}
}
