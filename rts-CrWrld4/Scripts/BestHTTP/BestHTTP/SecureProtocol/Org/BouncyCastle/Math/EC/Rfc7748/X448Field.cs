namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Rfc7748
{
	public abstract class X448Field
	{
		public const int Size = 16;

		private const uint M28 = 268435455u;

		public static void Add(uint[] x, uint[] y, uint[] z)
		{
		}

		public static void AddOne(uint[] z)
		{
		}

		public static void AddOne(uint[] z, int zOff)
		{
		}

		public static void Carry(uint[] z)
		{
		}

		public static void CMov(int cond, uint[] x, int xOff, uint[] z, int zOff)
		{
		}

		public static void CNegate(int negate, uint[] z)
		{
		}

		public static void Copy(uint[] x, int xOff, uint[] z, int zOff)
		{
		}

		public static uint[] Create()
		{
			return null;
		}

		public static void CSwap(int swap, uint[] a, uint[] b)
		{
		}

		public static void Decode(byte[] x, int xOff, uint[] z)
		{
		}

		private static uint Decode24(byte[] bs, int off)
		{
			return 0u;
		}

		private static uint Decode32(byte[] bs, int off)
		{
			return 0u;
		}

		private static void Decode56(byte[] bs, int off, uint[] z, int zOff)
		{
		}

		public static void Encode(uint[] x, byte[] z, int zOff)
		{
		}

		private static void Encode24(uint n, byte[] bs, int off)
		{
		}

		private static void Encode32(uint n, byte[] bs, int off)
		{
		}

		private static void Encode56(uint[] x, int xOff, byte[] bs, int off)
		{
		}

		public static void Inv(uint[] x, uint[] z)
		{
		}

		public static int IsZero(uint[] x)
		{
			return 0;
		}

		public static bool IsZeroVar(uint[] x)
		{
			return false;
		}

		public static void Mul(uint[] x, uint y, uint[] z)
		{
		}

		public static void Mul(uint[] x, uint[] y, uint[] z)
		{
		}

		public static void Negate(uint[] x, uint[] z)
		{
		}

		public static void Normalize(uint[] z)
		{
		}

		public static void One(uint[] z)
		{
		}

		private static void PowPm3d4(uint[] x, uint[] z)
		{
		}

		private static void Reduce(uint[] z, int x)
		{
		}

		public static void Sqr(uint[] x, uint[] z)
		{
		}

		public static void Sqr(uint[] x, int n, uint[] z)
		{
		}

		public static bool SqrtRatioVar(uint[] u, uint[] v, uint[] z)
		{
			return false;
		}

		public static void Sub(uint[] x, uint[] y, uint[] z)
		{
		}

		public static void SubOne(uint[] z)
		{
		}

		public static void Zero(uint[] z)
		{
		}
	}
}
