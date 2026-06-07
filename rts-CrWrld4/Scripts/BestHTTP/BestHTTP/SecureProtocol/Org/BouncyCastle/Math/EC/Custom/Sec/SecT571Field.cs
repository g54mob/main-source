namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecT571Field
	{
		private const ulong M59 = 576460752303423487uL;

		private const ulong RM = 17256631552825064414uL;

		private static readonly ulong[] ROOT_Z;

		public static void Add(ulong[] x, ulong[] y, ulong[] z)
		{
		}

		private static void Add(ulong[] x, int xOff, ulong[] y, int yOff, ulong[] z, int zOff)
		{
		}

		private static void AddBothTo(ulong[] x, int xOff, ulong[] y, int yOff, ulong[] z, int zOff)
		{
		}

		public static void AddExt(ulong[] xx, ulong[] yy, ulong[] zz)
		{
		}

		public static void AddOne(ulong[] x, ulong[] z)
		{
		}

		private static void AddTo(ulong[] x, ulong[] z)
		{
		}

		public static ulong[] FromBigInteger(BigInteger x)
		{
			return null;
		}

		public static void HalfTrace(ulong[] x, ulong[] z)
		{
		}

		public static void Invert(ulong[] x, ulong[] z)
		{
		}

		public static void Multiply(ulong[] x, ulong[] y, ulong[] z)
		{
		}

		public static void MultiplyAddToExt(ulong[] x, ulong[] y, ulong[] zz)
		{
		}

		public static void Reduce(ulong[] xx, ulong[] z)
		{
		}

		public static void Reduce5(ulong[] z, int zOff)
		{
		}

		public static void Sqrt(ulong[] x, ulong[] z)
		{
		}

		public static void Square(ulong[] x, ulong[] z)
		{
		}

		public static void SquareAddToExt(ulong[] x, ulong[] zz)
		{
		}

		public static void SquareN(ulong[] x, int n, ulong[] z)
		{
		}

		public static uint Trace(ulong[] x)
		{
			return 0u;
		}

		protected static void ImplMultiply(ulong[] x, ulong[] y, ulong[] zz)
		{
		}

		protected static void ImplMulwAcc(ulong[] xs, ulong y, ulong[] z, int zOff)
		{
		}

		protected static void ImplSquare(ulong[] x, ulong[] zz)
		{
		}
	}
}
