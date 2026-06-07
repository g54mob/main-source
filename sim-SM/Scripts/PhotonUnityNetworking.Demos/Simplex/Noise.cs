namespace Simplex
{
	public class Noise
	{
		private static int seed;

		private static byte[] perm;

		private static readonly byte[] permOriginal;

		public static int Seed
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static float[] Calc1D(int width, float scale)
		{
			return null;
		}

		public static float[,] Calc2D(int width, int height, float scale)
		{
			return null;
		}

		public static float[,,] Calc3D(int width, int height, int length, float scale)
		{
			return null;
		}

		public static float CalcPixel1D(int x, float scale)
		{
			return 0f;
		}

		public static float CalcPixel2D(int x, int y, float scale)
		{
			return 0f;
		}

		public static float CalcPixel3D(int x, int y, int z, float scale)
		{
			return 0f;
		}

		static Noise()
		{
		}

		internal static float Generate(float x)
		{
			return 0f;
		}

		internal static float Generate(float x, float y)
		{
			return 0f;
		}

		internal static float Generate(float x, float y, float z)
		{
			return 0f;
		}

		private static int FastFloor(float x)
		{
			return 0;
		}

		private static int Mod(int x, int m)
		{
			return 0;
		}

		private static float grad(int hash, float x)
		{
			return 0f;
		}

		private static float grad(int hash, float x, float y)
		{
			return 0f;
		}

		private static float grad(int hash, float x, float y, float z)
		{
			return 0f;
		}

		private static float grad(int hash, float x, float y, float z, float t)
		{
			return 0f;
		}
	}
}
