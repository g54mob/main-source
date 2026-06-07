namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class CertReqMessages : Asn1Encodable
	{
		private readonly Asn1Sequence content;

		private CertReqMessages(Asn1Sequence seq)
		{
		}

		public static CertReqMessages GetInstance(object obj)
		{
			return null;
		}

		public CertReqMessages(params CertReqMsg[] msgs)
		{
		}

		public virtual CertReqMsg[] ToCertReqMsgArray()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
