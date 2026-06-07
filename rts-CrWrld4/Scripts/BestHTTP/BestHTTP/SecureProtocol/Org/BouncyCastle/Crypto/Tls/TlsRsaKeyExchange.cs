using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsRsaKeyExchange : AbstractTlsKeyExchange
	{
		protected AsymmetricKeyParameter mServerPublicKey;

		protected RsaKeyParameters mRsaServerPublicKey;

		protected TlsEncryptionCredentials mServerCredentials;

		protected byte[] mPremasterSecret;

		public TlsRsaKeyExchange(IList supportedSignatureAlgorithms)
			: base(0, null)
		{
		}

		public override void SkipServerCredentials()
		{
		}

		public override void ProcessServerCredentials(TlsCredentials serverCredentials)
		{
		}

		public override void ProcessServerCertificate(Certificate serverCertificate)
		{
		}

		public override void ValidateCertificateRequest(CertificateRequest certificateRequest)
		{
		}

		public override void ProcessClientCredentials(TlsCredentials clientCredentials)
		{
		}

		public override void GenerateClientKeyExchange(Stream output)
		{
		}

		public override void ProcessClientKeyExchange(Stream input)
		{
		}

		public override byte[] GeneratePremasterSecret()
		{
			return null;
		}

		protected virtual RsaKeyParameters ValidateRsaPublicKey(RsaKeyParameters key)
		{
			return null;
		}
	}
}
