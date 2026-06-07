using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class NaccacheSternKeyGenerationParameters : KeyGenerationParameters
	{
		private readonly int certainty;

		private readonly int countSmallPrimes;

		public int Certainty => 0;

		public int CountSmallPrimes => 0;

		public bool IsDebug => false;

		public NaccacheSternKeyGenerationParameters(SecureRandom random, int strength, int certainty, int countSmallPrimes)
			: base(null, 0)
		{
		}

		public NaccacheSternKeyGenerationParameters(SecureRandom random, int strength, int certainty, int countSmallPrimes, bool debug)
			: base(null, 0)
		{
		}
	}
}
