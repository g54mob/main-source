namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PollReqContent : Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private PollReqContent(Asn1Sequence seq)
		{
		}

		public static PollReqContent GetInstance(object obj)
		{
			return null;
		}

		public virtual DerInteger[][] GetCertReqIDs()
		{
			return null;
		}

		private static DerInteger[] SequenceToDerIntegerArray(Asn1Sequence seq)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
