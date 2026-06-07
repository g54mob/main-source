using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Srp
{
	public class Srp6Utilities
	{
		public static BigInteger CalculateK(IDigest digest, BigInteger N, BigInteger g)
		{
			return null;
		}

		public static BigInteger CalculateU(IDigest digest, BigInteger N, BigInteger A, BigInteger B)
		{
			return null;
		}

		public static BigInteger CalculateX(IDigest digest, BigInteger N, byte[] salt, byte[] identity, byte[] password)
		{
			return null;
		}

		public static BigInteger GeneratePrivateValue(IDigest digest, BigInteger N, BigInteger g, SecureRandom random)
		{
			return null;
		}

		public static BigInteger ValidatePublicValue(BigInteger N, BigInteger val)
		{
			return null;
		}

		public static BigInteger CalculateM1(IDigest digest, BigInteger N, BigInteger A, BigInteger B, BigInteger S)
		{
			return null;
		}

		public static BigInteger CalculateM2(IDigest digest, BigInteger N, BigInteger A, BigInteger M1, BigInteger S)
		{
			return null;
		}

		public static BigInteger CalculateKey(IDigest digest, BigInteger N, BigInteger S)
		{
			return null;
		}

		private static BigInteger HashPaddedTriplet(IDigest digest, BigInteger N, BigInteger n1, BigInteger n2, BigInteger n3)
		{
			return null;
		}

		private static BigInteger HashPaddedPair(IDigest digest, BigInteger N, BigInteger n1, BigInteger n2)
		{
			return null;
		}

		private static byte[] GetPadded(BigInteger n, int length)
		{
			return null;
		}
	}
}
