namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class AbstractTlsSigner : TlsSigner
	{
		protected TlsContext mContext;

		public virtual void Init(TlsContext context)
		{
		}

		public virtual byte[] GenerateRawSignature(AsymmetricKeyParameter privateKey, byte[] md5AndSha1)
		{
			return null;
		}

		public abstract byte[] GenerateRawSignature(SignatureAndHashAlgorithm algorithm, AsymmetricKeyParameter privateKey, byte[] hash);

		public virtual bool VerifyRawSignature(byte[] sigBytes, AsymmetricKeyParameter publicKey, byte[] md5AndSha1)
		{
			return false;
		}

		public abstract bool VerifyRawSignature(SignatureAndHashAlgorithm algorithm, byte[] sigBytes, AsymmetricKeyParameter publicKey, byte[] hash);

		public virtual ISigner CreateSigner(AsymmetricKeyParameter privateKey)
		{
			return null;
		}

		public abstract ISigner CreateSigner(SignatureAndHashAlgorithm algorithm, AsymmetricKeyParameter privateKey);

		public virtual ISigner CreateVerifyer(AsymmetricKeyParameter publicKey)
		{
			return null;
		}

		public abstract ISigner CreateVerifyer(SignatureAndHashAlgorithm algorithm, AsymmetricKeyParameter publicKey);

		public abstract bool IsValidPublicKey(AsymmetricKeyParameter publicKey);
	}
}
