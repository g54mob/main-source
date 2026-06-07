namespace NAudio.Codecs
{
	public static class MuLawEncoder
	{
		private const int cBias = 132;

		private const int cClip = 32635;

		private static readonly byte[] MuLawCompressTable;

		public static byte LinearToMuLawSample(short sample)
		{
			return 0;
		}
	}
}
