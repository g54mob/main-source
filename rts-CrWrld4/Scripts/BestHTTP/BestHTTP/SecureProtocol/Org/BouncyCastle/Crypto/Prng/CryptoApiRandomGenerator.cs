using System.Security.Cryptography;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class CryptoApiRandomGenerator : IRandomGenerator
	{
		private readonly RandomNumberGenerator rndProv;

		public CryptoApiRandomGenerator()
		{
		}

		public CryptoApiRandomGenerator(RandomNumberGenerator rng)
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
	}
}
