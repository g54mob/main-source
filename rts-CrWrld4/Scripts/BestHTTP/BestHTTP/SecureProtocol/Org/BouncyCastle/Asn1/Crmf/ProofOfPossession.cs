namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class ProofOfPossession : Asn1Encodable, IAsn1Choice
	{
		public const int TYPE_RA_VERIFIED = 0;

		public const int TYPE_SIGNING_KEY = 1;

		public const int TYPE_KEY_ENCIPHERMENT = 2;

		public const int TYPE_KEY_AGREEMENT = 3;

		private readonly int tagNo;

		private readonly Asn1Encodable obj;

		public virtual int Type => 0;

		public virtual Asn1Encodable Object => null;

		private ProofOfPossession(Asn1TaggedObject tagged)
		{
		}

		public static ProofOfPossession GetInstance(object obj)
		{
			return null;
		}

		public ProofOfPossession()
		{
		}

		public ProofOfPossession(PopoSigningKey Poposk)
		{
		}

		public ProofOfPossession(int type, PopoPrivKey privkey)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
