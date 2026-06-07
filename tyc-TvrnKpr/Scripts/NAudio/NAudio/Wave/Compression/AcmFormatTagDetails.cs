namespace NAudio.Wave.Compression
{
	internal struct AcmFormatTagDetails
	{
		public int structureSize;

		public int formatTagIndex;

		public int formatTag;

		public int formatSize;

		public AcmDriverDetailsSupportFlags supportFlags;

		public int standardFormatsCount;

		public string formatDescription;

		public const int FormatTagDescriptionChars = 48;
	}
}
