namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class ProtectedPart : Asn1Encodable
	{
		private readonly PkiHeader header;

		private readonly PkiBody body;

		public virtual PkiHeader Header => null;

		public virtual PkiBody Body => null;

		private ProtectedPart(Asn1Sequence seq)
		{
		}

		public static ProtectedPart GetInstance(object obj)
		{
			return null;
		}

		public ProtectedPart(PkiHeader header, PkiBody body)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
