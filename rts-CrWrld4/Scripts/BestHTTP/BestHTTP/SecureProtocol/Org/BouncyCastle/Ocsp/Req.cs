using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp
{
	public class Req : X509ExtensionBase
	{
		private Request req;

		public X509Extensions SingleRequestExtensions => null;

		public Req(Request req)
		{
		}

		public CertificateID GetCertID()
		{
			return null;
		}

		protected override X509Extensions GetX509Extensions()
		{
			return null;
		}
	}
}
