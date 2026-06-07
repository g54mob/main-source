namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class AttCertValidityPeriod : Asn1Encodable
	{
		private readonly DerGeneralizedTime notBeforeTime;

		private readonly DerGeneralizedTime notAfterTime;

		public DerGeneralizedTime NotBeforeTime => null;

		public DerGeneralizedTime NotAfterTime => null;

		public static AttCertValidityPeriod GetInstance(object obj)
		{
			return null;
		}

		public static AttCertValidityPeriod GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		private AttCertValidityPeriod(Asn1Sequence seq)
		{
		}

		public AttCertValidityPeriod(DerGeneralizedTime notBeforeTime, DerGeneralizedTime notAfterTime)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
