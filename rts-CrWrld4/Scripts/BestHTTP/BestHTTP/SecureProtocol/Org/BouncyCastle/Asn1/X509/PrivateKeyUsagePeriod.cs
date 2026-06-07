namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class PrivateKeyUsagePeriod : Asn1Encodable
	{
		private DerGeneralizedTime _notBefore;

		private DerGeneralizedTime _notAfter;

		public DerGeneralizedTime NotBefore => null;

		public DerGeneralizedTime NotAfter => null;

		public static PrivateKeyUsagePeriod GetInstance(object obj)
		{
			return null;
		}

		private PrivateKeyUsagePeriod(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
