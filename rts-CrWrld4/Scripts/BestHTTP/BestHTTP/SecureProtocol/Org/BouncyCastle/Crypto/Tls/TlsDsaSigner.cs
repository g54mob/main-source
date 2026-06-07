namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class TlsDsaSigner : AbstractTlsSigner
	{
		protected abstract byte SignatureAlgorithm { get; }

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

		protected virtual ICipherParameters MakeInitParameters(bool forSigning, ICipherParameters cp)
		{
			return null;
		}

		protected virtual ISigner MakeSigner(SignatureAndHashAlgorithm algorithm, bool raw, bool forSigning, ICipherParameters cp)
		{
			return null;
		}

		protected abstract IDsa CreateDsaImpl(byte hashAlgorithm);
	}
}
