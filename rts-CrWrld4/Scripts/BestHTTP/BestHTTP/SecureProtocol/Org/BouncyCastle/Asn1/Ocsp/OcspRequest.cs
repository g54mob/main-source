namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class OcspRequest : Asn1Encodable
	{
		private readonly TbsRequest tbsRequest;

		private readonly Signature optionalSignature;

		public TbsRequest TbsRequest => null;

		public Signature OptionalSignature => null;

		public static OcspRequest GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static OcspRequest GetInstance(object obj)
		{
			return null;
		}

		public OcspRequest(TbsRequest tbsRequest, Signature optionalSignature)
		{
		}

		private OcspRequest(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
