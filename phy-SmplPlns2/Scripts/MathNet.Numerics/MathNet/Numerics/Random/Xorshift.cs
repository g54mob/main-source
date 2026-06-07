using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class Xorshift : RandomSource
	{
		private const uint YSeed = 362436069u;

		private const uint ZSeed = 77465321u;

		private const uint ASeed = 916905990u;

		private const uint CSeed = 13579u;

		private const double UlongToDoubleMultiplier = 2.3283064365386963E-10;

		[DataMember(Order = 1)]
		private ulong _x;

		[DataMember(Order = 2)]
		private ulong _y;

		[DataMember(Order = 3)]
		private ulong _z;

		[DataMember(Order = 4)]
		private ulong _c;

		[DataMember(Order = 5)]
		private readonly ulong _a;

		public Xorshift()
			: this(RandomSeed.Robust())
		{
		}

		public Xorshift(long a, long c, long x1, long x2)
			: this(RandomSeed.Robust(), a, c, x1, x2)
		{
		}

		public Xorshift(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public Xorshift(bool threadSafe, long a, long c, long x1, long x2)
			: this(RandomSeed.Robust(), threadSafe, a, c, x1, x2)
		{
		}

		public Xorshift(int seed)
			: this(seed, Control.ThreadSafeRandomNumberGenerators)
		{
		}

		public Xorshift(int seed, long a, long c, long x1, long x2)
			: this(seed, Control.ThreadSafeRandomNumberGenerators, a, c, x1, x2)
		{
		}

		public Xorshift(int seed, bool threadSafe)
			: base(threadSafe)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			_x = (uint)seed;
			_y = 362436069uL;
			_z = 77465321uL;
			_c = 13579uL;
			_a = 916905990uL;
		}

		public Xorshift(int seed, bool threadSafe, long a, long c, long x1, long x2)
			: base(threadSafe)
		{
			if (seed == 0)
			{
				seed = 1;
			}
			if (a <= c)
			{
				throw new ArgumentException("a must be greater than c.", "a");
			}
			_x = (uint)seed;
			_y = (ulong)x1;
			_z = (ulong)x2;
			_a = (ulong)a;
			_c = (ulong)c;
		}

		protected sealed override double DoSample()
		{
			ulong num = _a * _x + _c;
			_x = _y;
			_y = _z;
			_c = num >> 32;
			_z = num & 0xFFFFFFFFu;
			return (double)_z * 2.3283064365386963E-10;
		}

		protected sealed override int DoSampleInteger()
		{
			ulong num = _a * _x + _c;
			_x = _y;
			_y = _z;
			_c = num >> 32;
			_z = num & 0xFFFFFFFFu;
			int num2 = (int)((uint)_z >> 1);
			if (num2 == int.MaxValue)
			{
				return DoSampleInteger();
			}
			return num2;
		}

		protected sealed override void DoSampleBytes(byte[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				ulong num = _a * _x + _c;
				_x = _y;
				_y = _z;
				_c = num >> 32;
				_z = num & 0xFFFFFFFFu;
				buffer[i] = (byte)(_z % 256);
			}
		}

		[CLSCompliant(false)]
		public static void Doubles(double[] values, int seed, ulong a = 916905990uL, ulong c = 13579uL, ulong x1 = 362436069uL, ulong x2 = 77465321uL)
		{
			if (a <= c)
			{
				throw new ArgumentException("a must be greater than c.", "a");
			}
			if (seed == 0)
			{
				seed = 1;
			}
			ulong num = (uint)seed;
			for (int i = 0; i < values.Length; i++)
			{
				ulong num2 = a * num + c;
				num = x1;
				x1 = x2;
				c = num2 >> 32;
				x2 = num2 & 0xFFFFFFFFu;
				values[i] = (double)x2 * 2.3283064365386963E-10;
			}
		}

		[CLSCompliant(false)]
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double[] Doubles(int length, int seed, ulong a = 916905990uL, ulong c = 13579uL, ulong x1 = 362436069uL, ulong x2 = 77465321uL)
		{
			double[] array = new double[length];
			Doubles(array, seed, a, c, x1, x2);
			return array;
		}

		[CLSCompliant(false)]
		public static IEnumerable<double> DoubleSequence(int seed, ulong a = 916905990uL, ulong c = 13579uL, ulong x1 = 362436069uL, ulong x2 = 77465321uL)
		{
			if (a <= c)
			{
				throw new ArgumentException("a must be greater than c.", "a");
			}
			if (seed == 0)
			{
				seed = 1;
			}
			ulong x3 = (uint)seed;
			while (true)
			{
				ulong num = a * x3 + c;
				x3 = x1;
				x1 = x2;
				c = num >> 32;
				x2 = num & 0xFFFFFFFFu;
				yield return (double)x2 * 2.3283064365386963E-10;
			}
		}
	}
}
