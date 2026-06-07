using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Random
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/Random")]
	public class Xoshiro256StarStar : RandomSource
	{
		private const double REAL_UNIT_UINT = 1.1102230246251565E-16;

		[DataMember(Order = 1)]
		private ulong _s0;

		[DataMember(Order = 2)]
		private ulong _s1;

		[DataMember(Order = 3)]
		private ulong _s2;

		[DataMember(Order = 4)]
		private ulong _s3;

		public Xoshiro256StarStar()
			: this(RandomSeed.Robust())
		{
		}

		public Xoshiro256StarStar(bool threadSafe)
			: this(RandomSeed.Robust(), threadSafe)
		{
		}

		public Xoshiro256StarStar(int seed)
		{
			Initialise(seed);
		}

		public Xoshiro256StarStar(int seed, bool threadSafe)
			: base(threadSafe)
		{
			Initialise(seed);
		}

		protected sealed override double DoSample()
		{
			return (double)(NextInnerULong() >> 11) * 1.1102230246251565E-16;
		}

		protected override int DoSampleInteger()
		{
			ulong num;
			do
			{
				num = NextInnerULong() & 0x7FFFFFFF;
			}
			while (num == int.MaxValue);
			return (int)num;
		}

		protected override void DoSampleBytes(byte[] buffer)
		{
			ulong num = _s0;
			ulong num2 = _s1;
			ulong num3 = _s2;
			ulong num4 = _s3;
			int num5 = 0;
			int num6 = buffer.Length - buffer.Length % 8;
			while (num5 < num6)
			{
				ulong num7 = RotateLeft(num2 * 5, 7) * 9;
				ulong num8 = num2 << 17;
				num3 ^= num;
				num4 ^= num2;
				num2 ^= num3;
				num ^= num4;
				num3 ^= num8;
				num4 = RotateLeft(num4, 45);
				buffer[num5++] = (byte)num7;
				buffer[num5++] = (byte)(num7 >> 8);
				buffer[num5++] = (byte)(num7 >> 16);
				buffer[num5++] = (byte)(num7 >> 24);
				buffer[num5++] = (byte)(num7 >> 32);
				buffer[num5++] = (byte)(num7 >> 40);
				buffer[num5++] = (byte)(num7 >> 48);
				buffer[num5++] = (byte)(num7 >> 56);
			}
			if (num5 < buffer.Length)
			{
				ulong num9 = RotateLeft(num2 * 5, 7) * 9;
				ulong num10 = num2 << 17;
				num3 ^= num;
				num4 ^= num2;
				num2 ^= num3;
				num ^= num4;
				num3 ^= num10;
				num4 = RotateLeft(num4, 45);
				while (num5 < buffer.Length)
				{
					buffer[num5++] = (byte)num9;
					num9 >>= 8;
				}
			}
			_s0 = num;
			_s1 = num2;
			_s2 = num3;
			_s3 = num4;
		}

		protected override int DoSampleInt32WithNBits(int bitCount)
		{
			return (int)(NextInnerULong() >> 64 - bitCount);
		}

		protected override long DoSampleInt64WithNBits(int bitCount)
		{
			return (long)(NextInnerULong() >> 64 - bitCount);
		}

		private void Initialise(int seed)
		{
			ulong x = (ulong)seed;
			_s0 = Splitmix64(ref x);
			_s1 = Splitmix64(ref x);
			_s2 = Splitmix64(ref x);
			_s3 = Splitmix64(ref x);
		}

		private ulong NextInnerULong()
		{
			ulong s = _s0;
			ulong s2 = _s1;
			ulong s3 = _s2;
			ulong s4 = _s3;
			ulong result = RotateLeft(s2 * 5, 7) * 9;
			ulong num = s2 << 17;
			s3 ^= s;
			s4 ^= s2;
			s2 ^= s3;
			s ^= s4;
			s3 ^= num;
			s4 = RotateLeft(s4, 45);
			_s0 = s;
			_s1 = s2;
			_s2 = s3;
			_s3 = s4;
			return result;
		}

		public static void Doubles(double[] values, int seed)
		{
			ulong x = (ulong)seed;
			ulong num = Splitmix64(ref x);
			ulong num2 = Splitmix64(ref x);
			ulong num3 = Splitmix64(ref x);
			ulong num4 = Splitmix64(ref x);
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = (double)(RotateLeft(num2 * 5, 7) * 9 >> 11) * 1.1102230246251565E-16;
				ulong num5 = num2 << 17;
				num3 ^= num;
				num4 ^= num2;
				num2 ^= num3;
				num ^= num4;
				num3 ^= num5;
				num4 = RotateLeft(num4, 45);
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
			ulong x = (ulong)seed;
			ulong s0 = Splitmix64(ref x);
			ulong s1 = Splitmix64(ref x);
			ulong s2 = Splitmix64(ref x);
			ulong s3 = Splitmix64(ref x);
			while (true)
			{
				double num = (double)(RotateLeft(s1 * 5, 7) * 9 >> 11) * 1.1102230246251565E-16;
				ulong num2 = s1 << 17;
				s2 ^= s0;
				s3 ^= s1;
				s1 ^= s2;
				s0 ^= s3;
				s2 ^= num2;
				s3 = RotateLeft(s3, 45);
				yield return num;
			}
		}

		private static ulong Splitmix64(ref ulong x)
		{
			ulong num = (x += 11400714819323198485uL);
			long num2 = (long)(num ^ (num >> 30)) * -4658895280553007687L;
			long num3 = (long)((ulong)num2 ^ ((ulong)num2 >> 27)) * -7723592293110705685L;
			return (ulong)num3 ^ ((ulong)num3 >> 31);
		}

		private static ulong RotateLeft(ulong x, int k)
		{
			return (x << k) | (x >> 64 - k);
		}
	}
}
