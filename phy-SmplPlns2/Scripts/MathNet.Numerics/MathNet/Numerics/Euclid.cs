using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MathNet.Numerics
{
	public static class Euclid
	{
		private static readonly int[] MultiplyDeBruijnBitPosition = new int[32]
		{
			0, 9, 1, 10, 13, 21, 2, 29, 11, 14,
			16, 18, 22, 25, 3, 30, 8, 12, 20, 28,
			15, 17, 24, 7, 19, 27, 23, 6, 26, 5,
			4, 31
		};

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Modulus(double dividend, double divisor)
		{
			return (dividend % divisor + divisor) % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Modulus(float dividend, float divisor)
		{
			return (dividend % divisor + divisor) % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Modulus(int dividend, int divisor)
		{
			return (dividend % divisor + divisor) % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long Modulus(long dividend, long divisor)
		{
			return (dividend % divisor + divisor) % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static BigInteger Modulus(BigInteger dividend, BigInteger divisor)
		{
			return (dividend % divisor + divisor) % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Remainder(double dividend, double divisor)
		{
			return dividend % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Remainder(float dividend, float divisor)
		{
			return dividend % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Remainder(int dividend, int divisor)
		{
			return dividend % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long Remainder(long dividend, long divisor)
		{
			return dividend % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static BigInteger Remainder(BigInteger dividend, BigInteger divisor)
		{
			return dividend % divisor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsEven(this int number)
		{
			return (number & 1) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsEven(this long number)
		{
			return (number & 1) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsOdd(this int number)
		{
			return (number & 1) == 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsOdd(this long number)
		{
			return (number & 1) == 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPowerOfTwo(this int number)
		{
			if (number > 0)
			{
				return (number & (number - 1)) == 0;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPowerOfTwo(this long number)
		{
			if (number > 0)
			{
				return (number & (number - 1)) == 0;
			}
			return false;
		}

		public static bool IsPerfectSquare(this int number)
		{
			if (number < 0)
			{
				return false;
			}
			int num = number & 0xF;
			if (num > 9)
			{
				return false;
			}
			if (num == 0 || num == 1 || num == 4 || num == 9)
			{
				int num2 = (int)Math.Floor(Math.Sqrt(number) + 0.5);
				return num2 * num2 == number;
			}
			return false;
		}

		public static bool IsPerfectSquare(this long number)
		{
			if (number < 0)
			{
				return false;
			}
			int num = (int)(number & 0xF);
			if (num > 9)
			{
				return false;
			}
			if (num == 0 || num == 1 || num == 4 || num == 9)
			{
				long num2 = (long)Math.Floor(Math.Sqrt(number) + 0.5);
				return num2 * num2 == number;
			}
			return false;
		}

		public static int PowerOfTwo(this int exponent)
		{
			if (exponent < 0 || exponent >= 31)
			{
				throw new ArgumentOutOfRangeException("exponent");
			}
			return 1 << exponent;
		}

		public static long PowerOfTwo(this long exponent)
		{
			if (exponent < 0 || exponent >= 63)
			{
				throw new ArgumentOutOfRangeException("exponent");
			}
			return 1L << (int)exponent;
		}

		public static int Log2(this int number)
		{
			number |= number >> 1;
			number |= number >> 2;
			number |= number >> 4;
			number |= number >> 8;
			number |= number >> 16;
			return MultiplyDeBruijnBitPosition[(uint)((long)number * 130329821L) >> 27];
		}

		public static int CeilingToPowerOfTwo(this int number)
		{
			if (number == int.MinValue)
			{
				return 0;
			}
			if (number > 1073741824)
			{
				throw new ArgumentOutOfRangeException("number");
			}
			number--;
			number |= number >> 1;
			number |= number >> 2;
			number |= number >> 4;
			number |= number >> 8;
			number |= number >> 16;
			return number + 1;
		}

		public static long CeilingToPowerOfTwo(this long number)
		{
			if (number == long.MinValue)
			{
				return 0L;
			}
			if (number > 4611686018427387904L)
			{
				throw new ArgumentOutOfRangeException("number");
			}
			number--;
			number |= number >> 1;
			number |= number >> 2;
			number |= number >> 4;
			number |= number >> 8;
			number |= number >> 16;
			number |= number >> 32;
			return number + 1;
		}

		public static long GreatestCommonDivisor(long a, long b)
		{
			while (b != 0L)
			{
				long num = a % b;
				a = b;
				b = num;
			}
			return Math.Abs(a);
		}

		public static long GreatestCommonDivisor(IList<long> integers)
		{
			if (integers == null)
			{
				throw new ArgumentNullException("integers");
			}
			if (integers.Count == 0)
			{
				return 0L;
			}
			long num = Math.Abs(integers[0]);
			for (int i = 1; i < integers.Count; i++)
			{
				if (num <= 1)
				{
					break;
				}
				num = GreatestCommonDivisor(num, integers[i]);
			}
			return num;
		}

		public static long GreatestCommonDivisor(params long[] integers)
		{
			return GreatestCommonDivisor((IList<long>)integers);
		}

		public static long ExtendedGreatestCommonDivisor(long a, long b, out long x, out long y)
		{
			long num = 1L;
			long num2 = 0L;
			long num3 = 0L;
			long num4 = 1L;
			while (b != 0L)
			{
				long result;
				long num5 = Math.DivRem(a, b, out result);
				a = b;
				b = result;
				long num6 = num3;
				num3 = num - num5 * num3;
				num = num6;
				long num7 = num4;
				num4 = num2 - num5 * num4;
				num2 = num7;
			}
			if (a >= 0)
			{
				x = num;
				y = num2;
				return a;
			}
			x = -num;
			y = -num2;
			return -a;
		}

		public static long LeastCommonMultiple(long a, long b)
		{
			if (a == 0L || b == 0L)
			{
				return 0L;
			}
			return Math.Abs(a / GreatestCommonDivisor(a, b) * b);
		}

		public static long LeastCommonMultiple(IList<long> integers)
		{
			if (integers == null)
			{
				throw new ArgumentNullException("integers");
			}
			if (integers.Count == 0)
			{
				return 1L;
			}
			long num = Math.Abs(integers[0]);
			for (int i = 1; i < integers.Count; i++)
			{
				num = LeastCommonMultiple(num, integers[i]);
			}
			return num;
		}

		public static long LeastCommonMultiple(params long[] integers)
		{
			return LeastCommonMultiple((IList<long>)integers);
		}

		public static BigInteger GreatestCommonDivisor(BigInteger a, BigInteger b)
		{
			return BigInteger.GreatestCommonDivisor(a, b);
		}

		public static BigInteger GreatestCommonDivisor(IList<BigInteger> integers)
		{
			if (integers == null)
			{
				throw new ArgumentNullException("integers");
			}
			if (integers.Count == 0)
			{
				return 0;
			}
			BigInteger bigInteger = BigInteger.Abs(integers[0]);
			for (int i = 1; i < integers.Count; i++)
			{
				if (!(bigInteger > BigInteger.One))
				{
					break;
				}
				bigInteger = GreatestCommonDivisor(bigInteger, integers[i]);
			}
			return bigInteger;
		}

		public static BigInteger GreatestCommonDivisor(params BigInteger[] integers)
		{
			return GreatestCommonDivisor((IList<BigInteger>)integers);
		}

		public static BigInteger ExtendedGreatestCommonDivisor(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
		{
			BigInteger bigInteger = BigInteger.One;
			BigInteger bigInteger2 = BigInteger.Zero;
			BigInteger bigInteger3 = BigInteger.Zero;
			BigInteger bigInteger4 = BigInteger.One;
			while (!b.IsZero)
			{
				BigInteger remainder;
				BigInteger bigInteger5 = BigInteger.DivRem(a, b, out remainder);
				a = b;
				b = remainder;
				BigInteger bigInteger6 = bigInteger3;
				bigInteger3 = bigInteger - bigInteger5 * bigInteger3;
				bigInteger = bigInteger6;
				BigInteger bigInteger7 = bigInteger4;
				bigInteger4 = bigInteger2 - bigInteger5 * bigInteger4;
				bigInteger2 = bigInteger7;
			}
			if (a >= BigInteger.Zero)
			{
				x = bigInteger;
				y = bigInteger2;
				return a;
			}
			x = -bigInteger;
			y = -bigInteger2;
			return -a;
		}

		public static BigInteger LeastCommonMultiple(BigInteger a, BigInteger b)
		{
			if (a.IsZero || b.IsZero)
			{
				return BigInteger.Zero;
			}
			return BigInteger.Abs(a / BigInteger.GreatestCommonDivisor(a, b) * b);
		}

		public static BigInteger LeastCommonMultiple(IList<BigInteger> integers)
		{
			if (integers == null)
			{
				throw new ArgumentNullException("integers");
			}
			if (integers.Count == 0)
			{
				return 1;
			}
			BigInteger bigInteger = BigInteger.Abs(integers[0]);
			for (int i = 1; i < integers.Count; i++)
			{
				bigInteger = LeastCommonMultiple(bigInteger, integers[i]);
			}
			return bigInteger;
		}

		public static BigInteger LeastCommonMultiple(params BigInteger[] integers)
		{
			return LeastCommonMultiple((IList<BigInteger>)integers);
		}
	}
}
