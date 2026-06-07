namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class CertificatePair : Asn1Encodable
	{
		private X509CertificateStructure forward;

		private X509CertificateStructure reverse;

		public X509CertificateStructure Forward => null;

		public X509CertificateStructure Reverse => null;

		public static CertificatePair GetInstance(object obj)
		{
			return null;
		}

		private CertificatePair(Asn1Sequence seq)
		{
		}

		public CertificatePair(X509CertificateStructure forward, X509CertificateStructure reverse)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
