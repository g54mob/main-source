namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class ContentInfo : Asn1Encodable
	{
		private readonly DerObjectIdentifier contentType;

		private readonly Asn1Encodable content;

		public DerObjectIdentifier ContentType => null;

		public Asn1Encodable Content => null;

		public static ContentInfo GetInstance(object obj)
		{
			return null;
		}

		public static ContentInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		private ContentInfo(Asn1Sequence seq)
		{
		}

		public ContentInfo(DerObjectIdentifier contentType, Asn1Encodable content)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
