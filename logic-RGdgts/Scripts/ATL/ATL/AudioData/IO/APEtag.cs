using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	public class APEtag : MetaDataIO
	{
		private sealed class TagInfo
		{
			public char[] ID;

			public int Version;

			public int Size;

			public int FrameCount;

			public char[] Reserved;

			public byte DataShift;

			public long FileSize;

			public void Reset()
			{
			}
		}

		private static readonly IDictionary<string, TagData.Field> frameMapping;

		public override IList<Format> MetadataFormats => null;

		protected override byte ratingConvention => 0;

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		private bool readFooter(BufferedBinaryReader source, TagInfo Tag)
		{
			return false;
		}

		private bool readFrames(BufferedBinaryReader source, TagInfo Tag, ReadTagParams readTagParams)
		{
			return false;
		}

		private static PictureInfo.PIC_TYPE decodeAPEPictureType(string picCode)
		{
			return default(PictureInfo.PIC_TYPE);
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
