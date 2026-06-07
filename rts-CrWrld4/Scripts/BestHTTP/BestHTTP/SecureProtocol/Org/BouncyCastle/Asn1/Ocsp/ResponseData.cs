using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class ResponseData : Asn1Encodable
	{
		private static readonly DerInteger V1;

		private readonly bool versionPresent;

		private readonly DerInteger version;

		private readonly ResponderID responderID;

		private readonly DerGeneralizedTime producedAt;

		private readonly Asn1Sequence responses;

		private readonly X509Extensions responseExtensions;

		public DerInteger Version => null;

		public ResponderID ResponderID => null;

		public DerGeneralizedTime ProducedAt => null;

		public Asn1Sequence Responses => null;

		public X509Extensions ResponseExtensions => null;

		public static ResponseData GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static ResponseData GetInstance(object obj)
		{
			return null;
		}

		public ResponseData(DerInteger version, ResponderID responderID, DerGeneralizedTime producedAt, Asn1Sequence responses, X509Extensions responseExtensions)
		{
		}

		public ResponseData(ResponderID responderID, DerGeneralizedTime producedAt, Asn1Sequence responses, X509Extensions responseExtensions)
		{
		}

		private ResponseData(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
