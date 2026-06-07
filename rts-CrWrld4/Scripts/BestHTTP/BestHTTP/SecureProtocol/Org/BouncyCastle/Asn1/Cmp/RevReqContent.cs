namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class RevReqContent : Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private RevReqContent(Asn1Sequence seq)
		{
		}

		public static RevReqContent GetInstance(object obj)
		{
			return null;
		}

		public RevReqContent(params RevDetails[] revDetails)
		{
		}

		public virtual RevDetails[] ToRevDetailsArray()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
