namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class GenericSigner : ISigner
	{
		private readonly IAsymmetricBlockCipher engine;

		private readonly IDigest digest;

		private bool forSigning;

		public virtual string AlgorithmName => null;

		public GenericSigner(IAsymmetricBlockCipher engine, IDigest digest)
		{
		}

		public virtual void Init(bool forSigning, ICipherParameters parameters)
		{
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		public virtual byte[] GenerateSignature()
		{
			return null;
		}

		public virtual bool VerifySignature(byte[] signature)
		{
			return false;
		}

		public virtual void Reset()
		{
		}
	}
}
