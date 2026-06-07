namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class ScvpReqRes : Asn1Encodable
	{
		private readonly ContentInfo request;

		private readonly ContentInfo response;

		public virtual ContentInfo Request => null;

		public virtual ContentInfo Response => null;

		public static ScvpReqRes GetInstance(object obj)
		{
			return null;
		}

		private ScvpReqRes(Asn1Sequence seq)
		{
		}

		public ScvpReqRes(ContentInfo response)
		{
		}

		public ScvpReqRes(ContentInfo request, ContentInfo response)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
