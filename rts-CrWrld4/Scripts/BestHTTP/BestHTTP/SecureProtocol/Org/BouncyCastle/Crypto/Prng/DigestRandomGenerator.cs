namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class DigestRandomGenerator : IRandomGenerator
	{
		private const long CYCLE_COUNT = 10L;

		private long stateCounter;

		private long seedCounter;

		private IDigest digest;

		private byte[] state;

		private byte[] seed;

		public DigestRandomGenerator(IDigest digest)
		{
		}

		public void AddSeedMaterial(byte[] inSeed)
		{
		}

		public void AddSeedMaterial(long rSeed)
		{
		}

		public void NextBytes(byte[] bytes)
		{
		}

		public void NextBytes(byte[] bytes, int start, int len)
		{
		}

		private void CycleSeed()
		{
		}

		private void GenerateState()
		{
		}

		private void DigestAddCounter(long seedVal)
		{
		}

		private void DigestUpdate(byte[] inSeed)
		{
		}

		private void DigestDoFinal(byte[] result)
		{
		}
	}
}
