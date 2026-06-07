namespace NAudio.Codecs
{
	public static class ALawEncoder
	{
		private const int cBias = 132;

		private const int cClip = 32635;

		private static readonly byte[] ALawCompressTable;

		public static byte LinearToALawSample(short sample)
		{
			return 0;
		}
	}
}
