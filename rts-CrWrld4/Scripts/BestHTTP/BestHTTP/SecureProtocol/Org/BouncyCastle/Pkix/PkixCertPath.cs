using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixCertPath
	{
		internal static readonly IList certPathEncodings;

		private readonly IList certificates;

		public virtual IEnumerable Encodings => null;

		public virtual IList Certificates => null;

		static PkixCertPath()
		{
		}

		private static IList SortCerts(IList certs)
		{
			return null;
		}

		public PkixCertPath(ICollection certificates)
		{
		}

		public PkixCertPath(Stream inStream)
		{
		}

		public PkixCertPath(Stream inStream, string encoding)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public virtual byte[] GetEncoded()
		{
			return null;
		}

		public virtual byte[] GetEncoded(string encoding)
		{
			return null;
		}

		private Asn1Object ToAsn1Object(X509Certificate cert)
		{
			return null;
		}

		private byte[] ToDerEncoded(Asn1Encodable obj)
		{
			return null;
		}
	}
}
