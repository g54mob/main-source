using BCnEncoder.Shared;

namespace BCnEncoder.Encoder
{
	internal static class ColorVariationGenerator
	{
		private static readonly int[] variatePatternEp0R = new int[24]
		{
			1, 1, 0, 0, -1, 0, 0, -1, 1, -1,
			1, 0, 0, -1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		};

		private static readonly int[] variatePatternEp0G = new int[24]
		{
			1, 0, 1, 0, 0, -1, 0, -1, 1, -1,
			0, 1, 0, 0, -1, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		};

		private static readonly int[] variatePatternEp0B = new int[24]
		{
			1, 0, 0, 1, 0, 0, -1, -1, 1, -1,
			0, 0, 1, 0, 0, -1, 0, 0, 0, 0,
			0, 0, 0, 0
		};

		private static readonly int[] variatePatternEp1R = new int[24]
		{
			-1, -1, 0, 0, 1, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0, 0, 1, -1, 1, 0,
			0, -1, 0, 0
		};

		private static readonly int[] variatePatternEp1G = new int[24]
		{
			-1, 0, -1, 0, 0, 1, 0, 1, 0, 0,
			0, 0, 0, 0, 0, 0, 1, -1, 0, 1,
			0, 0, -1, 0
		};

		private static readonly int[] variatePatternEp1B = new int[24]
		{
			-1, 0, 0, -1, 0, 0, 1, 1, 0, 0,
			0, 0, 0, 0, 0, 0, 1, -1, 0, 0,
			1, 0, 0, -1
		};

		public static int VarPatternCount => variatePatternEp0R.Length;

		public static (ColorRgb565, ColorRgb565) Variate565(ColorRgb565 c0, ColorRgb565 c1, int i)
		{
			int num = i % variatePatternEp0R.Length;
			ColorRgb565 item = default(ColorRgb565);
			ColorRgb565 item2 = default(ColorRgb565);
			item.RawR = ByteHelper.ClampToByte(c0.RawR + variatePatternEp0R[num]);
			item.RawG = ByteHelper.ClampToByte(c0.RawG + variatePatternEp0G[num]);
			item.RawB = ByteHelper.ClampToByte(c0.RawB + variatePatternEp0B[num]);
			item2.RawR = ByteHelper.ClampToByte(c1.RawR + variatePatternEp1R[num]);
			item2.RawG = ByteHelper.ClampToByte(c1.RawG + variatePatternEp1G[num]);
			item2.RawB = ByteHelper.ClampToByte(c1.RawB + variatePatternEp1B[num]);
			return (item, item2);
		}

		public static ((int, int, int), (int, int, int)) VariateInt((int, int, int) ep0, (int, int, int) ep1, int i)
		{
			int num = i % variatePatternEp0R.Length;
			return ((ep0.Item1 + variatePatternEp0R[num], ep0.Item2 + variatePatternEp0G[num], ep0.Item3 + variatePatternEp0B[num]), (ep1.Item1 + variatePatternEp1R[num], ep1.Item2 + variatePatternEp1G[num], ep1.Item3 + variatePatternEp1B[num]));
		}
	}
}
