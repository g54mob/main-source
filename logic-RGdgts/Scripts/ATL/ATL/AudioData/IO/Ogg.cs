using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class Ogg : VorbisTagHolder, IMetaDataIO, IMetaData, IAudioDataIO
	{
		private sealed class OggPageHeader
		{
			public byte[] ID;

			public byte StreamVersion;

			public byte TypeFlag;

			public ulong AbsolutePosition;

			public int StreamId;

			public int PageNumber;

			public uint Checksum;

			public byte Segments;

			public byte[] LacingValues;

			public long Offset;

			public OggPageHeader(int streamId = 0)
			{
			}

			public static OggPageHeader ReadFromStream(BufferedBinaryReader r)
			{
				return null;
			}

			public int GetPageSize()
			{
				return 0;
			}

			public int GetHeaderSize()
			{
				return 0;
			}

			public bool IsFirstPage()
			{
				return false;
			}
		}

		private sealed class VorbisHeader
		{
			public byte[] ID;

			public byte[] BitstreamVersion;

			public byte ChannelMode;

			public int SampleRate;

			public int BitRateMaximal;

			public int BitRateNominal;

			public int BitRateMinimal;

			public byte BlockSize;

			public byte StopFlag;

			public void Reset()
			{
			}
		}

		private sealed class OpusHeader
		{
			public byte[] ID;

			public byte Version;

			public byte OutputChannelCount;

			public ushort PreSkip;

			public uint InputSampleRate;

			public short OutputGain;

			public byte ChannelMappingFamily;

			public byte StreamCount;

			public byte CoupledStreamCount;

			public byte[] ChannelMapping;

			public void Reset()
			{
			}
		}

		private sealed class FileInfo
		{
			public int AudioStreamId;

			public VorbisHeader VorbisParameters;

			public OpusHeader OpusParameters;

			public FlacHelper.FlacHeader FlacParameters;

			public ulong Samples;

			public long CommentHeaderStart;

			public long CommentHeaderEnd;

			public int CommentHeaderSpanPages;

			public long SetupHeaderStart;

			public long SetupHeaderEnd;

			public int SetupHeaderSpanPages;

			public void Reset()
			{
			}
		}

		private static readonly byte[] OGG_PAGE_ID;

		private static readonly byte[] VORBIS_HEADER_ID;

		private static readonly byte[] VORBIS_COMMENT_ID;

		private static readonly byte[] VORBIS_SETUP_ID;

		private static readonly byte[] THEORA_HEADER_ID;

		private static readonly byte[] OPUS_HEADER_ID;

		private static readonly byte[] OPUS_TAG_ID;

		private static readonly byte[] FLAC_HEADER_ID;

		private readonly string filePath;

		private readonly Format audioFormat;

		private readonly FileInfo info;

		private int contents;

		private int bits;

		private int sampleRate;

		private ushort bitRateNominal;

		private ulong samples;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private AudioDataManager.SizeInfo sizeInfo;

		public int SampleRate => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public bool IsVBR => false;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public Format AudioFormat => null;

		public int CodecFamily => 0;

		public override IList<Format> MetadataFormats => null;

		protected void resetData()
		{
		}

		public Ogg(string filePath, Format format)
		{
		}

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		private ulong getSamples(BufferedBinaryReader source)
		{
			return 0uL;
		}

		private bool getInfo(BufferedBinaryReader source, FileInfo info, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private bool readIdentificationPacket(BufferedBinaryReader source)
		{
			return false;
		}

		private static void readCommentPacket(BufferedBinaryReader source, int contentType, VorbisTag tag, MetaDataIO.ReadTagParams readTagParams)
		{
		}

		private double getDuration()
		{
			return 0.0;
		}

		private double getBitRate()
		{
			return 0.0;
		}

		private static ChannelsArrangements.ChannelsArrangement getArrangementFromCode(int vorbisCode)
		{
			return null;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}

		public bool Read(Stream source, MetaDataIO.ReadTagParams readTagParams)
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
