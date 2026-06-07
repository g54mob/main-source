using System.IO;

namespace ATL.AudioData.IO
{
	internal class DTS : IAudioDataIO
	{
		private static readonly int[] BITRATES;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private uint bits;

		private uint sampleRate;

		private double bitrate;

		private double duration;

		private readonly string filePath;

		public Format AudioFormat { get; }

		public bool IsVBR => false;

		public int CodecFamily => 0;

		public int SampleRate => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

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

		public DTS(string filePath, Format format)
		{
		}

		private ChannelsArrangements.ChannelsArrangement getChannelsArrangement(uint amode, bool isLfePresent)
		{
			return null;
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
