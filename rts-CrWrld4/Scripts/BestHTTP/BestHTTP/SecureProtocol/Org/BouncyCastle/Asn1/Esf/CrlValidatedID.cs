namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CrlValidatedID : Asn1Encodable
	{
		private readonly OtherHash crlHash;

		private readonly CrlIdentifier crlIdentifier;

		public OtherHash CrlHash => null;

		public CrlIdentifier CrlIdentifier => null;

		public static CrlValidatedID GetInstance(object obj)
		{
			return null;
		}

		private CrlValidatedID(Asn1Sequence seq)
		{
		}

		public CrlValidatedID(OtherHash crlHash)
		{
		}

		public CrlValidatedID(OtherHash crlHash, CrlIdentifier crlIdentifier)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
