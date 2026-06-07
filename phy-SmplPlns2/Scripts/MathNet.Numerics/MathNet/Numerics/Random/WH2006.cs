using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class WH2006 : RandomSource
	{
		private const uint Modw = 2147483123u;

		private const double ModwRecip = 4.656614011489952E-10;

		private const uint Modx = 2147483579u;

		private const double ModxRecip = 4.656613022697298E-10;

		private const uint Mody = 2147483543u;

		private const double ModyRecip = 4.65661310075986E-10;

		private const uint Modz = 2147483423u;

		private const double ModzRecip = 4.656613360968421E-10;

		[DataMember(Order = 1)]
		private ulong _wn = 1uL;

		[DataMember(Order = 2)]
		private ulong _xn;

		[DataMember(Order = 3)]
		private ulong _yn = 1uL;

		[DataMember(Order = 4)]
		private ulong _zn = 1uL;

		public WH2006()
			: this(RandomSeed.Robust())
		{
		}

		public WH2006(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public WH2006(int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (uint)seed % 2147483579u;
		}

		public WH2006(int seed, bool threadSafe)
			: base(threadSafe)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (uint)seed % 2147483579u;
		}

		protected sealed override double DoSample()
		{
			_xn = 11600 * _xn % 2147483579;
			_yn = 47003 * _yn % 2147483543;
			_zn = 23000 * _zn % 2147483423;
			_wn = 33000 * _wn % 2147483123;
			double num = (double)_xn * 4.656613022697298E-10 + (double)_yn * 4.65661310075986E-10 + (double)_zn * 4.656613360968421E-10 + (double)_wn * 4.656614011489952E-10;
			return num - (double)(int)num;
		}

		public static void Doubles(double[] values, int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			ulong num = 1uL;
			ulong num2 = (uint)seed % 2147483579u;
			ulong num3 = 1uL;
			ulong num4 = 1uL;
			for (int i = 0; i < values.Length; i++)
			{
				num2 = 11600 * num2 % 2147483579;
				num3 = 47003 * num3 % 2147483543;
				num4 = 23000 * num4 % 2147483423;
				num = 33000 * num % 2147483123;
				double num5 = (double)num2 * 4.656613022697298E-10 + (double)num3 * 4.65661310075986E-10 + (double)num4 * 4.656613360968421E-10 + (double)num * 4.656614011489952E-10;
				values[i] = num5 - (double)(int)num5;
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
			if (seed == 0)
			{
				seed = 1;
			}
			ulong wn = 1uL;
			ulong xn = (uint)seed % 2147483579u;
			ulong yn = 1uL;
			ulong zn = 1uL;
			while (true)
			{
				xn = 11600 * xn % 2147483579;
				yn = 47003 * yn % 2147483543;
				zn = 23000 * zn % 2147483423;
				wn = 33000 * wn % 2147483123;
				double num = (double)xn * 4.656613022697298E-10 + (double)yn * 4.65661310075986E-10 + (double)zn * 4.656613360968421E-10 + (double)wn * 4.656614011489952E-10;
				yield return num - (double)(int)num;
			}
		}
	}
}
