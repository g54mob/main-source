using System.Collections.Generic;

namespace ATL.AudioData.IO
{
	internal abstract class VorbisTagHolder : MetaDataHolder, IMetaData
	{
		protected VorbisTag vorbisTag;

		public bool Exists => false;

		public override IList<Format> MetadataFormats => null;

		public long Size => 0L;

		protected void createVorbisTag(bool writePicturesWithMetadata, bool writeMetadataFramingBit, bool hasCoreSignature, bool managePadding)
		{
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}
	}
}
