using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class SCrypt
	{
		public static byte[] Generate(byte[] P, byte[] S, int N, int r, int p, int dkLen)
		{
			return null;
		}

		private static byte[] MFcrypt(byte[] P, byte[] S, int N, int r, int p, int dkLen)
		{
			return null;
		}

		private static byte[] SingleIterationPBKDF2(byte[] P, byte[] S, int dkLen)
		{
			return null;
		}

		private static void SMix(uint[] B, int BOff, int N, int r)
		{
		}

		private static void BlockMix(uint[] B, uint[] X1, uint[] X2, uint[] Y, int r)
		{
		}

		private static void Xor(uint[] a, uint[] b, int bOff, uint[] output)
		{
		}

		private static void Clear(Array array)
		{
		}

		private static void ClearAll(params Array[] arrays)
		{
		}

		private static bool IsPowerOf2(int x)
		{
			return false;
		}
	}
}
