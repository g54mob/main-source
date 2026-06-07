namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	internal class X931Rng
	{
		private const long BLOCK64_RESEED_MAX = 32768L;

		private const long BLOCK128_RESEED_MAX = 8388608L;

		private const int BLOCK64_MAX_BITS_REQUEST = 4096;

		private const int BLOCK128_MAX_BITS_REQUEST = 262144;

		private readonly IBlockCipher mEngine;

		private readonly IEntropySource mEntropySource;

		private readonly byte[] mDT;

		private readonly byte[] mI;

		private readonly byte[] mR;

		private byte[] mV;

		private long mReseedCounter;

		internal IEntropySource EntropySource => null;

		internal X931Rng(IBlockCipher engine, byte[] dateTimeVector, IEntropySource entropySource)
		{
		}

		internal int Generate(byte[] output, bool predictionResistant)
		{
			return 0;
		}

		internal void Reseed()
		{
		}

		private void Process(byte[] res, byte[] a, byte[] b)
		{
		}

		private void Increment(byte[] val)
		{
		}

		private static bool IsTooLarge(byte[] bytes, int maxBytes)
		{
			return false;
		}
	}
}
