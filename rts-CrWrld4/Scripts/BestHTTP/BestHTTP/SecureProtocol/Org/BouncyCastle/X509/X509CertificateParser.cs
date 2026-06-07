using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class X509CertificateParser
	{
		private static readonly PemParser PemCertParser;

		private Asn1Set sData;

		private int sDataObjectCount;

		private Stream currentStream;

		private X509Certificate ReadDerCertificate(Asn1InputStream dIn)
		{
			return null;
		}

		private X509Certificate GetCertificate()
		{
			return null;
		}

		private X509Certificate ReadPemCertificate(Stream inStream)
		{
			return null;
		}

		protected virtual X509Certificate CreateX509Certificate(X509CertificateStructure c)
		{
			return null;
		}

		public X509Certificate ReadCertificate(byte[] input)
		{
			return null;
		}

		public ICollection ReadCertificates(byte[] input)
		{
			return null;
		}

		public X509Certificate ReadCertificate(Stream inStream)
		{
			return null;
		}

		public ICollection ReadCertificates(Stream inStream)
		{
			return null;
		}
	}
}
