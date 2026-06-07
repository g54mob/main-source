using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class WH1982 : RandomSource
	{
		private const uint Modx = 30269u;

		private const double ModxRecip = 3.3037100664045725E-05;

		private const uint Mody = 30307u;

		private const double ModyRecip = 3.2995677566238825E-05;

		private const uint Modz = 30323u;

		private const double ModzRecip = 3.297826732183491E-05;

		[DataMember(Order = 1)]
		private uint _xn;

		[DataMember(Order = 2)]
		private uint _yn = 1u;

		[DataMember(Order = 3)]
		private uint _zn = 1u;

		public WH1982()
			: this(RandomSeed.Robust())
		{
		}

		public WH1982(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public WH1982(int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (uint)seed % 30269u;
		}

		public WH1982(int seed, bool threadSafe)
			: base(threadSafe)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (uint)seed % 30269u;
		}

		protected sealed override double DoSample()
		{
			_xn = 171 * _xn % 30269;
			_yn = 172 * _yn % 30307;
			_zn = 170 * _zn % 30323;
			double num = (double)_xn * 3.3037100664045725E-05 + (double)_yn * 3.2995677566238825E-05 + (double)_zn * 3.297826732183491E-05;
			return num - (double)(int)num;
		}

		public static void Doubles(double[] values, int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			uint num = (uint)seed % 30269u;
			uint num2 = 1u;
			uint num3 = 1u;
			for (int i = 0; i < values.Length; i++)
			{
				num = 171 * num % 30269;
				num2 = 172 * num2 % 30307;
				num3 = 170 * num3 % 30323;
				double num4 = (double)num * 3.3037100664045725E-05 + (double)num2 * 3.2995677566238825E-05 + (double)num3 * 3.297826732183491E-05;
				values[i] = num4 - (double)(int)num4;
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
			uint xn = (uint)seed % 30269u;
			uint yn = 1u;
			uint zn = 1u;
			while (true)
			{
				xn = 171 * xn % 30269;
				yn = 172 * yn % 30307;
				zn = 170 * zn % 30323;
				double num = (double)xn * 3.3037100664045725E-05 + (double)yn * 3.2995677566238825E-05 + (double)zn * 3.297826732183491E-05;
				yield return num - (double)(int)num;
			}
		}
	}
}
