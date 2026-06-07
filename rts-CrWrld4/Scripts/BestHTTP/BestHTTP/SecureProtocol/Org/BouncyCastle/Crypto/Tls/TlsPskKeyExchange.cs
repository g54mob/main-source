using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsPskKeyExchange : AbstractTlsKeyExchange
	{
		protected TlsPskIdentity mPskIdentity;

		protected TlsPskIdentityManager mPskIdentityManager;

		protected TlsDHVerifier mDHVerifier;

		protected DHParameters mDHParameters;

		protected int[] mNamedCurves;

		protected byte[] mClientECPointFormats;

		protected byte[] mServerECPointFormats;

		protected byte[] mPskIdentityHint;

		protected byte[] mPsk;

		protected DHPrivateKeyParameters mDHAgreePrivateKey;

		protected DHPublicKeyParameters mDHAgreePublicKey;

		protected ECPrivateKeyParameters mECAgreePrivateKey;

		protected ECPublicKeyParameters mECAgreePublicKey;

		protected AsymmetricKeyParameter mServerPublicKey;

		protected RsaKeyParameters mRsaServerPublicKey;

		protected TlsEncryptionCredentials mServerCredentials;

		protected byte[] mPremasterSecret;

		public override bool RequiresServerKeyExchange => false;

		public TlsPskKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, TlsPskIdentity pskIdentity, TlsPskIdentityManager pskIdentityManager, DHParameters dhParameters, int[] namedCurves, byte[] clientECPointFormats, byte[] serverECPointFormats)
			: base(0, null)
		{
		}

		public TlsPskKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, TlsPskIdentity pskIdentity, TlsPskIdentityManager pskIdentityManager, TlsDHVerifier dhVerifier, DHParameters dhParameters, int[] namedCurves, byte[] clientECPointFormats, byte[] serverECPointFormats)
			: base(0, null)
		{
		}

		public override void SkipServerCredentials()
		{
		}

		public override void ProcessServerCredentials(TlsCredentials serverCredentials)
		{
		}

		public override byte[] GenerateServerKeyExchange()
		{
			return null;
		}

		public override void ProcessServerCertificate(Certificate serverCertificate)
		{
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

		public override void ProcessClientKeyExchange(Stream input)
		{
		}

		public override byte[] GeneratePremasterSecret()
		{
			return null;
		}

		protected virtual byte[] GenerateOtherSecret(int pskLength)
		{
			return null;
		}

		protected virtual RsaKeyParameters ValidateRsaPublicKey(RsaKeyParameters key)
		{
			return null;
		}
	}
}
