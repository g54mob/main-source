namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class ResponseBytes : Asn1Encodable
	{
		private readonly DerObjectIdentifier responseType;

		private readonly Asn1OctetString response;

		public DerObjectIdentifier ResponseType => null;

		public Asn1OctetString Response => null;

		public static ResponseBytes GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static ResponseBytes GetInstance(object obj)
		{
			return null;
		}

		public ResponseBytes(DerObjectIdentifier responseType, Asn1OctetString response)
		{
		}

		private ResponseBytes(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
