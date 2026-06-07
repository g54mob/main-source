namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class KekIdentifier : Asn1Encodable
	{
		private Asn1OctetString keyIdentifier;

		private DerGeneralizedTime date;

		private OtherKeyAttribute other;

		public Asn1OctetString KeyIdentifier => null;

		public DerGeneralizedTime Date => null;

		public OtherKeyAttribute Other => null;

		public KekIdentifier(byte[] keyIdentifier, DerGeneralizedTime date, OtherKeyAttribute other)
		{
		}

		public KekIdentifier(Asn1Sequence seq)
		{
		}

		public static KekIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static KekIdentifier GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
