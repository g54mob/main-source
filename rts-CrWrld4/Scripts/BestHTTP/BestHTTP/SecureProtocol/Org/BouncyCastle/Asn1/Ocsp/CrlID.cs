namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class CrlID : Asn1Encodable
	{
		private readonly DerIA5String crlUrl;

		private readonly DerInteger crlNum;

		private readonly DerGeneralizedTime crlTime;

		public DerIA5String CrlUrl => null;

		public DerInteger CrlNum => null;

		public DerGeneralizedTime CrlTime => null;

		public CrlID(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
