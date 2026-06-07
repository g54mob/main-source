using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class TwinVQ : MetaDataIO, IAudioDataIO
	{
		private sealed class ChunkHeader
		{
			public string ID;

			public uint Size;
		}

		private sealed class HeaderInfo
		{
			public byte[] ID;

			public char[] Version;

			public uint Size;

			public ChunkHeader Common;

			public uint ChannelMode;

			public uint BitRate;

			public uint SampleRate;

			public uint SecurityLevel;
		}

		private static readonly byte[] TWIN_ID;

		private static IDictionary<string, TagData.Field> frameMapping;

		private int sampleRate;

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

		protected override bool isLittleEndian => false;

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		private void resetData()
		{
		}

		public TwinVQ(string filePath, Format format)
		{
		}

		private static bool readHeader(BufferedBinaryReader source, ref HeaderInfo Header)
		{
			return false;
		}

		private static ChannelsArrangements.ChannelsArrangement getChannelArrangement(HeaderInfo Header)
		{
			return null;
		}

		private static uint getBitRate(HeaderInfo Header)
		{
			return 0u;
		}

		private int GetSampleRate(HeaderInfo Header)
		{
			return 0;
		}

		private double getDuration(HeaderInfo Header)
		{
			return 0.0;
		}

		private static bool headerEndReached(ChunkHeader Chunk)
		{
			return false;
		}

		private void readTag(BufferedBinaryReader source, HeaderInfo Header, ReadTagParams readTagParams)
		{
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, ReadTagParams readTagParams)
		{
			return false;
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
