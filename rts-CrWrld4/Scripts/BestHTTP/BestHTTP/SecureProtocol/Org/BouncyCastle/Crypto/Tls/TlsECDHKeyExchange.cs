using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsECDHKeyExchange : AbstractTlsKeyExchange
	{
		protected TlsSigner mTlsSigner;

		protected int[] mNamedCurves;

		protected byte[] mClientECPointFormats;

		protected byte[] mServerECPointFormats;

		protected AsymmetricKeyParameter mServerPublicKey;

		protected TlsAgreementCredentials mAgreementCredentials;

		protected ECPrivateKeyParameters mECAgreePrivateKey;

		protected ECPublicKeyParameters mECAgreePublicKey;

		public override bool RequiresServerKeyExchange => false;

		public TlsECDHKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, int[] namedCurves, byte[] clientECPointFormats, byte[] serverECPointFormats)
			: base(0, null)
		{
		}

		public override void Init(TlsContext context)
		{
		}

		public override void SkipServerCredentials()
		{
		}

		public override void ProcessServerCertificate(Certificate serverCertificate)
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

		public override void GenerateClientKeyExchange(Stream output)
		{
		}

		public override void ProcessClientCertificate(Certificate clientCertificate)
		{
		}

		public override void ProcessClientKeyExchange(Stream input)
		{
		}

		public override byte[] GeneratePremasterSecret()
		{
			return null;
		}
	}
}
