using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class WAV : MetaDataIO, IAudioDataIO, IMetaDataEmbedder
	{
		private static readonly byte[] HEADER_RIFF;

		private static readonly byte[] HEADER_RIFX;

		private static readonly byte[] HEADER_RF64;

		private ushort formatId;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private uint sampleRate;

		private uint bytesPerSecond;

		private ushort bitsPerSample;

		private long sampleNumber;

		private long headerSize;

		private double bitrate;

		private double duration;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private readonly Format audioFormat;

		private bool _isLittleEndian;

		private long id3v2Offset;

		private FileStructureHelper id3v2StructureHelper;

		private static IDictionary<string, TagData.Field> frameMapping;

		public Format AudioFormat => null;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		protected override bool isLittleEndian => false;

		public long HasEmbeddedID3v2 => 0L;

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		protected void resetData()
		{
		}

		public WAV(string filePath, Format format)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readWAV(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}

		private object getFormattedRiffChunkSize(long input, bool isRf64)
		{
			return null;
		}

		private string getFormat()
		{
			return null;
		}

		private double getDuration()
		{
			return 0.0;
		}

		private double getBitrate()
		{
			return 0.0;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, ReadTagParams readTagParams)
		{
			return false;
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
