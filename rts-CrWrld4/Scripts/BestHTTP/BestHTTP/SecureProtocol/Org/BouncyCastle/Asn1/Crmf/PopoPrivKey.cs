namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class PopoPrivKey : Asn1Encodable, IAsn1Choice
	{
		public const int thisMessage = 0;

		public const int subsequentMessage = 1;

		public const int dhMAC = 2;

		public const int agreeMAC = 3;

		public const int encryptedKey = 4;

		private readonly int tagNo;

		private readonly Asn1Encodable obj;

		public virtual int Type => 0;

		public virtual Asn1Encodable Value => null;

		private PopoPrivKey(Asn1TaggedObject obj)
		{
		}

		public static PopoPrivKey GetInstance(Asn1TaggedObject tagged, bool isExplicit)
		{
			return null;
		}

		public PopoPrivKey(SubsequentMessage msg)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
