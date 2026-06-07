namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ess
{
	public class ContentHints : Asn1Encodable
	{
		private readonly DerUtf8String contentDescription;

		private readonly DerObjectIdentifier contentType;

		public DerObjectIdentifier ContentType => null;

		public DerUtf8String ContentDescription => null;

		public static ContentHints GetInstance(object o)
		{
			return null;
		}

		private ContentHints(Asn1Sequence seq)
		{
		}

		public ContentHints(DerObjectIdentifier contentType)
		{
		}

		public ContentHints(DerObjectIdentifier contentType, DerUtf8String contentDescription)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
