using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class X931SecureRandomBuilder
	{
		private readonly SecureRandom mRandom;

		private IEntropySourceProvider mEntropySourceProvider;

		private byte[] mDateTimeVector;

		public X931SecureRandomBuilder()
		{
		}

		public X931SecureRandomBuilder(SecureRandom entropySource, bool predictionResistant)
		{
		}

		public X931SecureRandomBuilder(IEntropySourceProvider entropySourceProvider)
		{
		}

		public X931SecureRandomBuilder SetDateTimeVector(byte[] dateTimeVector)
		{
			return null;
		}

		public X931SecureRandom Build(IBlockCipher engine, KeyParameter key, bool predictionResistant)
		{
			return null;
		}
	}
}
