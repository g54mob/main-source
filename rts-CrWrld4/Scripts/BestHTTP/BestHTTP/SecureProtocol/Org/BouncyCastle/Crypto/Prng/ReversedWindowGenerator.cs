namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class ReversedWindowGenerator : IRandomGenerator
	{
		private readonly IRandomGenerator generator;

		private byte[] window;

		private int windowCount;

		public ReversedWindowGenerator(IRandomGenerator generator, int windowSize)
		{
		}

		public virtual void AddSeedMaterial(byte[] seed)
		{
		}

		public virtual void AddSeedMaterial(long seed)
		{
		}

		public virtual void NextBytes(byte[] bytes)
		{
		}

		public virtual void NextBytes(byte[] bytes, int start, int len)
		{
		}

		private void doNextBytes(byte[] bytes, int start, int len)
		{
		}
	}
}
