using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsCompressedDataParser : CmsContentInfoParser
	{
		public CmsCompressedDataParser(byte[] compressedData)
			: base(null)
		{
		}

		public CmsCompressedDataParser(Stream compressedData)
			: base(null)
		{
		}

		public CmsTypedStream GetContent()
		{
			return null;
		}
	}
}
