using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CompleteCertificateRefs : Asn1Encodable
	{
		private readonly Asn1Sequence otherCertIDs;

		public static CompleteCertificateRefs GetInstance(object obj)
		{
			return null;
		}

		private CompleteCertificateRefs(Asn1Sequence seq)
		{
		}

		public CompleteCertificateRefs(params OtherCertID[] otherCertIDs)
		{
		}

		public CompleteCertificateRefs(IEnumerable otherCertIDs)
		{
		}

		public OtherCertID[] GetOtherCertIDs()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
