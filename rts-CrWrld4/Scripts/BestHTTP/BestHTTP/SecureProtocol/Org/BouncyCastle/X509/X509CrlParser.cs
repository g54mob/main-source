using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class X509CrlParser
	{
		private static readonly PemParser PemCrlParser;

		private readonly bool lazyAsn1;

		private Asn1Set sCrlData;

		private int sCrlDataObjectCount;

		private Stream currentCrlStream;

		public X509CrlParser()
		{
		}

		public X509CrlParser(bool lazyAsn1)
		{
		}

		private X509Crl ReadPemCrl(Stream inStream)
		{
			return null;
		}

		private X509Crl ReadDerCrl(Asn1InputStream dIn)
		{
			return null;
		}

		private X509Crl GetCrl()
		{
			return null;
		}

		protected virtual X509Crl CreateX509Crl(CertificateList c)
		{
			return null;
		}

		public X509Crl ReadCrl(byte[] input)
		{
			return null;
		}

		public ICollection ReadCrls(byte[] input)
		{
			return null;
		}

		public X509Crl ReadCrl(Stream inStream)
		{
			return null;
		}

		public ICollection ReadCrls(Stream inStream)
		{
			return null;
		}
	}
}
