namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class AttributeCertificateInfo : Asn1Encodable
	{
		internal readonly DerInteger version;

		internal readonly Holder holder;

		internal readonly AttCertIssuer issuer;

		internal readonly AlgorithmIdentifier signature;

		internal readonly DerInteger serialNumber;

		internal readonly AttCertValidityPeriod attrCertValidityPeriod;

		internal readonly Asn1Sequence attributes;

		internal readonly DerBitString issuerUniqueID;

		internal readonly X509Extensions extensions;

		public DerInteger Version => null;

		public Holder Holder => null;

		public AttCertIssuer Issuer => null;

		public AlgorithmIdentifier Signature => null;

		public DerInteger SerialNumber => null;

		public AttCertValidityPeriod AttrCertValidityPeriod => null;

		public Asn1Sequence Attributes => null;

		public DerBitString IssuerUniqueID => null;

		public X509Extensions Extensions => null;

		public static AttributeCertificateInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static AttributeCertificateInfo GetInstance(object obj)
		{
			return null;
		}

		private AttributeCertificateInfo(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
