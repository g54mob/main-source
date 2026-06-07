using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ess
{
	public class SigningCertificateV2 : Asn1Encodable
	{
		private readonly Asn1Sequence certs;

		private readonly Asn1Sequence policies;

		public static SigningCertificateV2 GetInstance(object o)
		{
			return null;
		}

		private SigningCertificateV2(Asn1Sequence seq)
		{
		}

		public SigningCertificateV2(EssCertIDv2 cert)
		{
		}

		public SigningCertificateV2(EssCertIDv2[] certs)
		{
		}

		public SigningCertificateV2(EssCertIDv2[] certs, PolicyInformation[] policies)
		{
		}

		public EssCertIDv2[] GetCerts()
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
