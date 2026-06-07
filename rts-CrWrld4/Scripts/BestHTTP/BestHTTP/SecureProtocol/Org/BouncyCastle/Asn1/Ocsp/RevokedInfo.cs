using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class RevokedInfo : Asn1Encodable
	{
		private readonly DerGeneralizedTime revocationTime;

		private readonly CrlReason revocationReason;

		public DerGeneralizedTime RevocationTime => null;

		public CrlReason RevocationReason => null;

		public static RevokedInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static RevokedInfo GetInstance(object obj)
		{
			return null;
		}

		public RevokedInfo(DerGeneralizedTime revocationTime)
		{
		}

		public RevokedInfo(DerGeneralizedTime revocationTime, CrlReason revocationReason)
		{
		}

		private RevokedInfo(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
