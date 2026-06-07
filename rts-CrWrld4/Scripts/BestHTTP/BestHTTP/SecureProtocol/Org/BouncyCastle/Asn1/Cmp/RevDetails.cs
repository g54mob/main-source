using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class RevDetails : Asn1Encodable
	{
		private readonly CertTemplate certDetails;

		private readonly X509Extensions crlEntryDetails;

		public virtual CertTemplate CertDetails => null;

		public virtual X509Extensions CrlEntryDetails => null;

		private RevDetails(Asn1Sequence seq)
		{
		}

		public static RevDetails GetInstance(object obj)
		{
			return null;
		}

		public RevDetails(CertTemplate certDetails)
		{
		}

		public RevDetails(CertTemplate certDetails, X509Extensions crlEntryDetails)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
