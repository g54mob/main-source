using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class X931SecureRandom : SecureRandom
	{
		private readonly bool mPredictionResistant;

		private readonly SecureRandom mRandomSource;

		private readonly X931Rng mDrbg;

		internal X931SecureRandom(SecureRandom randomSource, X931Rng drbg, bool predictionResistant)
		{
		}

		public override void SetSeed(byte[] seed)
		{
		}

		public override void SetSeed(long seed)
		{
		}

		public override void NextBytes(byte[] bytes)
		{
		}

		public override void NextBytes(byte[] buf, int off, int len)
		{
		}

		public override byte[] GenerateSeed(int numBytes)
		{
			return null;
		}
	}
}
