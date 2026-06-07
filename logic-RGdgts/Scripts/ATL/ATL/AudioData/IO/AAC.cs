using System.IO;

namespace ATL.AudioData.IO
{
	internal class AAC : IAudioDataIO
	{
		public static readonly string[] AAC_HEADER_TYPE;

		public static readonly string[] AAC_MPEG_VERSION;

		public static readonly string[] AAC_PROFILE;

		public static readonly string[] AAC_BITRATE_TYPE;

		private static readonly int[] SAMPLE_RATE;

		private byte headerTypeID;

		private byte bitrateTypeID;

		private double bitrate;

		private int sampleRate;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string fileName;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public double BitRate => 0.0;

		public double Duration => 0.0;

		public int SampleRate => 0;

		public int BitDepth => 0;

		public string FileName => null;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected void resetData()
		{
		}

		public AAC(string fileName, Format format)
		{
		}

		private double getDuration()
		{
			return 0.0;
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private static byte recognizeHeaderType(byte[] data)
		{
			return 0;
		}

		private byte recognizeHeaderType(Stream source)
		{
			return 0;
		}

		private void readADIF(Stream Source)
		{
		}

		private void readADTS(Stream source)
		{
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}

		protected bool read(Stream source, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
