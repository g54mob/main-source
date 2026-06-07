namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsRsaSigner : AbstractTlsSigner
	{
		public override byte[] GenerateRawSignature(SignatureAndHashAlgorithm algorithm, AsymmetricKeyParameter privateKey, byte[] hash)
		{
			return null;
		}

		public override bool VerifyRawSignature(SignatureAndHashAlgorithm algorithm, byte[] sigBytes, AsymmetricKeyParameter publicKey, byte[] hash)
		{
			return false;
		}

		public override ISigner CreateSigner(SignatureAndHashAlgorithm algorithm, AsymmetricKeyParameter privateKey)
		{
			return null;
		}

		public override ISigner CreateVerifyer(SignatureAndHashAlgorithm algorithm, AsymmetricKeyParameter publicKey)
		{
			return null;
		}

		public override bool IsValidPublicKey(AsymmetricKeyParameter publicKey)
		{
			return false;
		}

		protected virtual ISigner MakeSigner(SignatureAndHashAlgorithm algorithm, bool raw, bool forSigning, ICipherParameters cp)
		{
			return null;
		}

		protected virtual IAsymmetricBlockCipher CreateRsaImpl()
		{
			return null;
		}
	}
}
