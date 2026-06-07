using System;
using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class AIFF : MetaDataIO, IAudioDataIO, IMetaDataEmbedder
	{
		public class CommentData
		{
			public uint Timestamp;

			public short MarkerId;
		}

		private struct ChunkHeader
		{
			public string ID;

			public int Size;
		}

		public static readonly byte[] AIFF_CONTAINER_ID;

		private static DateTime timestampBase;

		private int bits;

		private string compression;

		private byte versionID;

		private int sampleRate;

		private double bitrate;

		private double duration;

		private ChannelsArrangements.ChannelsArrangement channelsArrangement;

		private bool isValid;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		private long id3v2Offset;

		private readonly FileStructureHelper id3v2StructureHelper;

		private static IDictionary<string, TagData.Field> frameMapping;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public string FileName => null;

		public int SampleRate => 0;

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

		private void resetData()
		{
		}

		public AIFF(string filePath, Format format)
		{
		}

		private ChunkHeader seekNextChunkHeader(BufferedBinaryReader source, long limit, string previousChunkId)
		{
			return default(ChunkHeader);
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
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
