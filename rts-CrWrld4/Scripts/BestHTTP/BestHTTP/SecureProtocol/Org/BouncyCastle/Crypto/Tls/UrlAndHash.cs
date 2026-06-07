using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class UrlAndHash
	{
		protected readonly string mUrl;

		protected readonly byte[] mSha1Hash;

		public virtual string Url => null;

		public virtual byte[] Sha1Hash => null;

		public UrlAndHash(string url, byte[] sha1Hash)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static UrlAndHash Parse(TlsContext context, Stream input)
		{
			return null;
		}
	}
}
