namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class GenMsgContent : Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private GenMsgContent(Asn1Sequence seq)
		{
		}

		public static GenMsgContent GetInstance(object obj)
		{
			return null;
		}

		public GenMsgContent(params InfoTypeAndValue[] itv)
		{
		}

		public virtual InfoTypeAndValue[] ToInfoTypeAndValueArray()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
