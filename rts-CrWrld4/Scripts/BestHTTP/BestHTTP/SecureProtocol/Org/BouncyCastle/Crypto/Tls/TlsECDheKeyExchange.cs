using System.Collections;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsECDheKeyExchange : TlsECDHKeyExchange
	{
		protected TlsSignerCredentials mServerCredentials;

		public TlsECDheKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, int[] namedCurves, byte[] clientECPointFormats, byte[] serverECPointFormats)
			: base(0, null, null, null, null)
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

		public override void ValidateCertificateRequest(CertificateRequest certificateRequest)
		{
		}

		public override void ProcessClientCredentials(TlsCredentials clientCredentials)
		{
		}

		protected virtual ISigner InitVerifyer(TlsSigner tlsSigner, SignatureAndHashAlgorithm algorithm, SecurityParameters securityParameters)
		{
			return null;
		}
	}
}
