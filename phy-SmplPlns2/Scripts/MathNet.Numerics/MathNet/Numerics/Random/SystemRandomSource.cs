using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;
using System.Threading;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class SystemRandomSource : RandomSource
	{
		[DataMember(Order = 1)]
		private readonly System.Random _random;

		private static readonly ThreadLocal<SystemRandomSource> DefaultInstance = new ThreadLocal<SystemRandomSource>(() => new SystemRandomSource(RandomSeed.Robust(), threadSafe: true));

		public static SystemRandomSource Default => DefaultInstance.Value;

		public SystemRandomSource()
			: this(RandomSeed.Robust())
		{
		}

		public SystemRandomSource(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public SystemRandomSource(int seed)
		{
			_random = new System.Random(seed);
		}

		public SystemRandomSource(int seed, bool threadSafe)
			: base(threadSafe)
		{
			_random = new System.Random(seed);
		}

		protected sealed override double DoSample()
		{
			return _random.NextDouble();
		}

		protected override int DoSampleInteger()
		{
			return _random.Next();
		}

		protected override int DoSampleInteger(int maxExclusive)
		{
			return _random.Next(maxExclusive);
		}

		protected override int DoSampleInteger(int minInclusive, int maxExclusive)
		{
			return _random.Next(minInclusive, maxExclusive);
		}

		protected override void DoSampleBytes(byte[] buffer)
		{
			_random.NextBytes(buffer);
		}

		public static void FastDoubles(double[] values)
		{
			if (values.Length < 2048)
			{
				Default.NextDoubles(values);
				return;
			}
			CommonParallel.For(0, values.Length, (values.Length >= 65536) ? 8192 : ((values.Length >= 16384) ? 2048 : 1024), delegate(int a, int b)
			{
				System.Random random = new System.Random(RandomSeed.Robust());
				for (int i = a; i < b; i++)
				{
					values[i] = random.NextDouble();
				}
			});
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double[] FastDoubles(int length)
		{
			double[] array = new double[length];
			FastDoubles(array);
			return array;
		}

		public static IEnumerable<double> DoubleSequence()
		{
			SystemRandomSource rnd1 = Default;
			for (int i = 0; i < 128; i++)
			{
				yield return rnd1.NextDouble();
			}
			System.Random rnd2 = new System.Random(RandomSeed.Robust());
			while (true)
			{
				yield return rnd2.NextDouble();
			}
		}

		public static void Doubles(double[] values, int seed)
		{
			System.Random random = new System.Random(seed);
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = random.NextDouble();
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
			System.Random rnd = new System.Random(seed);
			while (true)
			{
				yield return rnd.NextDouble();
			}
		}
	}
}
