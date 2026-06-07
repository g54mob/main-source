namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class RecipientIdentifier : Asn1Encodable, IAsn1Choice
	{
		private Asn1Encodable id;

		public bool IsTagged => false;

		public Asn1Encodable ID => null;

		public RecipientIdentifier(IssuerAndSerialNumber id)
		{
		}

		public RecipientIdentifier(Asn1OctetString id)
		{
		}

		public RecipientIdentifier(Asn1Object id)
		{
		}

		public static RecipientIdentifier GetInstance(object o)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
