using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng.Drbg;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class SP800SecureRandom : SecureRandom
	{
		private readonly IDrbgProvider mDrbgProvider;

		private readonly bool mPredictionResistant;

		private readonly SecureRandom mRandomSource;

		private readonly IEntropySource mEntropySource;

		private ISP80090Drbg mDrbg;

		internal SP800SecureRandom(SecureRandom randomSource, IEntropySource entropySource, IDrbgProvider drbgProvider, bool predictionResistant)
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

		public virtual void Reseed(byte[] additionalInput)
		{
		}
	}
}
