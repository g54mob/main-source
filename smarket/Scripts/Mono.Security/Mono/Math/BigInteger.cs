using System;
using System.Security.Cryptography;

namespace Mono.Math
{
	public class BigInteger
	{
		public enum Sign
		{
			Negative = -1,
			Zero = 0,
			Positive = 1
		}

		public sealed class ModulusRing
		{
			private BigInteger mod;

			private BigInteger constant;

			public ModulusRing(BigInteger modulus)
			{
			}

			public void BarrettReduction(BigInteger x)
			{
			}

			public BigInteger Multiply(BigInteger a, BigInteger b)
			{
				return null;
			}

			public BigInteger Difference(BigInteger a, BigInteger b)
			{
				return null;
			}

			public BigInteger Pow(BigInteger a, BigInteger k)
			{
				return null;
			}

			[CLSCompliant(false)]
			public BigInteger Pow(uint b, BigInteger exp)
			{
				return null;
			}
		}

		private sealed class Kernel
		{
			public static BigInteger AddSameSign(BigInteger bi1, BigInteger bi2)
			{
				return null;
			}

			public static BigInteger Subtract(BigInteger big, BigInteger small)
			{
				return null;
			}

			public static void MinusEq(BigInteger big, BigInteger small)
			{
			}

			public static void PlusEq(BigInteger bi1, BigInteger bi2)
			{
			}

			public static Sign Compare(BigInteger bi1, BigInteger bi2)
			{
				return default(Sign);
			}

			public static uint SingleByteDivideInPlace(BigInteger n, uint d)
			{
				return 0u;
			}

			public static uint DwordMod(BigInteger n, uint d)
			{
				return 0u;
			}

			public static BigInteger[] DwordDivMod(BigInteger n, uint d)
			{
				return null;
			}

			public static BigInteger[] multiByteDivide(BigInteger bi1, BigInteger bi2)
			{
				return null;
			}

			public static BigInteger LeftShift(BigInteger bi, int n)
			{
				return null;
			}

			public static BigInteger RightShift(BigInteger bi, int n)
			{
				return null;
			}

			public static void Multiply(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset)
			{
			}

			public static void MultiplyMod2p32pmod(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod)
			{
			}

			public static uint modInverse(BigInteger bi, uint modulus)
			{
				return 0u;
			}

			public static BigInteger modInverse(BigInteger bi, BigInteger modulus)
			{
				return null;
			}
		}

		private uint length;

		private uint[] data;

		internal static readonly uint[] smallPrimes;

		private static RandomNumberGenerator rng;

		private static RandomNumberGenerator Rng => null;

		[CLSCompliant(false)]
		public BigInteger(Sign sign, uint len)
		{
		}

		public BigInteger(BigInteger bi)
		{
		}

		[CLSCompliant(false)]
		public BigInteger(BigInteger bi, uint len)
		{
		}

		public BigInteger(byte[] inData)
		{
		}

		[CLSCompliant(false)]
		public BigInteger(uint ui)
		{
		}

		[CLSCompliant(false)]
		public static implicit operator BigInteger(uint value)
		{
			return null;
		}

		public static implicit operator BigInteger(int value)
		{
			return null;
		}

		public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		[CLSCompliant(false)]
		public static uint operator %(BigInteger bi, uint ui)
		{
			return 0u;
		}

		public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator <<(BigInteger bi1, int shiftVal)
		{
			return null;
		}

		public static BigInteger operator >>(BigInteger bi1, int shiftVal)
		{
			return null;
		}

		public static BigInteger GenerateRandom(int bits, RandomNumberGenerator rng)
		{
			return null;
		}

		public static BigInteger GenerateRandom(int bits)
		{
			return null;
		}

		public int BitCount()
		{
			return 0;
		}

		public bool TestBit(int bitNum)
		{
			return false;
		}

		[CLSCompliant(false)]
		public void SetBit(uint bitNum)
		{
		}

		[CLSCompliant(false)]
		public void SetBit(uint bitNum, bool value)
		{
		}

		public int LowestSetBit()
		{
			return 0;
		}

		public byte[] GetBytes()
		{
			return null;
		}

		[CLSCompliant(false)]
		public static bool operator ==(BigInteger bi1, uint ui)
		{
			return false;
		}

		[CLSCompliant(false)]
		public static bool operator !=(BigInteger bi1, uint ui)
		{
			return false;
		}

		public static bool operator ==(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		public static bool operator !=(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		public static bool operator >(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		public static bool operator <(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		public static bool operator >=(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		public static bool operator <=(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		[CLSCompliant(false)]
		public string ToString(uint radix)
		{
			return null;
		}

		[CLSCompliant(false)]
		public string ToString(uint radix, string characterSet)
		{
			return null;
		}

		private void Normalize()
		{
		}

		public void Clear()
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public BigInteger ModInverse(BigInteger modulus)
		{
			return null;
		}

		public BigInteger ModPow(BigInteger exp, BigInteger n)
		{
			return null;
		}

		public static BigInteger GeneratePseudoPrime(int bits)
		{
			return null;
		}

		public void Incr2()
		{
		}
	}
}
