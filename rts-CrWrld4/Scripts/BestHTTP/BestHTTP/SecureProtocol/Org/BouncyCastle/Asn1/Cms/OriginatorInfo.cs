namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class OriginatorInfo : Asn1Encodable
	{
		private Asn1Set certs;

		private Asn1Set crls;

		public Asn1Set Certificates => null;

		public Asn1Set Crls => null;

		public OriginatorInfo(Asn1Set certs, Asn1Set crls)
		{
		}

		public OriginatorInfo(Asn1Sequence seq)
		{
		}

		public static OriginatorInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static OriginatorInfo GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
