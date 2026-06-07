using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal class VorbisTag : MetaDataIO
	{
		public class VorbisMetaDataBlockPicture
		{
			public PictureInfo.PIC_TYPE picType;

			public int nativePicCode;

			public string mimeType;

			public string description;

			public int width;

			public int height;

			public int colorDepth;

			public int colorNum;

			public int picDataLength;

			public int picDataOffset;
		}

		private static readonly byte[] CORE_SIGNATURE;

		private static IDictionary<string, TagData.Field> frameMapping;

		private readonly bool writePicturesWithMetadata;

		private readonly bool writeMetadataFramingBit;

		private readonly bool hasCoreSignature;

		private readonly bool managePadding;

		private long initialTagOffset;

		private long initialPaddingOffset;

		private long initialPaddingSize;

		protected override byte ratingConvention => 0;

		public VorbisTag(bool writePicturesWithMetadata, bool writeMetadataFramingBit, bool hasCoreSignature, bool managePadding)
		{
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		public static VorbisMetaDataBlockPicture ReadMetadataBlockPicture(Stream s)
		{
			return null;
		}

		private void setChapterData(string fieldName, string fieldValue)
		{
		}

		private void SetPictureItem(Stream Source, string tagId, int size, ReadTagParams readTagParams)
		{
		}

		public void ReadPicture(Stream s, ReadTagParams readTagParams)
		{
		}

		public new void SetMetaField(string ID, string data, bool readAllMetaFrames, string zone = "default", byte tagVersion = 0, ushort streamNumber = 0, string language = "")
		{
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
