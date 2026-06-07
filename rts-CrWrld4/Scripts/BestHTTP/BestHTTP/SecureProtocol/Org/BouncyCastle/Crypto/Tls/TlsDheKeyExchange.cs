using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsDheKeyExchange : TlsDHKeyExchange
	{
		protected TlsSignerCredentials mServerCredentials;

		public TlsDheKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, DHParameters dhParameters)
			: base(0, null, null)
		{
		}

		public TlsDheKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, TlsDHVerifier dhVerifier, DHParameters dhParameters)
			: base(0, null, null)
		{
		}

		public override void ProcessServerCredentials(TlsCredentials serverCredentials)
		{
		}

		public override byte[] GenerateServerKeyExchange()
		{
			return null;
		}

		public override void ProcessServerKeyExchange(Stream input)
		{
		}

		protected virtual ISigner InitVerifyer(TlsSigner tlsSigner, SignatureAndHashAlgorithm algorithm, SecurityParameters securityParameters)
		{
			return null;
		}
	}
}
