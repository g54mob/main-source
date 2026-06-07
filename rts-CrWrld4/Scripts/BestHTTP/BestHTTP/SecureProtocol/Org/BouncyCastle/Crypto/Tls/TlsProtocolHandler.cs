using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsProtocolHandler : TlsClientProtocol
	{
		public TlsProtocolHandler(Stream stream, SecureRandom secureRandom)
			: base(null, null)
		{
		}

		public TlsProtocolHandler(Stream input, Stream output, SecureRandom secureRandom)
			: base(null, null)
		{
		}
	}
}
