using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class Palf : RandomSource
	{
		private const int DefaultShortLag = 418;

		private const int DefaultLongLag = 1279;

		private const double Reciprocal = 2.3283064365386963E-10;

		[DataMember(Order = 3)]
		private readonly uint[] _x;

		[DataMember(Order = 4)]
		private readonly int _threads;

		[DataMember(Order = 5)]
		private int _k;

		[DataMember(Order = 1)]
		public int ShortLag { get; private set; }

		[DataMember(Order = 2)]
		public int LongLag { get; private set; }

		public Palf()
			: this(RandomSeed.Robust(), Control.ThreadSafeRandomNumberGenerators, 418, 1279)
		{
		}

		public Palf(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe, 418, 1279)
		{
		}

		public Palf(int seed)
			: this(seed, Control.ThreadSafeRandomNumberGenerators, 418, 1279)
		{
		}

		public Palf(int seed, bool threadSafe)
			: this(seed, threadSafe, 418, 1279)
		{
		}

		public Palf(int seed, bool threadSafe, int shortLag, int longLag)
			: base(threadSafe)
		{
			if (shortLag < 1)
			{
				throw new ArgumentException("Value must be positive.", "shortLag");
			}
			if (longLag <= shortLag)
			{
				throw new ArgumentException("The upper bound must be strictly larger than the lower bound.", "longLag");
			}
			if (seed == 0)
			{
				seed = 1;
			}
			_threads = Control.MaxDegreeOfParallelism;
			ShortLag = shortLag;
			if (longLag % _threads == 0)
			{
				LongLag = longLag;
			}
			else
			{
				LongLag = (longLag / _threads + 1) * _threads;
			}
			_x = Generate.Map(MersenneTwister.Doubles(LongLag, seed), (double uniform) => (uint)(uniform * 4294967295.0));
			_k = LongLag;
		}

		private void Fill()
		{
			for (int i = 0; i < _threads; i++)
			{
				for (int j = i; j < ShortLag; j += _threads)
				{
					_x[j] += _x[j + (LongLag - ShortLag)];
				}
				for (int k = ShortLag + i; k < LongLag; k += _threads)
				{
					_x[k] += _x[k - ShortLag - i];
				}
			}
			_k = 0;
		}

		protected sealed override double DoSample()
		{
			if (_k >= LongLag)
			{
				Fill();
			}
			return (double)_x[_k++] * 2.3283064365386963E-10;
		}

		protected override int DoSampleInteger()
		{
			if (_k >= LongLag)
			{
				Fill();
			}
			int num = (int)(_x[_k++] >> 1);
			if (num == int.MaxValue)
			{
				return DoSampleInteger();
			}
			return num;
		}

		public static void Doubles(double[] values, int seed)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			int maxDegreeOfParallelism = Control.MaxDegreeOfParallelism;
			int num = 1279;
			if (num % maxDegreeOfParallelism != 0)
			{
				num = (num / maxDegreeOfParallelism + 1) * maxDegreeOfParallelism;
			}
			uint[] array = Generate.Map(MersenneTwister.Doubles(num, seed), (double uniform) => (uint)(uniform * 4294967295.0));
			int num2 = num;
			for (int num3 = 0; num3 < values.Length; num3++)
			{
				if (num2 >= num)
				{
					for (int num4 = 0; num4 < maxDegreeOfParallelism; num4++)
					{
						for (int num5 = num4; num5 < 418; num5 += maxDegreeOfParallelism)
						{
							array[num5] += array[num5 + (num - 418)];
						}
						for (int num6 = 418 + num4; num6 < num; num6 += maxDegreeOfParallelism)
						{
							array[num6] += array[num6 - 418 - num4];
						}
					}
					num2 = 0;
				}
				values[num3] = (double)array[num2++] * 2.3283064365386963E-10;
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
			int threads = Control.MaxDegreeOfParallelism;
			int longLag = 1279;
			if (longLag % threads != 0)
			{
				longLag = (longLag / threads + 1) * threads;
			}
			uint[] x = Generate.Map(MersenneTwister.Doubles(longLag, seed), (double uniform) => (uint)(uniform * 4294967295.0));
			int k = longLag;
			while (true)
			{
				if (k >= longLag)
				{
					for (int num = 0; num < threads; num++)
					{
						for (int num2 = num; num2 < 418; num2 += threads)
						{
							x[num2] += x[num2 + (longLag - 418)];
						}
						for (int num3 = 418 + num; num3 < longLag; num3 += threads)
						{
							x[num3] += x[num3 - 418 - num];
						}
					}
					k = 0;
				}
				yield return (double)x[k++] * 2.3283064365386963E-10;
			}
		}
	}
}
