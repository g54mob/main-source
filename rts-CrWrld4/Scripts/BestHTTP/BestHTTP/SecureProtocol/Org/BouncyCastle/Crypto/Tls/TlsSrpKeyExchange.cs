using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Srp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsSrpKeyExchange : AbstractTlsKeyExchange
	{
		protected TlsSigner mTlsSigner;

		protected TlsSrpGroupVerifier mGroupVerifier;

		protected byte[] mIdentity;

		protected byte[] mPassword;

		protected AsymmetricKeyParameter mServerPublicKey;

		protected Srp6GroupParameters mSrpGroup;

		protected Srp6Client mSrpClient;

		protected Srp6Server mSrpServer;

		protected BigInteger mSrpPeerCredentials;

		protected BigInteger mSrpVerifier;

		protected byte[] mSrpSalt;

		protected TlsSignerCredentials mServerCredentials;

		public override bool RequiresServerKeyExchange => false;

		protected static TlsSigner CreateSigner(int keyExchange)
		{
			return null;
		}

		public TlsSrpKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, byte[] identity, byte[] password)
			: base(0, null)
		{
		}

		public TlsSrpKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, TlsSrpGroupVerifier groupVerifier, byte[] identity, byte[] password)
			: base(0, null)
		{
		}

		public TlsSrpKeyExchange(int keyExchange, IList supportedSignatureAlgorithms, byte[] identity, TlsSrpLoginParameters loginParameters)
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

		protected virtual ISigner InitVerifyer(TlsSigner tlsSigner, SignatureAndHashAlgorithm algorithm, SecurityParameters securityParameters)
		{
			return null;
		}
	}
}
