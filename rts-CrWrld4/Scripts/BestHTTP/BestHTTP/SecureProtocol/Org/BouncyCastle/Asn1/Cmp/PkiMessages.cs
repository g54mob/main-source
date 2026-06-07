namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PkiMessages : Asn1Encodable
	{
		private Asn1Sequence content;

		private PkiMessages(Asn1Sequence seq)
		{
		}

		public static PkiMessages GetInstance(object obj)
		{
			return null;
		}

		public PkiMessages(params PkiMessage[] msgs)
		{
		}

		public virtual PkiMessage[] ToPkiMessageArray()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
