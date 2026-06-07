using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class NaccacheSternKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
	{
		private static readonly int[] smallPrimes;

		private NaccacheSternKeyGenerationParameters param;

		public void Init(KeyGenerationParameters parameters)
		{
		}

		public AsymmetricCipherKeyPair GenerateKeyPair()
		{
			return null;
		}

		private static BigInteger generatePrime(int bitLength, int certainty, SecureRandom rand)
		{
			return null;
		}

		private static IList permuteList(IList arr, SecureRandom rand)
		{
			return null;
		}

		private static IList findFirstPrimes(int count)
		{
			return null;
		}
	}
}
