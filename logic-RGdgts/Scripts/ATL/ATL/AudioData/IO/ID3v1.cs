using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	public class ID3v1 : MetaDataIO
	{
		public static readonly string[] MusicGenre;

		public override IList<Format> MetadataFormats => null;

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		private bool ReadTag(BufferedBinaryReader source)
		{
			return false;
		}

		private static byte GetTagVersion(byte[] endComment)
		{
			return 0;
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}
	}
}
