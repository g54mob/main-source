using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class CertTemplate : Asn1Encodable
	{
		private readonly Asn1Sequence seq;

		private readonly DerInteger version;

		private readonly DerInteger serialNumber;

		private readonly AlgorithmIdentifier signingAlg;

		private readonly X509Name issuer;

		private readonly OptionalValidity validity;

		private readonly X509Name subject;

		private readonly SubjectPublicKeyInfo publicKey;

		private readonly DerBitString issuerUID;

		private readonly DerBitString subjectUID;

		private readonly X509Extensions extensions;

		public virtual int Version => 0;

		public virtual DerInteger SerialNumber => null;

		public virtual AlgorithmIdentifier SigningAlg => null;

		public virtual X509Name Issuer => null;

		public virtual OptionalValidity Validity => null;

		public virtual X509Name Subject => null;

		public virtual SubjectPublicKeyInfo PublicKey => null;

		public virtual DerBitString IssuerUID => null;

		public virtual DerBitString SubjectUID => null;

		public virtual X509Extensions Extensions => null;

		private CertTemplate(Asn1Sequence seq)
		{
		}

		public static CertTemplate GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
