using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class SignerAttribute : Asn1Encodable
	{
		private Asn1Sequence claimedAttributes;

		private AttributeCertificate certifiedAttributes;

		public virtual Asn1Sequence ClaimedAttributes => null;

		public virtual AttributeCertificate CertifiedAttributes => null;

		public static SignerAttribute GetInstance(object obj)
		{
			return null;
		}

		private SignerAttribute(object obj)
		{
		}

		public SignerAttribute(Asn1Sequence claimedAttributes)
		{
		}

		public SignerAttribute(AttributeCertificate certifiedAttributes)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
