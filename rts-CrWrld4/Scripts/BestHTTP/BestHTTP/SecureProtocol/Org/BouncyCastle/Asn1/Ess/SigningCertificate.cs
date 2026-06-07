using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ess
{
	public class SigningCertificate : Asn1Encodable
	{
		private Asn1Sequence certs;

		private Asn1Sequence policies;

		public static SigningCertificate GetInstance(object o)
		{
			return null;
		}

		public SigningCertificate(Asn1Sequence seq)
		{
		}

		public SigningCertificate(EssCertID essCertID)
		{
		}

		public EssCertID[] GetCerts()
		{
			return null;
		}

		public PolicyInformation[] GetPolicies()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
