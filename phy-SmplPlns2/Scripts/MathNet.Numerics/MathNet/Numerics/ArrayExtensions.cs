using System;
using System.Numerics;

namespace MathNet.Numerics
{
	internal static class ArrayExtensions
	{
		public static void Copy(this double[] source, double[] dest)
		{
			Buffer.BlockCopy(source, 0, dest, 0, source.Length * 8);
		}

		public static void Copy(this float[] source, float[] dest)
		{
			Buffer.BlockCopy(source, 0, dest, 0, source.Length * 4);
		}

		public static void Copy(this Complex[] source, Complex[] dest)
		{
			Array.Copy(source, 0, dest, 0, source.Length);
		}

		public static void Copy(this Complex32[] source, Complex32[] dest)
		{
			Array.Copy(source, 0, dest, 0, source.Length);
		}
	}
}
