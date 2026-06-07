using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Icao
{
	public class CscaMasterList : Asn1Encodable
	{
		private DerInteger version;

		private X509CertificateStructure[] certList;

		public virtual int Version => 0;

		public static CscaMasterList GetInstance(object obj)
		{
			return null;
		}

		private CscaMasterList(Asn1Sequence seq)
		{
		}

		public CscaMasterList(X509CertificateStructure[] certStructs)
		{
		}

		public X509CertificateStructure[] GetCertStructs()
		{
			return null;
		}

		private static X509CertificateStructure[] CopyCertList(X509CertificateStructure[] orig)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
