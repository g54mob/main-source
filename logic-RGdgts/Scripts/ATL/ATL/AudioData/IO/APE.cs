using System.IO;

namespace ATL.AudioData.IO
{
	internal class APE : IAudioDataIO
	{
		private sealed class ApeHeader
		{
			public byte[] cID;

			public ushort nVersion;
		}

		private struct ApeHeaderOld
		{
			public ushort nCompressionLevel;

			public ushort nFormatFlags;

			public ushort nChannels;

			public uint nSampleRate;

			public uint nHeaderBytes;

			public uint nTerminatingBytes;

			public uint nTotalFrames;

			public uint nFinalFrameBlocks;

			public int nInt;
		}

		private struct ApeHeaderNew
		{
			public ushort nCompressionLevel;

			public ushort nFormatFlags;

			public uint nBlocksPerFrame;

			public uint nFinalFrameBlocks;

			public uint nTotalFrames;

			public ushort nBitsPerSample;

			public ushort nChannels;

			public uint nSampleRate;
		}

		private sealed class ApeDescriptor
		{
			public ushort padded;

			public uint nDescriptorBytes;

			public uint nHeaderBytes;

			public uint nSeekTableBytes;

			public uint nHeaderDataBytes;

			public uint nAPEFrameDataBytes;

			public uint nAPEFrameDataBytesHigh;

			public uint nTerminatingDataBytes;

			public byte[] cFileMD5;
		}

		public static readonly string[] MONKEY_COMPRESSION;

		public static readonly string[] MONKEY_MODE;

		private static readonly byte[] FILE_HEADER;

		private readonly ApeHeader header;

		private int version;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private int sampleRate;

		private int bits;

		private uint peakLevel;

		private double peakLevelRatio;

		private long totalSamples;

		private int compressionMode;

		private string compressionModeStr;

		private int formatFlags;

		private bool hasPeakLevel;

		private bool hasSeekElements;

		private bool wavNotStored;

		private double bitrate;

		private double duration;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public double Duration => 0.0;

		public int BitDepth => 0;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected void resetData()
		{
		}

		public APE(string filePath, Format format)
		{
		}

		private void readCommonHeader(BufferedBinaryReader source)
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
