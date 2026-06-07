namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class CertStatus : Asn1Encodable, IAsn1Choice
	{
		private readonly int tagNo;

		private readonly Asn1Encodable value;

		public int TagNo => 0;

		public Asn1Encodable Status => null;

		public CertStatus()
		{
		}

		public CertStatus(RevokedInfo info)
		{
		}

		public CertStatus(int tagNo, Asn1Encodable value)
		{
		}

		public CertStatus(Asn1TaggedObject choice)
		{
		}

		public static CertStatus GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
