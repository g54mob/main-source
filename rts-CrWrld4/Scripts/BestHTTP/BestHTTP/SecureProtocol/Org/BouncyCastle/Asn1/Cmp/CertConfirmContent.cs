namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CertConfirmContent : Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private CertConfirmContent(Asn1Sequence seq)
		{
		}

		public static CertConfirmContent GetInstance(object obj)
		{
			return null;
		}

		public virtual CertStatus[] ToCertStatusArray()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
