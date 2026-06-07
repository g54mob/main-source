namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.Ecc
{
	public class MQVuserKeyingMaterial : Asn1Encodable
	{
		private OriginatorPublicKey ephemeralPublicKey;

		private Asn1OctetString addedukm;

		public OriginatorPublicKey EphemeralPublicKey => null;

		public Asn1OctetString AddedUkm => null;

		public MQVuserKeyingMaterial(OriginatorPublicKey ephemeralPublicKey, Asn1OctetString addedukm)
		{
		}

		private MQVuserKeyingMaterial(Asn1Sequence seq)
		{
		}

		public static MQVuserKeyingMaterial GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static MQVuserKeyingMaterial GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
