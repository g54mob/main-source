namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class GenRepContent : Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private GenRepContent(Asn1Sequence seq)
		{
		}

		public static GenRepContent GetInstance(object obj)
		{
			return null;
		}

		public GenRepContent(params InfoTypeAndValue[] itv)
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
