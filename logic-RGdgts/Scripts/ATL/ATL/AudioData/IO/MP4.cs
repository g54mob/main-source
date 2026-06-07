using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class MP4 : MetaDataIO, IAudioDataIO
	{
		private sealed class MP4Sample
		{
			public double Duration;

			public uint Size;

			public uint ChunkIndex;

			public long ChunkOffset;

			public long RelativeOffset;
		}

		private static readonly byte[] FILE_HEADER;

		public static readonly string[] MP4_BITRATE_TYPE;

		private static readonly byte[] ILST_CORE_SIGNATURE;

		private static Dictionary<string, TagData.Field> frameMapping_mp4;

		private static ConcurrentDictionary<string, byte> frameClasses_mp4;

		private uint globalTimeScale;

		private readonly IDictionary<int, int> trackTimescales;

		private int qtChapterTextTrackId;

		private int qtChapterPictureTrackId;

		private long initialPaddingOffset;

		private uint initialPaddingSize;

		private byte[] chapterTextTrackEdits;

		private byte[] chapterPictureTrackEdits;

		private long udtaOffset;

		private byte bitrateTypeID;

		private double bitrate;

		private double calculatedDurationMs;

		private int sampleRate;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string fileName;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public int SampleRate => 0;

		public string FileName => null;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		protected override bool isLittleEndian => false;

		protected override byte ratingConvention => 0;

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

		public MP4(string fileName, Format format)
		{
		}

		private static void addFrameClass(string frameCode, byte frameClass)
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

		private bool recognizeHeaderType(BinaryReader Source)
		{
			return false;
		}

		private void readQTChapters(BinaryReader source, IList<MP4Sample> chapterTextTrackSamples, IList<MP4Sample> chapterPictureTrackSamples)
		{
		}

		private bool readMP4(BinaryReader source, ReadTagParams readTagParams)
		{
			return false;
		}

		private long readTrack(BinaryReader source, ReadTagParams readTagParams, int currentTrakIndex, IList<MP4Sample> chapterTextTrackSamples, IList<MP4Sample> chapterPictureTrackSamples, IDictionary<int, IList<int>> chapterTrackIndexes, IList<long> mediaTrackOffsets, long trackCounterOffset, long moovPosition, long moovSize)
		{
			return 0L;
		}

		private uint readQtChapter(BinaryReader source, ReadTagParams readTagParams, long stblPosition, long trakPosition, uint trakSize, int currentTrakIndex, long trackCounterOffset, IList<MP4Sample> chapterTrackSamples, int mediaTimeScale, bool isText)
		{
			return 0u;
		}

		private void readUserData(BinaryReader source, ReadTagParams readTagParams, long moovPosition, uint moovSize)
		{
		}

		private void readTag(BinaryReader source, ReadTagParams readTagParams)
		{
		}

		private void readXtraTag(BinaryReader source, ReadTagParams readTagParams, long atomDataSize)
		{
		}

		private void setXtraField(string ID, string data, bool readAllMetaFrames)
		{
		}

		private uint navigateToAtom(BinaryReader source, string atomKey)
		{
			return 0u;
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
