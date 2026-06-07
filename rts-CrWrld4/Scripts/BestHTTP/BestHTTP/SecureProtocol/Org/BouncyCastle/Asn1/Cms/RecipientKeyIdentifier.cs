namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class RecipientKeyIdentifier : Asn1Encodable
	{
		private Asn1OctetString subjectKeyIdentifier;

		private DerGeneralizedTime date;

		private OtherKeyAttribute other;

		public Asn1OctetString SubjectKeyIdentifier => null;

		public DerGeneralizedTime Date => null;

		public OtherKeyAttribute OtherKeyAttribute => null;

		public RecipientKeyIdentifier(Asn1OctetString subjectKeyIdentifier, DerGeneralizedTime date, OtherKeyAttribute other)
		{
		}

		public RecipientKeyIdentifier(byte[] subjectKeyIdentifier)
		{
		}

		public RecipientKeyIdentifier(byte[] subjectKeyIdentifier, DerGeneralizedTime date, OtherKeyAttribute other)
		{
		}

		public RecipientKeyIdentifier(Asn1Sequence seq)
		{
		}

		public static RecipientKeyIdentifier GetInstance(Asn1TaggedObject ato, bool explicitly)
		{
			return null;
		}

		public static RecipientKeyIdentifier GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
