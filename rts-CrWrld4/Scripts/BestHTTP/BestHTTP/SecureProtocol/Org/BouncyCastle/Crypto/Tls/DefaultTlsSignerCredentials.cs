namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class DefaultTlsSignerCredentials : AbstractTlsSignerCredentials
	{
		protected readonly TlsContext mContext;

		protected readonly Certificate mCertificate;

		protected readonly AsymmetricKeyParameter mPrivateKey;

		protected readonly SignatureAndHashAlgorithm mSignatureAndHashAlgorithm;

		protected readonly TlsSigner mSigner;

		public override Certificate Certificate => null;

		public override SignatureAndHashAlgorithm SignatureAndHashAlgorithm => null;

		public DefaultTlsSignerCredentials(TlsContext context, Certificate certificate, AsymmetricKeyParameter privateKey)
		{
		}

		public DefaultTlsSignerCredentials(TlsContext context, Certificate certificate, AsymmetricKeyParameter privateKey, SignatureAndHashAlgorithm signatureAndHashAlgorithm)
		{
		}

		public override byte[] GenerateCertificateSignature(byte[] hash)
		{
			return null;
		}
	}
}
