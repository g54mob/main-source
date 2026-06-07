using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class AA : MetaDataIO, IAudioDataIO
	{
		private sealed class TocEntry
		{
			public readonly long TocOffset;

			public readonly int Section;

			public readonly uint Offset;

			public readonly uint Size;

			public TocEntry(long tocOffset, int section, uint offset, uint size)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		private static Dictionary<string, TagData.Field> frameMapping;

		private string codec;

		private long tocOffset;

		private long tocSize;

		private readonly string fileName;

		private readonly Format audioFormat;

		private IDictionary<int, TocEntry> toc;

		public bool IsVBR => false;

		public Format AudioFormat => null;

		public int CodecFamily => 0;

		public double BitRate => 0.0;

		public double Duration => 0.0;

		public int SampleRate => 0;

		public int BitDepth => 0;

		public string FileName => null;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		protected override bool isLittleEndian => false;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

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

		public AA(string fileName, Format format)
		{
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		private double getDuration()
		{
			return 0.0;
		}

		private bool readHeader(BufferedBinaryReader source)
		{
			return false;
		}

		private IDictionary<int, TocEntry> readToc(BufferedBinaryReader s)
		{
			return null;
		}

		private static bool isSectionDeletable(int sectionId)
		{
			return false;
		}

		private void readTags(BufferedBinaryReader source, long offset, ReadTagParams readTagParams)
		{
		}

		private void readCover(BufferedBinaryReader source, long offset, PictureInfo.PIC_TYPE pictureType)
		{
		}

		private void readChapters(BufferedBinaryReader source, long offset, long size)
		{
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
