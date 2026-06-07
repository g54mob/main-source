using System.Collections.Generic;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls;

namespace BestHTTP
{
	public delegate AbstractTlsClient TlsClientFactoryDelegate(HTTPRequest request, List<string> protocols);
}
