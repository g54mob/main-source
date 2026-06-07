using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsContentInfoParser
	{
		protected ContentInfoParser contentInfo;

		protected Stream data;

		protected CmsContentInfoParser(Stream data)
		{
		}

		public void Close()
		{
		}
	}
}
