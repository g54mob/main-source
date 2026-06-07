using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ZLinq.Internal
{
	internal static class RandomShared
	{
		internal sealed class Xoshiro256StarStar
		{
			private ulong _s0;

			private ulong _s1;

			private ulong _s2;

			private ulong _s3;

			public Xoshiro256StarStar()
			{
				Span<ulong> span = stackalloc ulong[4];
				do
				{
					RandomNumberGenerator.Fill(MemoryMarshal.AsBytes(span));
					_s0 = span[0];
					_s1 = span[1];
					_s2 = span[2];
					_s3 = span[3];
				}
				while (_s0 == 0L && _s1 == 0L && _s2 == 0L && _s3 == 0L);
			}

			public ulong NextUInt64()
			{
				ulong s = _s0;
				ulong s2 = _s1;
				ulong s3 = _s2;
				ulong s4 = _s3;
				ulong result = ((s2 << 7) ^ (s2 >> 57)) * 9;
				ulong num = s2 << 17;
				s3 ^= s;
				s4 ^= s2;
				s2 ^= s3;
				s ^= s4;
				s3 ^= num;
				s4 = (s4 << 45) ^ (s4 >> 19);
				_s0 = s;
				_s1 = s2;
				_s2 = s3;
				_s3 = s4;
				return result;
			}

			private static ulong BigMul(ulong a, ulong b, out ulong lo)
			{
				int num = (int)a;
				uint num2 = (uint)(a >> 32);
				uint num3 = (uint)b;
				uint num4 = (uint)(b >> 32);
				ulong num5 = (ulong)(uint)num * (ulong)num3;
				ulong num6 = (ulong)(uint)num * (ulong)num4;
				ulong num7 = (ulong)num2 * (ulong)num3;
				long num8 = (long)num2 * (long)num4;
				ulong num9 = num6 + num7;
				ulong num10 = (ulong)((long)((num9 < num6) ? 1 : 0) << 32);
				lo = num5 + (num9 << 32);
				num10 += (ulong)((lo < num5) ? 1 : 0);
				return (ulong)(num8 + (long)(num9 >> 32)) + num10;
			}

			public ulong NextUInt64(ulong maxExclusive)
			{
				ulong lo;
				ulong result = BigMul(NextUInt64(), maxExclusive, out lo);
				if (lo < maxExclusive)
				{
					ulong num = (0 - maxExclusive) % maxExclusive;
					while (lo < num)
					{
						result = BigMul(NextUInt64(), maxExclusive, out lo);
					}
				}
				return result;
			}

			public void Shuffle<T>(Span<T> values)
			{
				ulong num = 2432902008176640000uL;
				int i = Math.Min(20, values.Length);
				int num2 = 1;
				while (num2 < values.Length)
				{
					ulong lo = NextUInt64();
					ulong num3 = lo * num;
					if (num3 > 0 - num)
					{
						ulong num5;
						ulong num6;
						do
						{
							ulong lo2;
							ulong num4 = BigMul(NextUInt64(), num, out lo2);
							num5 = num3 + num4;
							num6 = (ulong)((num5 < num3) ? 1 : 0);
							num3 = lo2;
						}
						while (num5 == ulong.MaxValue);
						lo += num6;
					}
					for (int j = num2; j < i; j++)
					{
						int index = (int)BigMul(lo, (ulong)(j + 1), out lo);
						T val = values[j];
						values[j] = values[index];
						values[index] = val;
					}
					num2 = i;
					num = (ulong)(num2 + 1);
					ulong lo3;
					for (i = num2 + 1; i < values.Length && BigMul(num, (ulong)(i + 1), out lo3) == 0L; i++)
					{
						num = lo3;
					}
				}
			}

			public void PartialShuffle<T>(Span<T> values, int count)
			{
				count = Math.Min(count, values.Length);
				int num = 0;
				while (num < count)
				{
					ulong num2 = (ulong)(values.Length - num);
					int i;
					if (num2 <= 20)
					{
						num2 = 2432902008176640000uL;
						i = count;
					}
					else
					{
						ulong lo;
						for (i = num + 1; i < count && BigMul(num2, (ulong)(values.Length - i), out lo) == 0L; i++)
						{
							num2 = lo;
						}
					}
					ulong lo2 = NextUInt64();
					ulong num3 = lo2 * num2;
					if (num3 > 0 - num2)
					{
						ulong num5;
						ulong num6;
						do
						{
							ulong lo3;
							ulong num4 = BigMul(NextUInt64(), num2, out lo3);
							num5 = num3 + num4;
							num6 = (ulong)((num5 < num3) ? 1 : 0);
							num3 = lo3;
						}
						while (num5 == ulong.MaxValue);
						lo2 += num6;
					}
					for (int j = num; j < i; j++)
					{
						int index = j + (int)BigMul(lo2, (ulong)(values.Length - j), out lo2);
						T val = values[j];
						values[j] = values[index];
						values[index] = val;
					}
					num = i;
				}
			}
		}

		[ThreadStatic]
		private static Xoshiro256StarStar? s_Shared;

		private static Xoshiro256StarStar Shared => s_Shared ?? (s_Shared = new Xoshiro256StarStar());

		public static void Shuffle<T>(Span<T> span)
		{
			Shared.Shuffle(span);
		}

		public static void PartialShuffle<T>(Span<T> span, int count)
		{
			if (count >= span.Length)
			{
				Shared.Shuffle(span);
			}
			else
			{
				Shared.PartialShuffle(span, count);
			}
		}
	}
}
