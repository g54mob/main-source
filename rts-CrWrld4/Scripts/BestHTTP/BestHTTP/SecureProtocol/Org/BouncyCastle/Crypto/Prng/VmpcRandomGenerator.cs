namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class VmpcRandomGenerator : IRandomGenerator
	{
		private byte n;

		private byte[] P;

		private byte s;

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
	}
}
