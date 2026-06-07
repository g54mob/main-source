using System.IO;

namespace ATL.AudioData.IO
{
	internal class TAK : IAudioDataIO
	{
		public static readonly byte[] TAK_ID;

		private uint bits;

		private uint sampleRate;

		private double bitrate;

		private double duration;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private bool isValid;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

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

		private void resetData()
		{
		}

		public TAK(string filePath, Format format)
		{
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
