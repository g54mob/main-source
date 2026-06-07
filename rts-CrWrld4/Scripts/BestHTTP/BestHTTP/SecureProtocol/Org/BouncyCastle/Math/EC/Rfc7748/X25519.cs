using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Rfc7748
{
	public abstract class X25519
	{
		public const int PointSize = 32;

		public const int ScalarSize = 32;

		private const int C_A = 486662;

		private const int C_A24 = 121666;

		public static bool CalculateAgreement(byte[] k, int kOff, byte[] u, int uOff, byte[] r, int rOff)
		{
			return false;
		}

		private static uint Decode32(byte[] bs, int off)
		{
			return 0u;
		}

		private static void DecodeScalar(byte[] k, int kOff, uint[] n)
		{
		}

		public static void GeneratePrivateKey(SecureRandom random, byte[] k)
		{
		}

		public static void GeneratePublicKey(byte[] k, int kOff, byte[] r, int rOff)
		{
		}

		private static void PointDouble(int[] x, int[] z)
		{
		}

		public static void Precompute()
		{
		}

		public static void ScalarMult(byte[] k, int kOff, byte[] u, int uOff, byte[] r, int rOff)
		{
		}

		public static void ScalarMultBase(byte[] k, int kOff, byte[] r, int rOff)
		{
		}
	}
}
