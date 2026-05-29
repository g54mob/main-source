using System;

namespace Photon.SocketServer.Numeric
{
	internal class BigInteger
	{
		private const int maxLength = 70;

		public static readonly int[] primesBelow2000;

		private uint[] data;

		public int dataLength;

		public BigInteger()
		{
		}

		public BigInteger(long value)
		{
		}

		public BigInteger(ulong value)
		{
		}

		public BigInteger(BigInteger bi)
		{
		}

		public BigInteger(string value, int radix)
		{
		}

		public BigInteger(byte[] inData)
		{
		}

		public BigInteger(byte[] inData, int inLen)
		{
		}

		public BigInteger(uint[] inData)
		{
		}

		public static implicit operator BigInteger(long value)
		{
			return null;
		}

		public static implicit operator BigInteger(ulong value)
		{
			return null;
		}

		public static implicit operator BigInteger(int value)
		{
			return null;
		}

		public static implicit operator BigInteger(uint value)
		{
			return null;
		}

		public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator ++(BigInteger bi1)
		{
			return null;
		}

		public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator --(BigInteger bi1)
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

		private static int shiftLeft(uint[] buffer, int shiftVal)
		{
			return 0;
		}

		public static BigInteger operator >>(BigInteger bi1, int shiftVal)
		{
			return null;
		}

		private static int shiftRight(uint[] buffer, int shiftVal)
		{
			return 0;
		}

		public static BigInteger operator ~(BigInteger bi1)
		{
			return null;
		}

		public static BigInteger operator -(BigInteger bi1)
		{
			return null;
		}

		public static bool operator ==(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		public static bool operator !=(BigInteger bi1, BigInteger bi2)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
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

		private static void multiByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
		}

		private static void singleByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
		}

		public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator &(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator |(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public static BigInteger operator ^(BigInteger bi1, BigInteger bi2)
		{
			return null;
		}

		public BigInteger max(BigInteger bi)
		{
			return null;
		}

		public BigInteger min(BigInteger bi)
		{
			return null;
		}

		public BigInteger abs()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(int radix)
		{
			return null;
		}

		public string ToHexString()
		{
			return null;
		}

		public BigInteger ModPow(BigInteger exp, BigInteger n)
		{
			return null;
		}

		private BigInteger BarrettReduction(BigInteger x, BigInteger n, BigInteger constant)
		{
			return null;
		}

		public BigInteger gcd(BigInteger bi)
		{
			return null;
		}

		public static BigInteger GenerateRandom(int bits)
		{
			return null;
		}

		public void genRandomBits(int bits, Random rand)
		{
		}

		public int bitCount()
		{
			return 0;
		}

		public bool FermatLittleTest(int confidence)
		{
			return false;
		}

		public bool RabinMillerTest(int confidence)
		{
			return false;
		}

		public bool SolovayStrassenTest(int confidence)
		{
			return false;
		}

		public bool LucasStrongTest()
		{
			return false;
		}

		private bool LucasStrongTestHelper(BigInteger thisVal)
		{
			return false;
		}

		public bool isProbablePrime(int confidence)
		{
			return false;
		}

		public bool isProbablePrime()
		{
			return false;
		}

		public int IntValue()
		{
			return 0;
		}

		public long LongValue()
		{
			return 0L;
		}

		public static int Jacobi(BigInteger a, BigInteger b)
		{
			return 0;
		}

		public static BigInteger genPseudoPrime(int bits, int confidence, Random rand)
		{
			return null;
		}

		public BigInteger genCoPrime(int bits, Random rand)
		{
			return null;
		}

		public BigInteger modInverse(BigInteger modulus)
		{
			return null;
		}

		public byte[] GetBytes()
		{
			return null;
		}

		public void setBit(uint bitNum)
		{
		}

		public void unsetBit(uint bitNum)
		{
		}

		public BigInteger sqrt()
		{
			return null;
		}

		public static BigInteger[] LucasSequence(BigInteger P, BigInteger Q, BigInteger k, BigInteger n)
		{
			return null;
		}

		private static BigInteger[] LucasSequenceHelper(BigInteger P, BigInteger Q, BigInteger k, BigInteger n, BigInteger constant, int s)
		{
			return null;
		}

		public static void MulDivTest(int rounds)
		{
		}

		public static void RSATest(int rounds)
		{
		}

		public static void RSATest2(int rounds)
		{
		}

		public static void SqrtTest(int rounds)
		{
		}

		public static void Main(string[] args)
		{
		}
	}
}
