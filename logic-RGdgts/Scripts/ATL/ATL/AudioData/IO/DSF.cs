using System.IO;

namespace ATL.AudioData.IO
{
	internal class DSF : IAudioDataIO, IMetaDataEmbedder
	{
		private static readonly byte[] DSD_ID;

		private static readonly byte[] FMT_ID;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private uint bits;

		private uint sampleRate;

		private double bitrate;

		private double duration;

		private bool isValid;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private long id3v2Offset;

		private readonly FileStructureHelper id3v2StructureHelper;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long HasEmbeddedID3v2 => 0L;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected void resetData()
		{
		}

		public DSF(string filePath, Format format)
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
