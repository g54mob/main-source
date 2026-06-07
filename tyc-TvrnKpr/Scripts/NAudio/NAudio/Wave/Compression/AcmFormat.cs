namespace NAudio.Wave.Compression
{
	public class AcmFormat
	{
		private readonly AcmFormatDetails formatDetails;

		private readonly WaveFormat waveFormat;

		public int FormatIndex => 0;

		public WaveFormatEncoding FormatTag => default(WaveFormatEncoding);

		public AcmDriverDetailsSupportFlags SupportFlags => default(AcmDriverDetailsSupportFlags);

		public WaveFormat WaveFormat => null;

		public int WaveFormatByteSize => 0;

		public string FormatDescription => null;

		internal AcmFormat(AcmFormatDetails formatDetails)
		{
		}
	}
}
