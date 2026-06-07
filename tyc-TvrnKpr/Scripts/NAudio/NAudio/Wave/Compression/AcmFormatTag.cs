namespace NAudio.Wave.Compression
{
	public class AcmFormatTag
	{
		private AcmFormatTagDetails formatTagDetails;

		public int FormatTagIndex => 0;

		public WaveFormatEncoding FormatTag => default(WaveFormatEncoding);

		public int FormatSize => 0;

		public AcmDriverDetailsSupportFlags SupportFlags => default(AcmDriverDetailsSupportFlags);

		public int StandardFormatsCount => 0;

		public string FormatDescription => null;

		internal AcmFormatTag(AcmFormatTagDetails formatTagDetails)
		{
		}
	}
}
