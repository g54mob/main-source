using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsCompressedData
	{
		internal ContentInfo contentInfo;

		public ContentInfo ContentInfo => null;

		public CmsCompressedData(byte[] compressedData)
		{
		}

		public CmsCompressedData(Stream compressedDataStream)
		{
		}

		public CmsCompressedData(ContentInfo contentInfo)
		{
		}

		public byte[] GetContent()
		{
			return null;
		}

		public byte[] GetContent(int limit)
		{
			return null;
		}

		public byte[] GetEncoded()
		{
			return null;
		}
	}
}
