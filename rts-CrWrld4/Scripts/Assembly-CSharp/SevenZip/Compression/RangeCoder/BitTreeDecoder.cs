namespace SevenZip.Compression.RangeCoder
{
	internal struct BitTreeDecoder
	{
		private BitDecoder[] Models;

		private int NumBitLevels;

		public BitTreeDecoder(int numBitLevels)
		{
			Models = null;
			NumBitLevels = 0;
		}

		public void Init()
		{
		}

		public uint Decode(Decoder rangeDecoder)
		{
			return 0u;
		}

		public uint ReverseDecode(Decoder rangeDecoder)
		{
			return 0u;
		}

		public static uint ReverseDecode(BitDecoder[] Models, uint startIndex, Decoder rangeDecoder, int NumBitLevels)
		{
			return 0u;
		}
	}
}
