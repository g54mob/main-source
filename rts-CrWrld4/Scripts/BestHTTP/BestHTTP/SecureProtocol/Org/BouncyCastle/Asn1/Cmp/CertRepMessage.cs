namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CertRepMessage : Asn1Encodable
	{
		private readonly Asn1Sequence caPubs;

		private readonly Asn1Sequence response;

		private CertRepMessage(Asn1Sequence seq)
		{
		}

		public static CertRepMessage GetInstance(object obj)
		{
			return null;
		}

		public CertRepMessage(CmpCertificate[] caPubs, CertResponse[] response)
		{
		}

		public virtual CmpCertificate[] GetCAPubs()
		{
			return null;
		}

		public virtual CertResponse[] GetResponse()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
