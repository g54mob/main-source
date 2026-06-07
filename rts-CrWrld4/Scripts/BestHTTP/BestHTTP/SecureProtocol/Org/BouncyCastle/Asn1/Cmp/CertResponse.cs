namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CertResponse : Asn1Encodable
	{
		private readonly DerInteger certReqId;

		private readonly PkiStatusInfo status;

		private readonly CertifiedKeyPair certifiedKeyPair;

		private readonly Asn1OctetString rspInfo;

		public virtual DerInteger CertReqID => null;

		public virtual PkiStatusInfo Status => null;

		public virtual CertifiedKeyPair CertifiedKeyPair => null;

		private CertResponse(Asn1Sequence seq)
		{
		}

		public static CertResponse GetInstance(object obj)
		{
			return null;
		}

		public CertResponse(DerInteger certReqId, PkiStatusInfo status)
		{
		}

		public CertResponse(DerInteger certReqId, PkiStatusInfo status, CertifiedKeyPair certifiedKeyPair, Asn1OctetString rspInfo)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
