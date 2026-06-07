namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class KeyAgreeRecipientIdentifier : Asn1Encodable, IAsn1Choice
	{
		private readonly IssuerAndSerialNumber issuerSerial;

		private readonly RecipientKeyIdentifier rKeyID;

		public IssuerAndSerialNumber IssuerAndSerialNumber => null;

		public RecipientKeyIdentifier RKeyID => null;

		public static KeyAgreeRecipientIdentifier GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static KeyAgreeRecipientIdentifier GetInstance(object obj)
		{
			return null;
		}

		public KeyAgreeRecipientIdentifier(IssuerAndSerialNumber issuerSerial)
		{
		}

		public KeyAgreeRecipientIdentifier(RecipientKeyIdentifier rKeyID)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
