using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class Rfc3394WrapEngine : IWrapper
	{
		private readonly IBlockCipher engine;

		private KeyParameter param;

		private bool forWrapping;

		private byte[] iv;

		public virtual string AlgorithmName => null;

		public Rfc3394WrapEngine(IBlockCipher engine)
		{
		}

		public virtual void Init(bool forWrapping, ICipherParameters parameters)
		{
		}

		public virtual byte[] Wrap(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		public virtual byte[] Unwrap(byte[] input, int inOff, int inLen)
		{
			return null;
		}
	}
}
