using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class CertTemplateBuilder
	{
		private DerInteger version;

		private DerInteger serialNumber;

		private AlgorithmIdentifier signingAlg;

		private X509Name issuer;

		private OptionalValidity validity;

		private X509Name subject;

		private SubjectPublicKeyInfo publicKey;

		private DerBitString issuerUID;

		private DerBitString subjectUID;

		private X509Extensions extensions;

		public virtual CertTemplateBuilder SetVersion(int ver)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetSerialNumber(DerInteger ser)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetSigningAlg(AlgorithmIdentifier aid)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetIssuer(X509Name name)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetValidity(OptionalValidity v)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetSubject(X509Name name)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetPublicKey(SubjectPublicKeyInfo spki)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetIssuerUID(DerBitString uid)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetSubjectUID(DerBitString uid)
		{
			return null;
		}

		public virtual CertTemplateBuilder SetExtensions(X509Extensions extens)
		{
			return null;
		}

		public virtual CertTemplate Build()
		{
			return null;
		}

		private void AddOptional(Asn1EncodableVector v, int tagNo, bool isExplicit, Asn1Encodable obj)
		{
		}
	}
}
