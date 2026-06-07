using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	public class DummyTag : MetaDataHolder, IMetaDataIO, IMetaData
	{
		public override IList<Format> MetadataFormats => null;

		public bool Exists => false;

		public long Size => 0L;

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
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
