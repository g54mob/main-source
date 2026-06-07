namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class ContentInfoParser
	{
		private DerObjectIdentifier contentType;

		private Asn1TaggedObjectParser content;

		public DerObjectIdentifier ContentType => null;

		public ContentInfoParser(Asn1SequenceParser seq)
		{
		}

		public IAsn1Convertible GetContent(int tag)
		{
			return null;
		}
	}
}
