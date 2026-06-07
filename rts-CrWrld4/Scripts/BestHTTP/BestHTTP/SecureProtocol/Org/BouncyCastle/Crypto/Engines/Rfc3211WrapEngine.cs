using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class Rfc3211WrapEngine : IWrapper
	{
		private CbcBlockCipher engine;

		private ParametersWithIV param;

		private bool forWrapping;

		private SecureRandom rand;

		public virtual string AlgorithmName => null;

		public Rfc3211WrapEngine(IBlockCipher engine)
		{
		}

		public virtual void Init(bool forWrapping, ICipherParameters param)
		{
		}

		public virtual byte[] Wrap(byte[] inBytes, int inOff, int inLen)
		{
			return null;
		}

		public virtual byte[] Unwrap(byte[] inBytes, int inOff, int inLen)
		{
			return null;
		}
	}
}
