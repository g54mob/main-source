namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class OtherInfo : Asn1Encodable
	{
		private KeySpecificInfo keyInfo;

		private Asn1OctetString partyAInfo;

		private Asn1OctetString suppPubInfo;

		public KeySpecificInfo KeyInfo => null;

		public Asn1OctetString PartyAInfo => null;

		public Asn1OctetString SuppPubInfo => null;

		public OtherInfo(KeySpecificInfo keyInfo, Asn1OctetString partyAInfo, Asn1OctetString suppPubInfo)
		{
		}

		public OtherInfo(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
