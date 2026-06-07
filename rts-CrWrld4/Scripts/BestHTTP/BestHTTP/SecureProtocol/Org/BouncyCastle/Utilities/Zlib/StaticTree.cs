namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Zlib
{
	internal sealed class StaticTree
	{
		private const int MAX_BITS = 15;

		private const int BL_CODES = 19;

		private const int D_CODES = 30;

		private const int LITERALS = 256;

		private const int LENGTH_CODES = 29;

		private const int L_CODES = 286;

		internal const int MAX_BL_BITS = 7;

		internal static readonly short[] static_ltree;

		internal static readonly short[] static_dtree;

		internal static readonly StaticTree static_l_desc;

		internal static readonly StaticTree static_d_desc;

		internal static readonly StaticTree static_bl_desc;

		internal short[] static_tree;

		internal int[] extra_bits;

		internal int extra_base;

		internal int elems;

		internal int max_length;

		internal StaticTree(short[] static_tree, int[] extra_bits, int extra_base, int elems, int max_length)
		{
		}
	}
}
