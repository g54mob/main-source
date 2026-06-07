using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class Mcg31m1 : RandomSource
	{
		private const ulong Modulus = 2147483647uL;

		private const ulong Multiplier = 1132489760uL;

		private const double Reciprocal = 4.656612875245797E-10;

		[DataMember(Order = 1)]
		private ulong _xn;

		public Mcg31m1()
			: this(RandomSeed.Robust())
		{
		}

		public Mcg31m1(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public Mcg31m1(int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (ulong)(uint)seed % 2147483647uL;
		}

		public Mcg31m1(int seed, bool threadSafe)
			: base(threadSafe)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_xn = (ulong)(uint)seed % 2147483647uL;
		}

		protected sealed override double DoSample()
		{
			double result = (double)_xn * 4.656612875245797E-10;
			_xn = _xn * 1132489760 % int.MaxValue;
			return result;
		}

		public static void Doubles(double[] values, int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			ulong num = (ulong)(uint)seed % 2147483647uL;
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = (double)num * 4.656612875245797E-10;
				num = num * 1132489760 % int.MaxValue;
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
			ulong xn = (ulong)(uint)seed % 2147483647uL;
			while (true)
			{
				yield return (double)xn * 4.656612875245797E-10;
				xn = xn * 1132489760 % int.MaxValue;
			}
		}
	}
}
