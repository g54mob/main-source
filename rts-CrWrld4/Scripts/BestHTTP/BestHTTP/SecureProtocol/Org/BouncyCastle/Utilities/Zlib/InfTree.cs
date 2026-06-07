namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib
{
	internal sealed class InfTree
	{
		private const int MANY = 1440;

		private const int Z_OK = 0;

		private const int Z_STREAM_END = 1;

		private const int Z_NEED_DICT = 2;

		private const int Z_ERRNO = -1;

		private const int Z_STREAM_ERROR = -2;

		private const int Z_DATA_ERROR = -3;

		private const int Z_MEM_ERROR = -4;

		private const int Z_BUF_ERROR = -5;

		private const int Z_VERSION_ERROR = -6;

		private const int fixed_bl = 9;

		private const int fixed_bd = 5;

		private static readonly int[] fixed_tl;

		private static readonly int[] fixed_td;

		private static readonly int[] cplens;

		private static readonly int[] cplext;

		private static readonly int[] cpdist;

		private static readonly int[] cpdext;

		private const int BMAX = 15;

		private int[] hn;

		private int[] v;

		private int[] c;

		private int[] r;

		private int[] u;

		private int[] x;

		private int huft_build(int[] b, int bindex, int n, int s, int[] d, int[] e, int[] t, int[] m, int[] hp, int[] hn, int[] v)
		{
			return 0;
		}

		internal int inflate_trees_bits(int[] c, int[] bb, int[] tb, int[] hp, ZStream z)
		{
			return 0;
		}

		internal int inflate_trees_dynamic(int nl, int nd, int[] c, int[] bl, int[] bd, int[] tl, int[] td, int[] hp, ZStream z)
		{
			return 0;
		}

		internal static int inflate_trees_fixed(int[] bl, int[] bd, int[][] tl, int[][] td, ZStream z)
		{
			return 0;
		}

		private void initWorkArea(int vsize)
		{
		}
	}
}
