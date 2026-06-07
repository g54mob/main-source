using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public abstract class RandomSource : System.Random
	{
		private readonly bool _threadSafe;

		private readonly object _lock = new object();

		protected RandomSource()
			: base(RandomSeed.Robust())
		{
			_threadSafe = Control.ThreadSafeRandomNumberGenerators;
		}

		protected RandomSource(bool threadSafe)
			: base(RandomSeed.Robust())
		{
			_threadSafe = threadSafe;
		}

		public void NextDoubles(double[] values)
		{
			if (_threadSafe)
			{
				lock (_lock)
				{
					for (int i = 0; i < values.Length; i++)
					{
						values[i] = DoSample();
					}
					return;
				}
			}
			for (int j = 0; j < values.Length; j++)
			{
				values[j] = DoSample();
			}
		}

		public double[] NextDoubles(int count)
		{
			double[] array = new double[count];
			NextDoubles(array);
			return array;
		}

		public IEnumerable<double> NextDoubleSequence()
		{
			for (int i = 0; i < 64; i++)
			{
				yield return NextDouble();
			}
			double[] buffer = new double[64];
			while (true)
			{
				NextDoubles(buffer);
				for (int i = 0; i < buffer.Length; i++)
				{
					yield return buffer[i];
				}
			}
		}

		public sealed override int Next()
		{
			if (_threadSafe)
			{
				lock (_lock)
				{
					return DoSampleInteger();
				}
			}
			return DoSampleInteger();
		}

		public sealed override int Next(int maxExclusive)
		{
			if (maxExclusive <= 0)
			{
				throw new ArgumentException("Value must be positive.");
			}
			switch (maxExclusive)
			{
			case 1:
				return 0;
			case int.MaxValue:
				return Next();
			default:
				if (_threadSafe)
				{
					lock (_lock)
					{
						return DoSampleInteger(maxExclusive);
					}
				}
				return DoSampleInteger(maxExclusive);
			}
		}

		public sealed override int Next(int minInclusive, int maxExclusive)
		{
			if (minInclusive >= maxExclusive)
			{
				throw new ArgumentException("In the specified range, the exclusive maximum must be greater than the inclusive minimum.");
			}
			if (maxExclusive == minInclusive + 1)
			{
				return minInclusive;
			}
			if (minInclusive == 0)
			{
				if (maxExclusive == int.MaxValue)
				{
					return Next();
				}
				return Next(maxExclusive);
			}
			if (_threadSafe)
			{
				lock (_lock)
				{
					return DoSampleInteger(minInclusive, maxExclusive);
				}
			}
			return DoSampleInteger(minInclusive, maxExclusive);
		}

		public void NextInt32s(int[] values)
		{
			if (_threadSafe)
			{
				lock (_lock)
				{
					for (int i = 0; i < values.Length; i++)
					{
						values[i] = DoSampleInteger();
					}
					return;
				}
			}
			for (int j = 0; j < values.Length; j++)
			{
				values[j] = DoSampleInteger();
			}
		}

		public int[] NextInt32s(int count)
		{
			int[] array = new int[count];
			NextInt32s(array);
			return array;
		}

		public void NextInt32s(int[] values, int maxExclusive)
		{
			if (maxExclusive <= 0)
			{
				throw new ArgumentException("Value must be positive.");
			}
			switch (maxExclusive)
			{
			case 1:
				Array.Clear(values, 0, values.Length);
				return;
			case int.MaxValue:
				NextInt32s(values);
				return;
			}
			if (_threadSafe)
			{
				lock (_lock)
				{
					for (int i = 0; i < values.Length; i++)
					{
						values[i] = DoSampleInteger(maxExclusive);
					}
					return;
				}
			}
			for (int j = 0; j < values.Length; j++)
			{
				values[j] = DoSampleInteger(maxExclusive);
			}
		}

		public int[] NextInt32s(int count, int maxExclusive)
		{
			int[] array = new int[count];
			NextInt32s(array, maxExclusive);
			return array;
		}

		public void NextInt32s(int[] values, int minInclusive, int maxExclusive)
		{
			if (minInclusive >= maxExclusive)
			{
				throw new ArgumentException("In the specified range, the exclusive maximum must be greater than the inclusive minimum.");
			}
			if (maxExclusive == minInclusive + 1)
			{
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = minInclusive;
				}
				return;
			}
			if (minInclusive == 0)
			{
				if (maxExclusive == int.MaxValue)
				{
					NextInt32s(values);
				}
				else
				{
					NextInt32s(values, maxExclusive);
				}
				return;
			}
			if (_threadSafe)
			{
				lock (_lock)
				{
					for (int j = 0; j < values.Length; j++)
					{
						values[j] = DoSampleInteger(minInclusive, maxExclusive);
					}
					return;
				}
			}
			for (int k = 0; k < values.Length; k++)
			{
				values[k] = DoSampleInteger(minInclusive, maxExclusive);
			}
		}

		public int[] NextInt32s(int count, int minInclusive, int maxExclusive)
		{
			int[] array = new int[count];
			NextInt32s(array, minInclusive, maxExclusive);
			return array;
		}

		public IEnumerable<int> NextInt32Sequence()
		{
			for (int i = 0; i < 64; i++)
			{
				yield return Next();
			}
			int[] buffer = new int[64];
			while (true)
			{
				NextInt32s(buffer);
				for (int i = 0; i < buffer.Length; i++)
				{
					yield return buffer[i];
				}
			}
		}

		public IEnumerable<int> NextInt32Sequence(int minInclusive, int maxExclusive)
		{
			if (minInclusive > maxExclusive)
			{
				throw new ArgumentException("In the specified range, the minimum is greater than maximum.");
			}
			for (int i = 0; i < 64; i++)
			{
				yield return Next(minInclusive, maxExclusive);
			}
			int[] buffer = new int[64];
			while (true)
			{
				NextInt32s(buffer, minInclusive, maxExclusive);
				for (int i = 0; i < buffer.Length; i++)
				{
					yield return buffer[i];
				}
			}
		}

		public sealed override void NextBytes(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (_threadSafe)
			{
				lock (_lock)
				{
					DoSampleBytes(buffer);
					return;
				}
			}
			DoSampleBytes(buffer);
		}

		protected sealed override double Sample()
		{
			if (_threadSafe)
			{
				lock (_lock)
				{
					return DoSample();
				}
			}
			return DoSample();
		}

		protected abstract double DoSample();

		protected virtual int DoSampleInteger()
		{
			return (int)(DoSample() * 2147483647.0);
		}

		protected virtual void DoSampleBytes(byte[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = (byte)(DoSampleInteger() % 256);
			}
		}

		protected virtual int DoSampleInt32WithNBits(int bitCount)
		{
			if (bitCount == 0)
			{
				return 0;
			}
			byte[] array = new byte[4];
			DoSampleBytes(array);
			return (int)(BitConverter.ToUInt32(array, 0) >> 32 - bitCount);
		}

		protected virtual long DoSampleInt64WithNBits(int bitCount)
		{
			if (bitCount == 0)
			{
				return 0L;
			}
			byte[] array = new byte[8];
			DoSampleBytes(array);
			return (long)(BitConverter.ToUInt64(array, 0) >> 64 - bitCount);
		}

		protected virtual int DoSampleInteger(int maxExclusive)
		{
			int num = maxExclusive.Log2();
			if (num.PowerOfTwo() == maxExclusive)
			{
				return DoSampleInt32WithNBits(num);
			}
			num++;
			int num2;
			do
			{
				num2 = DoSampleInt32WithNBits(num);
			}
			while (num2 >= maxExclusive);
			return num2;
		}

		protected virtual int DoSampleInteger(int minInclusive, int maxExclusive)
		{
			return DoSampleInteger(maxExclusive - minInclusive) + minInclusive;
		}
	}
}
