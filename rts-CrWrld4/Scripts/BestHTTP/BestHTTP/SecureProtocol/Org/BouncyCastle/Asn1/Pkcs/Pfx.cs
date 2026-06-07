namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class Pfx : Asn1Encodable
	{
		private readonly ContentInfo contentInfo;

		private readonly MacData macData;

		public ContentInfo AuthSafe => null;

		public MacData MacData => null;

		public static Pfx GetInstance(object obj)
		{
			return null;
		}

		public Pfx(Asn1Sequence seq)
		{
		}

		public Pfx(ContentInfo contentInfo, MacData macData)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
