using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class CertificationRequestInfo : Asn1Encodable
	{
		internal DerInteger version;

		internal X509Name subject;

		internal SubjectPublicKeyInfo subjectPKInfo;

		internal Asn1Set attributes;

		public DerInteger Version => null;

		public X509Name Subject => null;

		public SubjectPublicKeyInfo SubjectPublicKeyInfo => null;

		public Asn1Set Attributes => null;

		public static CertificationRequestInfo GetInstance(object obj)
		{
			return null;
		}

		public CertificationRequestInfo(X509Name subject, SubjectPublicKeyInfo pkInfo, Asn1Set attributes)
		{
		}

		private CertificationRequestInfo(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		private static void ValidateAttributes(Asn1Set attributes)
		{
		}
	}
}
