using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities
{
	public abstract class BigIntegers
	{
		private const int MaxIterations = 1000;

		public static byte[] AsUnsignedByteArray(BigInteger n)
		{
			return null;
		}

		public static byte[] AsUnsignedByteArray(int length, BigInteger n)
		{
			return null;
		}

		public static BigInteger CreateRandomBigInteger(int bitLength, SecureRandom secureRandom)
		{
			return null;
		}

		public static BigInteger CreateRandomInRange(BigInteger min, BigInteger max, SecureRandom random)
		{
			return null;
		}

		public static int GetUnsignedByteLength(BigInteger n)
		{
			return 0;
		}
	}
}
