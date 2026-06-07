using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class Mrg32k3a : RandomSource
	{
		private const double A12 = 1403580.0;

		private const double A13 = 810728.0;

		private const double A21 = 527612.0;

		private const double A23 = 1370589.0;

		private const double Modulus1 = 4294967087.0;

		private const double Modulus2 = 4294944443.0;

		private const double Reciprocal = 2.328306549837829E-10;

		[DataMember(Order = 1)]
		private double _xn1 = 1.0;

		[DataMember(Order = 2)]
		private double _xn2 = 1.0;

		[DataMember(Order = 3)]
		private double _xn3;

		[DataMember(Order = 4)]
		private double _yn1 = 1.0;

		[DataMember(Order = 5)]
		private double _yn2 = 1.0;

		[DataMember(Order = 6)]
		private double _yn3 = 1.0;

		public Mrg32k3a()
			: this(RandomSeed.Robust())
		{
		}

		public Mrg32k3a(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public Mrg32k3a(int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn3 = (uint)seed;
		}

		public Mrg32k3a(int seed, bool threadSafe)
			: base(threadSafe)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn3 = (uint)seed;
		}

		protected sealed override double DoSample()
		{
			double num = 1403580.0 * _xn2 - 810728.0 * _xn3;
			double num2 = (long)(num / 4294967087.0);
			num -= num2 * 4294967087.0;
			if (num < 0.0)
			{
				num += 4294967087.0;
			}
			double num3 = 527612.0 * _yn1 - 1370589.0 * _yn3;
			num2 = (long)(num3 / 4294944443.0);
			num3 -= num2 * 4294944443.0;
			if (num3 < 0.0)
			{
				num3 += 4294944443.0;
			}
			_xn3 = _xn2;
			_xn2 = _xn1;
			_xn1 = num;
			_yn3 = _yn2;
			_yn2 = _yn1;
			_yn1 = num3;
			if (num <= num3)
			{
				return (num - num3 + 4294967087.0) * 2.328306549837829E-10;
			}
			return (num - num3) * 2.328306549837829E-10;
		}

		public static void Doubles(double[] values, int seed)
		{
			double num = 1.0;
			double num2 = 1.0;
			double num3 = (uint)seed;
			double num4 = 1.0;
			double num5 = 1.0;
			double num6 = 1.0;
			for (int i = 0; i < values.Length; i++)
			{
				double num7 = 1403580.0 * num2 - 810728.0 * num3;
				double num8 = (long)(num7 / 4294967087.0);
				num7 -= num8 * 4294967087.0;
				if (num7 < 0.0)
				{
					num7 += 4294967087.0;
				}
				double num9 = 527612.0 * num4 - 1370589.0 * num6;
				num8 = (long)(num9 / 4294944443.0);
				num9 -= num8 * 4294944443.0;
				if (num9 < 0.0)
				{
					num9 += 4294944443.0;
				}
				num3 = num2;
				num2 = num;
				num = num7;
				num6 = num5;
				num5 = num4;
				num4 = num9;
				values[i] = ((num7 <= num9) ? ((num7 - num9 + 4294967087.0) * 2.328306549837829E-10) : ((num7 - num9) * 2.328306549837829E-10));
			}
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double[] Doubles(int length, int seed)
		{
			double[] array = new double[length];
			Doubles(array, seed);
			return array;
		}

		public static IEnumerable<double> DoubleSequence(int seed)
		{
			double x1 = 1.0;
			double x2 = 1.0;
			double x3 = (uint)seed;
			double y1 = 1.0;
			double y2 = 1.0;
			double y3 = 1.0;
			while (true)
			{
				double num = 1403580.0 * x2 - 810728.0 * x3;
				double num2 = (long)(num / 4294967087.0);
				num -= num2 * 4294967087.0;
				if (num < 0.0)
				{
					num += 4294967087.0;
				}
				double num3 = 527612.0 * y1 - 1370589.0 * y3;
				num2 = (long)(num3 / 4294944443.0);
				num3 -= num2 * 4294944443.0;
				if (num3 < 0.0)
				{
					num3 += 4294944443.0;
				}
				x3 = x2;
				x2 = x1;
				x1 = num;
				y3 = y2;
				y2 = y1;
				y1 = num3;
				yield return (num <= num3) ? ((num - num3 + 4294967087.0) * 2.328306549837829E-10) : ((num - num3) * 2.328306549837829E-10);
			}
		}
	}
}
