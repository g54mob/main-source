namespace SevenZip.Compression.RangeCoder
{
	internal struct BitDecoder
	{
		public const int kNumBitModelTotalBits = 11;

		public const uint kBitModelTotal = 2048u;

		private const int kNumMoveBits = 5;

		private uint Prob;

		public void UpdateModel(int numMoveBits, uint symbol)
		{
		}

		public void Init()
		{
		}

		public uint Decode(Decoder rangeDecoder)
		{
			return 0u;
		}
	}
}
