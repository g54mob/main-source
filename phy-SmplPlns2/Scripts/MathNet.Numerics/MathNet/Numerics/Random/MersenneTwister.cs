using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;
using System.Threading;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class MersenneTwister : RandomSource
	{
		private const uint LowerMask = 2147483647u;

		private const int M = 397;

		private const uint MatrixA = 2567483615u;

		private const int N = 624;

		private const double Reciprocal = 2.3283064365386963E-10;

		private const uint UpperMask = 2147483648u;

		private static readonly uint[] Mag01 = new uint[2] { 0u, 2567483615u };

		[DataMember(Order = 1)]
		private readonly uint[] _mt = new uint[624];

		[DataMember(Order = 2)]
		private int _mti = 625;

		private static readonly ThreadLocal<MersenneTwister> DefaultInstance = new ThreadLocal<MersenneTwister>(() => new MersenneTwister(RandomSeed.Robust(), threadSafe: true));

		public static MersenneTwister Default => DefaultInstance.Value;

		public MersenneTwister()
			: this(RandomSeed.Robust())
		{
		}

		public MersenneTwister(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public MersenneTwister(int seed)
		{
			init_genrand((uint)seed);
		}

		public MersenneTwister(int seed, bool threadSafe)
			: base(threadSafe)
		{
			init_genrand((uint)seed);
		}

		private void init_genrand(uint s)
		{
			_mt[0] = s & 0xFFFFFFFFu;
			for (_mti = 1; _mti < 624; _mti++)
			{
				_mt[_mti] = 1812433253 * (_mt[_mti - 1] ^ (_mt[_mti - 1] >> 30)) + (uint)_mti;
				_mt[_mti] &= uint.MaxValue;
			}
		}

		private uint genrand_int32()
		{
			uint num;
			if (_mti >= 624)
			{
				if (_mti == 625)
				{
					init_genrand(5489u);
				}
				int i;
				for (i = 0; i < 227; i++)
				{
					num = (_mt[i] & 0x80000000u) | (_mt[i + 1] & 0x7FFFFFFF);
					_mt[i] = _mt[i + 397] ^ (num >> 1) ^ Mag01[num & 1];
				}
				for (; i < 623; i++)
				{
					num = (_mt[i] & 0x80000000u) | (_mt[i + 1] & 0x7FFFFFFF);
					_mt[i] = _mt[i + -227] ^ (num >> 1) ^ Mag01[num & 1];
				}
				num = (_mt[623] & 0x80000000u) | (_mt[0] & 0x7FFFFFFF);
				_mt[623] = _mt[396] ^ (num >> 1) ^ Mag01[num & 1];
				_mti = 0;
			}
			num = _mt[_mti++];
			num ^= num >> 11;
			num ^= (num << 7) & 0x9D2C5680u;
			num ^= (num << 15) & 0xEFC60000u;
			return num ^ (num >> 18);
		}

		protected sealed override double DoSample()
		{
			return (double)genrand_int32() * 2.3283064365386963E-10;
		}

		protected sealed override int DoSampleInteger()
		{
			int num = (int)(genrand_int32() >> 1);
			if (num == int.MaxValue)
			{
				return DoSampleInteger();
			}
			return num;
		}

		protected sealed override void DoSampleBytes(byte[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = (byte)(genrand_int32() % 256);
			}
		}

		public static void Doubles(double[] values, int seed)
		{
			uint[] array = new uint[624];
			array[0] = (uint)(seed & -1);
			int i;
			for (i = 1; i < 624; i++)
			{
				array[i] = 1812433253 * (array[i - 1] ^ (array[i - 1] >> 30)) + (uint)i;
				array[i] &= uint.MaxValue;
			}
			for (int j = 0; j < values.Length; j++)
			{
				uint num;
				if (i >= 624)
				{
					int k;
					for (k = 0; k < 227; k++)
					{
						num = (array[k] & 0x80000000u) | (array[k + 1] & 0x7FFFFFFF);
						array[k] = array[k + 397] ^ (num >> 1) ^ Mag01[num & 1];
					}
					for (; k < 623; k++)
					{
						num = (array[k] & 0x80000000u) | (array[k + 1] & 0x7FFFFFFF);
						array[k] = array[k + -227] ^ (num >> 1) ^ Mag01[num & 1];
					}
					num = (array[623] & 0x80000000u) | (array[0] & 0x7FFFFFFF);
					array[623] = array[396] ^ (num >> 1) ^ Mag01[num & 1];
					i = 0;
				}
				num = array[i++];
				num ^= num >> 11;
				num ^= (num << 7) & 0x9D2C5680u;
				num ^= (num << 15) & 0xEFC60000u;
				num ^= num >> 18;
				values[j] = (double)num * 2.3283064365386963E-10;
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
			uint[] t = new uint[624];
			t[0] = (uint)(seed & -1);
			int k;
			for (k = 1; k < 624; k++)
			{
				t[k] = 1812433253 * (t[k - 1] ^ (t[k - 1] >> 30)) + (uint)k;
				t[k] &= uint.MaxValue;
			}
			while (true)
			{
				uint num;
				if (k >= 624)
				{
					int i;
					for (i = 0; i < 227; i++)
					{
						num = (t[i] & 0x80000000u) | (t[i + 1] & 0x7FFFFFFF);
						t[i] = t[i + 397] ^ (num >> 1) ^ Mag01[num & 1];
					}
					for (; i < 623; i++)
					{
						num = (t[i] & 0x80000000u) | (t[i + 1] & 0x7FFFFFFF);
						t[i] = t[i + -227] ^ (num >> 1) ^ Mag01[num & 1];
					}
					num = (t[623] & 0x80000000u) | (t[0] & 0x7FFFFFFF);
					t[623] = t[396] ^ (num >> 1) ^ Mag01[num & 1];
					k = 0;
				}
				num = t[k++];
				num ^= num >> 11;
				num ^= (num << 7) & 0x9D2C5680u;
				num ^= (num << 15) & 0xEFC60000u;
				num ^= num >> 18;
				yield return (double)num * 2.3283064365386963E-10;
			}
		}
	}
}
