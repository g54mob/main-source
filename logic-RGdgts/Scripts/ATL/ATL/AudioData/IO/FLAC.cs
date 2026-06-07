using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class FLAC : VorbisTagHolder, IMetaDataIO, IMetaData, IAudioDataIO
	{
		public static readonly byte[] FLAC_ID;

		private FlacHelper.FlacHeader header;

		private readonly string filePath;

		private AudioDataManager.SizeInfo sizeInfo;

		private IList<FileStructureHelper.Zone> zones;

		private long initialPaddingOffset;

		private long initialPaddingSize;

		private int sampleRate;

		private byte bitsPerSample;

		private long samples;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private long latestBlockOffset;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public override IList<Format> MetadataFormats => null;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected void resetData()
		{
		}

		public FLAC(string path, Format format)
		{
		}

		private bool isValid()
		{
			return false;
		}

		private double getDuration()
		{
			return 0.0;
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
