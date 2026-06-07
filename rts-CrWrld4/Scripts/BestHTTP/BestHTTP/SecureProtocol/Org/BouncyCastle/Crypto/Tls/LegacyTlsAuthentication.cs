using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class LegacyTlsAuthentication : TlsAuthentication
	{
		protected ICertificateVerifyer verifyer;

		protected IClientCredentialsProvider credProvider;

		protected Uri TargetUri;

		public LegacyTlsAuthentication(Uri targetUri, ICertificateVerifyer verifyer, IClientCredentialsProvider prov)
		{
		}

		public virtual void NotifyServerCertificate(Certificate serverCertificate)
		{
		}

		public virtual TlsCredentials GetClientCredentials(TlsContext context, CertificateRequest certificateRequest)
		{
			return null;
		}
	}
}
