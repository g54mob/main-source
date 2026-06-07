namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PkiBody : Asn1Encodable, IAsn1Choice
	{
		public const int TYPE_INIT_REQ = 0;

		public const int TYPE_INIT_REP = 1;

		public const int TYPE_CERT_REQ = 2;

		public const int TYPE_CERT_REP = 3;

		public const int TYPE_P10_CERT_REQ = 4;

		public const int TYPE_POPO_CHALL = 5;

		public const int TYPE_POPO_REP = 6;

		public const int TYPE_KEY_UPDATE_REQ = 7;

		public const int TYPE_KEY_UPDATE_REP = 8;

		public const int TYPE_KEY_RECOVERY_REQ = 9;

		public const int TYPE_KEY_RECOVERY_REP = 10;

		public const int TYPE_REVOCATION_REQ = 11;

		public const int TYPE_REVOCATION_REP = 12;

		public const int TYPE_CROSS_CERT_REQ = 13;

		public const int TYPE_CROSS_CERT_REP = 14;

		public const int TYPE_CA_KEY_UPDATE_ANN = 15;

		public const int TYPE_CERT_ANN = 16;

		public const int TYPE_REVOCATION_ANN = 17;

		public const int TYPE_CRL_ANN = 18;

		public const int TYPE_CONFIRM = 19;

		public const int TYPE_NESTED = 20;

		public const int TYPE_GEN_MSG = 21;

		public const int TYPE_GEN_REP = 22;

		public const int TYPE_ERROR = 23;

		public const int TYPE_CERT_CONFIRM = 24;

		public const int TYPE_POLL_REQ = 25;

		public const int TYPE_POLL_REP = 26;

		private int tagNo;

		private Asn1Encodable body;

		public virtual int Type => 0;

		public virtual Asn1Encodable Content => null;

		public static PkiBody GetInstance(object obj)
		{
			return null;
		}

		private PkiBody(Asn1TaggedObject tagged)
		{
		}

		public PkiBody(int type, Asn1Encodable content)
		{
		}

		private static Asn1Encodable GetBodyForType(int type, Asn1Encodable o)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
