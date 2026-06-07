using System;
using System.Collections.Generic;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class LegacyTlsClient : DefaultTlsClient
	{
		public readonly Uri TargetUri;

		public readonly ICertificateVerifyer verifyer;

		public readonly IClientCredentialsProvider credProvider;

		public LegacyTlsClient(Uri targetUri, ICertificateVerifyer verifyer, IClientCredentialsProvider prov, List<string> hostNames, List<string> clientSupportedProtocols)
		{
		}

		public override TlsAuthentication GetAuthentication()
		{
			return null;
		}
	}
}
