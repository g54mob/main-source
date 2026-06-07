using System.IO;

namespace ATL.AudioData.IO
{
	internal class OptimFrog : IAudioDataIO
	{
		public class TOfrHeader
		{
			public byte[] ID;

			public uint Size;

			public uint Length;

			public ushort HiLength;

			public byte SampleType;

			public byte ChannelMode;

			public int SampleRate;

			public ushort EncoderID;

			public byte CompressionID;

			public void Reset()
			{
			}
		}

		private static readonly byte[] OFR_SIGNATURE;

		private static readonly string[] OFR_COMPRESSION;

		private static readonly sbyte[] OFR_BITS;

		private readonly TOfrHeader header;

		private double bitrate;

		private double duration;

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

		public OptimFrog(string filePath, Format format)
		{
		}

		private long getSamples()
		{
			return 0L;
		}

		private double getDuration()
		{
			return 0.0;
		}

		private int getSampleRate()
		{
			return 0;
		}

		private double getBitrate()
		{
			return 0.0;
		}

		private sbyte getBits()
		{
			return 0;
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
