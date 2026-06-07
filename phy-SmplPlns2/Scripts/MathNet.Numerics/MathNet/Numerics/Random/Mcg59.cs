using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class Mcg59 : RandomSource
	{
		private const ulong Modulus = 576460752303423488uL;

		private const ulong Multiplier = 302875106592253uL;

		private const double Reciprocal = 1.734723475976807E-18;

		[DataMember(Order = 1)]
		private ulong _xn;

		public Mcg59()
			: this(RandomSeed.Robust())
		{
		}

		public Mcg59(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public Mcg59(int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (ulong)(uint)seed % 576460752303423488uL;
		}

		public Mcg59(int seed, bool threadSafe)
			: base(threadSafe)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (ulong)(uint)seed % 576460752303423488uL;
		}

		protected sealed override double DoSample()
		{
			double result = (double)_xn * 1.734723475976807E-18;
			_xn = _xn * 302875106592253L % 576460752303423488L;
			return result;
		}

		public static void Doubles(double[] values, int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			ulong num = (ulong)(uint)seed % 576460752303423488uL;
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = (double)num * 1.734723475976807E-18;
				num = num * 302875106592253L % 576460752303423488L;
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
			ulong xn = (ulong)(uint)seed % 576460752303423488uL;
			while (true)
			{
				yield return (double)xn * 1.734723475976807E-18;
				xn = xn * 302875106592253L % 576460752303423488L;
			}
		}
	}
}
