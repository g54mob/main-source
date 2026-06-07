namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Djb
{
	internal class Curve25519Field
	{
		internal static readonly uint[] P;

		private const uint P7 = 2147483647u;

		private static readonly uint[] PExt;

		private const uint PInv = 19u;

		public static void Add(uint[] x, uint[] y, uint[] z)
		{
		}

		public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
		{
		}

		public static void AddOne(uint[] x, uint[] z)
		{
		}

		public static uint[] FromBigInteger(BigInteger x)
		{
			return null;
		}

		public static void Half(uint[] x, uint[] z)
		{
		}

		public static void Multiply(uint[] x, uint[] y, uint[] z)
		{
		}

		public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
		{
		}

		public static void Negate(uint[] x, uint[] z)
		{
		}

		public static void Reduce(uint[] xx, uint[] z)
		{
		}

		public static void Reduce27(uint x, uint[] z)
		{
		}

		public static void Square(uint[] x, uint[] z)
		{
		}

		public static void SquareN(uint[] x, int n, uint[] z)
		{
		}

		public static void Subtract(uint[] x, uint[] y, uint[] z)
		{
		}

		public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
		{
		}

		public static void Twice(uint[] x, uint[] z)
		{
		}

		private static uint AddPTo(uint[] z)
		{
			return 0u;
		}

		private static uint AddPExtTo(uint[] zz)
		{
			return 0u;
		}

		private static int SubPFrom(uint[] z)
		{
			return 0;
		}

		private static int SubPExtFrom(uint[] zz)
		{
			return 0;
		}
	}
}
