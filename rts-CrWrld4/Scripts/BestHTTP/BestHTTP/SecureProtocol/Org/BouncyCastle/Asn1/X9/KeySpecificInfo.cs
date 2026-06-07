namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class KeySpecificInfo : Asn1Encodable
	{
		private DerObjectIdentifier algorithm;

		private Asn1OctetString counter;

		public DerObjectIdentifier Algorithm => null;

		public Asn1OctetString Counter => null;

		public KeySpecificInfo(DerObjectIdentifier algorithm, Asn1OctetString counter)
		{
		}

		public KeySpecificInfo(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
