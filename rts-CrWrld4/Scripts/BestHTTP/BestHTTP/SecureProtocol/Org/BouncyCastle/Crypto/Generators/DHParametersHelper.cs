using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	internal class DHParametersHelper
	{
		private static readonly BigInteger Six;

		private static readonly int[][] primeLists;

		private static readonly int[] primeProducts;

		private static readonly BigInteger[] BigPrimeProducts;

		private static BigInteger[] ConstructBigPrimeProducts(int[] primeProducts)
		{
			return null;
		}

		internal static BigInteger[] GenerateSafePrimes(int size, int certainty, SecureRandom random)
		{
			return null;
		}

		internal static BigInteger SelectGenerator(BigInteger p, BigInteger q, SecureRandom random)
		{
			return null;
		}
	}
}
