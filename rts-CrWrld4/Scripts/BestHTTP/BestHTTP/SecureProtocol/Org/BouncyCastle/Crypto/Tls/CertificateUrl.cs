using System.Collections;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class CertificateUrl
	{
		internal class ListBuffer16 : MemoryStream
		{
			internal ListBuffer16()
			{
			}

			internal void EncodeTo(Stream output)
			{
			}
		}

		protected readonly byte mType;

		protected readonly IList mUrlAndHashList;

		public virtual byte Type => 0;

		public virtual IList UrlAndHashList => null;

		public CertificateUrl(byte type, IList urlAndHashList)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static CertificateUrl parse(TlsContext context, Stream input)
		{
			return null;
		}
	}
}
