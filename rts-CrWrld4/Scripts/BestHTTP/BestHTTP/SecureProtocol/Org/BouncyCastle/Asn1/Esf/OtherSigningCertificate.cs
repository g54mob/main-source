using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class OtherSigningCertificate : Asn1Encodable
	{
		private readonly Asn1Sequence certs;

		private readonly Asn1Sequence policies;

		public static OtherSigningCertificate GetInstance(object obj)
		{
			return null;
		}

		private OtherSigningCertificate(Asn1Sequence seq)
		{
		}

		public OtherSigningCertificate(params OtherCertID[] certs)
		{
		}

		public OtherSigningCertificate(OtherCertID[] certs, params PolicyInformation[] policies)
		{
		}

		public OtherSigningCertificate(IEnumerable certs)
		{
		}

		public OtherSigningCertificate(IEnumerable certs, IEnumerable policies)
		{
		}

		public OtherCertID[] GetCerts()
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
