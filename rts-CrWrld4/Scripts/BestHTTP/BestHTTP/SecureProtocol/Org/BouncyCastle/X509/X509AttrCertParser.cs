using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class X509AttrCertParser
	{
		private static readonly PemParser PemAttrCertParser;

		private Asn1Set sData;

		private int sDataObjectCount;

		private Stream currentStream;

		private IX509AttributeCertificate ReadDerCertificate(Asn1InputStream dIn)
		{
			return null;
		}

		private IX509AttributeCertificate GetCertificate()
		{
			return null;
		}

		private IX509AttributeCertificate ReadPemCertificate(Stream inStream)
		{
			return null;
		}

		public IX509AttributeCertificate ReadAttrCert(byte[] input)
		{
			return null;
		}

		public ICollection ReadAttrCerts(byte[] input)
		{
			return null;
		}

		public IX509AttributeCertificate ReadAttrCert(Stream inStream)
		{
			return null;
		}

		public ICollection ReadAttrCerts(Stream inStream)
		{
			return null;
		}
	}
}
