namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class RsaEngine : IAsymmetricBlockCipher
	{
		private readonly IRsa core;

		public virtual string AlgorithmName => null;

		public RsaEngine()
		{
		}

		public RsaEngine(IRsa rsa)
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int GetInputBlockSize()
		{
			return 0;
		}

		public virtual int GetOutputBlockSize()
		{
			return 0;
		}

		public virtual byte[] ProcessBlock(byte[] inBuf, int inOff, int inLen)
		{
			return null;
		}
	}
}
