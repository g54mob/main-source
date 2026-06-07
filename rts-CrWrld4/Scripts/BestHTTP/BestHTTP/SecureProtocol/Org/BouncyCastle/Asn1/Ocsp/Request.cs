using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class Request : Asn1Encodable
	{
		private readonly CertID reqCert;

		private readonly X509Extensions singleRequestExtensions;

		public CertID ReqCert => null;

		public X509Extensions SingleRequestExtensions => null;

		public static Request GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static Request GetInstance(object obj)
		{
			return null;
		}

		public Request(CertID reqCert, X509Extensions singleRequestExtensions)
		{
		}

		private Request(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
