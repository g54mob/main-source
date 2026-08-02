namespace K4os.Compression.LZ4.Encoders
{
	public static class LZ4Encoder
	{
		public static ILZ4Encoder Create(bool chaining, LZ4Level level, int blockSize, int extraBlocks = 0)
		{
			return null;
		}

		private static ILZ4Encoder CreateBlockEncoder(LZ4Level level, int blockSize)
		{
			return null;
		}

		private static ILZ4Encoder CreateFastEncoder(int blockSize, int extraBlocks)
		{
			return null;
		}

		private static ILZ4Encoder CreateHighEncoder(LZ4Level level, int blockSize, int extraBlocks)
		{
			return null;
		}
	}
}
