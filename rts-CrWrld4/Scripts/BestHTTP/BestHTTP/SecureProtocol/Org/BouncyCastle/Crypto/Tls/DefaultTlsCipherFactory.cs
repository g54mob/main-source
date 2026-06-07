using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public sealed class DefaultTlsCipherFactory : AbstractTlsCipherFactory
	{
		public override TlsCipher CreateCipher(TlsContext context, int encryptionAlgorithm, int macAlgorithm)
		{
			return null;
		}

		protected TlsBlockCipher CreateAESCipher(TlsContext context, int cipherKeySize, int macAlgorithm)
		{
			return null;
		}

		protected TlsBlockCipher CreateCamelliaCipher(TlsContext context, int cipherKeySize, int macAlgorithm)
		{
			return null;
		}

		protected TlsCipher CreateChaCha20Poly1305(TlsContext context)
		{
			return null;
		}

		protected TlsAeadCipher CreateCipher_Aes_Ccm(TlsContext context, int cipherKeySize, int macSize)
		{
			return null;
		}

		protected TlsAeadCipher CreateCipher_Aes_Gcm(TlsContext context, int cipherKeySize, int macSize)
		{
			return null;
		}

		protected TlsAeadCipher CreateCipher_Aes_Ocb(TlsContext context, int cipherKeySize, int macSize)
		{
			return null;
		}

		protected TlsAeadCipher CreateCipher_Camellia_Gcm(TlsContext context, int cipherKeySize, int macSize)
		{
			return null;
		}

		protected TlsBlockCipher CreateDesEdeCipher(TlsContext context, int macAlgorithm)
		{
			return null;
		}

		protected TlsNullCipher CreateNullCipher(TlsContext context, int macAlgorithm)
		{
			return null;
		}

		protected TlsStreamCipher CreateRC4Cipher(TlsContext context, int cipherKeySize, int macAlgorithm)
		{
			return null;
		}

		protected TlsBlockCipher CreateSeedCipher(TlsContext context, int macAlgorithm)
		{
			return null;
		}

		protected IBlockCipher CreateAesEngine()
		{
			return null;
		}

		protected IBlockCipher CreateCamelliaEngine()
		{
			return null;
		}

		protected IBlockCipher CreateAesBlockCipher()
		{
			return null;
		}

		protected IAeadBlockCipher CreateAeadBlockCipher_Aes_Ccm()
		{
			return null;
		}

		protected IAeadBlockCipher CreateAeadBlockCipher_Aes_Gcm()
		{
			return null;
		}

		protected IAeadBlockCipher CreateAeadBlockCipher_Aes_Ocb()
		{
			return null;
		}

		protected IAeadBlockCipher CreateAeadBlockCipher_Camellia_Gcm()
		{
			return null;
		}

		protected IBlockCipher CreateCamelliaBlockCipher()
		{
			return null;
		}

		protected IBlockCipher CreateDesEdeBlockCipher()
		{
			return null;
		}

		protected IStreamCipher CreateRC4StreamCipher()
		{
			return null;
		}

		protected IBlockCipher CreateSeedBlockCipher()
		{
			return null;
		}

		protected IDigest CreateHMacDigest(int macAlgorithm)
		{
			return null;
		}
	}
}
