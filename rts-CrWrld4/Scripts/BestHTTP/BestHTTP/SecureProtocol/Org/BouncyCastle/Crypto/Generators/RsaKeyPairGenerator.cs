using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class RsaKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
	{
		private static readonly int[] SPECIAL_E_VALUES;

		private static readonly int SPECIAL_E_HIGHEST;

		private static readonly int SPECIAL_E_BITS;

		protected static readonly BigInteger One;

		protected static readonly BigInteger DefaultPublicExponent;

		protected const int DefaultTests = 100;

		protected RsaKeyGenerationParameters parameters;

		public virtual void Init(KeyGenerationParameters parameters)
		{
		}

		public virtual AsymmetricCipherKeyPair GenerateKeyPair()
		{
			return null;
		}

		protected virtual BigInteger ChooseRandomPrime(int bitlength, BigInteger e)
		{
			return null;
		}
	}
}
