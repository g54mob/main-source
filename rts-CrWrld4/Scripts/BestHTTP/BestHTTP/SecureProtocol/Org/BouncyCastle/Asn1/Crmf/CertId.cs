using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class CertId : Asn1Encodable
	{
		private readonly GeneralName issuer;

		private readonly DerInteger serialNumber;

		public virtual GeneralName Issuer => null;

		public virtual DerInteger SerialNumber => null;

		private CertId(Asn1Sequence seq)
		{
		}

		public static CertId GetInstance(object obj)
		{
			return null;
		}

		public static CertId GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
