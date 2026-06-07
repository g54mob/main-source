namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Raw
{
	internal abstract class Nat
	{
		private const ulong M = 4294967295uL;

		public static uint Add(int len, uint[] x, uint[] y, uint[] z)
		{
			return 0u;
		}

		public static uint Add33At(int len, uint x, uint[] z, int zPos)
		{
			return 0u;
		}

		public static uint Add33At(int len, uint x, uint[] z, int zOff, int zPos)
		{
			return 0u;
		}

		public static uint Add33To(int len, uint x, uint[] z)
		{
			return 0u;
		}

		public static uint Add33To(int len, uint x, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint AddBothTo(int len, uint[] x, uint[] y, uint[] z)
		{
			return 0u;
		}

		public static uint AddBothTo(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint AddDWordAt(int len, ulong x, uint[] z, int zPos)
		{
			return 0u;
		}

		public static uint AddDWordAt(int len, ulong x, uint[] z, int zOff, int zPos)
		{
			return 0u;
		}

		public static uint AddDWordTo(int len, ulong x, uint[] z)
		{
			return 0u;
		}

		public static uint AddDWordTo(int len, ulong x, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint AddTo(int len, uint[] x, uint[] z)
		{
			return 0u;
		}

		public static uint AddTo(int len, uint[] x, int xOff, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint AddTo(int len, uint[] x, int xOff, uint[] z, int zOff, uint cIn)
		{
			return 0u;
		}

		public static uint AddToEachOther(int len, uint[] u, int uOff, uint[] v, int vOff)
		{
			return 0u;
		}

		public static uint AddWordAt(int len, uint x, uint[] z, int zPos)
		{
			return 0u;
		}

		public static uint AddWordAt(int len, uint x, uint[] z, int zOff, int zPos)
		{
			return 0u;
		}

		public static uint AddWordTo(int len, uint x, uint[] z)
		{
			return 0u;
		}

		public static uint AddWordTo(int len, uint x, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint CAdd(int len, int mask, uint[] x, uint[] y, uint[] z)
		{
			return 0u;
		}

		public static void CMov(int len, int mask, uint[] x, int xOff, uint[] z, int zOff)
		{
		}

		public static void CMov(int len, int mask, int[] x, int xOff, int[] z, int zOff)
		{
		}

		public static void Copy(int len, uint[] x, uint[] z)
		{
		}

		public static uint[] Copy(int len, uint[] x)
		{
			return null;
		}

		public static void Copy(int len, uint[] x, int xOff, uint[] z, int zOff)
		{
		}

		public static ulong[] Copy64(int len, ulong[] x)
		{
			return null;
		}

		public static void Copy64(int len, ulong[] x, ulong[] z)
		{
		}

		public static void Copy64(int len, ulong[] x, int xOff, ulong[] z, int zOff)
		{
		}

		public static uint[] Create(int len)
		{
			return null;
		}

		public static ulong[] Create64(int len)
		{
			return null;
		}

		public static int CSub(int len, int mask, uint[] x, uint[] y, uint[] z)
		{
			return 0;
		}

		public static int CSub(int len, int mask, uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
		{
			return 0;
		}

		public static int Dec(int len, uint[] z)
		{
			return 0;
		}

		public static int Dec(int len, uint[] x, uint[] z)
		{
			return 0;
		}

		public static int DecAt(int len, uint[] z, int zPos)
		{
			return 0;
		}

		public static int DecAt(int len, uint[] z, int zOff, int zPos)
		{
			return 0;
		}

		public static bool Eq(int len, uint[] x, uint[] y)
		{
			return false;
		}

		public static uint[] FromBigInteger(int bits, BigInteger x)
		{
			return null;
		}

		public static ulong[] FromBigInteger64(int bits, BigInteger x)
		{
			return null;
		}

		public static uint GetBit(uint[] x, int bit)
		{
			return 0u;
		}

		public static bool Gte(int len, uint[] x, uint[] y)
		{
			return false;
		}

		public static uint Inc(int len, uint[] z)
		{
			return 0u;
		}

		public static uint Inc(int len, uint[] x, uint[] z)
		{
			return 0u;
		}

		public static uint IncAt(int len, uint[] z, int zPos)
		{
			return 0u;
		}

		public static uint IncAt(int len, uint[] z, int zOff, int zPos)
		{
			return 0u;
		}

		public static bool IsOne(int len, uint[] x)
		{
			return false;
		}

		public static bool IsZero(int len, uint[] x)
		{
			return false;
		}

		public static void Mul(int len, uint[] x, uint[] y, uint[] zz)
		{
		}

		public static void Mul(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
		{
		}

		public static void Mul(uint[] x, int xOff, int xLen, uint[] y, int yOff, int yLen, uint[] zz, int zzOff)
		{
		}

		public static uint MulAddTo(int len, uint[] x, uint[] y, uint[] zz)
		{
			return 0u;
		}

		public static uint MulAddTo(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] zz, int zzOff)
		{
			return 0u;
		}

		public static uint Mul31BothAdd(int len, uint a, uint[] x, uint b, uint[] y, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint MulWord(int len, uint x, uint[] y, uint[] z)
		{
			return 0u;
		}

		public static uint MulWord(int len, uint x, uint[] y, int yOff, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint MulWordAddTo(int len, uint x, uint[] y, int yOff, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint MulWordDwordAddAt(int len, uint x, ulong y, uint[] z, int zPos)
		{
			return 0u;
		}

		public static uint ShiftDownBit(int len, uint[] z, uint c)
		{
			return 0u;
		}

		public static uint ShiftDownBit(int len, uint[] z, int zOff, uint c)
		{
			return 0u;
		}

		public static uint ShiftDownBit(int len, uint[] x, uint c, uint[] z)
		{
			return 0u;
		}

		public static uint ShiftDownBit(int len, uint[] x, int xOff, uint c, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint ShiftDownBits(int len, uint[] z, int bits, uint c)
		{
			return 0u;
		}

		public static uint ShiftDownBits(int len, uint[] z, int zOff, int bits, uint c)
		{
			return 0u;
		}

		public static uint ShiftDownBits(int len, uint[] x, int bits, uint c, uint[] z)
		{
			return 0u;
		}

		public static uint ShiftDownBits(int len, uint[] x, int xOff, int bits, uint c, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint ShiftDownWord(int len, uint[] z, uint c)
		{
			return 0u;
		}

		public static uint ShiftUpBit(int len, uint[] z, uint c)
		{
			return 0u;
		}

		public static uint ShiftUpBit(int len, uint[] z, int zOff, uint c)
		{
			return 0u;
		}

		public static uint ShiftUpBit(int len, uint[] x, uint c, uint[] z)
		{
			return 0u;
		}

		public static uint ShiftUpBit(int len, uint[] x, int xOff, uint c, uint[] z, int zOff)
		{
			return 0u;
		}

		public static ulong ShiftUpBit64(int len, ulong[] x, int xOff, ulong c, ulong[] z, int zOff)
		{
			return 0uL;
		}

		public static uint ShiftUpBits(int len, uint[] z, int bits, uint c)
		{
			return 0u;
		}

		public static uint ShiftUpBits(int len, uint[] z, int zOff, int bits, uint c)
		{
			return 0u;
		}

		public static ulong ShiftUpBits64(int len, ulong[] z, int zOff, int bits, ulong c)
		{
			return 0uL;
		}

		public static uint ShiftUpBits(int len, uint[] x, int bits, uint c, uint[] z)
		{
			return 0u;
		}

		public static uint ShiftUpBits(int len, uint[] x, int xOff, int bits, uint c, uint[] z, int zOff)
		{
			return 0u;
		}

		public static ulong ShiftUpBits64(int len, ulong[] x, int xOff, int bits, ulong c, ulong[] z, int zOff)
		{
			return 0uL;
		}

		public static void Square(int len, uint[] x, uint[] zz)
		{
		}

		public static void Square(int len, uint[] x, int xOff, uint[] zz, int zzOff)
		{
		}

		public static uint SquareWordAdd(uint[] x, int xPos, uint[] z)
		{
			return 0u;
		}

		public static uint SquareWordAdd(uint[] x, int xOff, int xPos, uint[] z, int zOff)
		{
			return 0u;
		}

		public static uint SquareWordAddTo(uint[] x, int xPos, uint[] z)
		{
			return 0u;
		}

		public static uint SquareWordAddTo(uint[] x, int xOff, int xPos, uint[] z, int zOff)
		{
			return 0u;
		}

		public static int Sub(int len, uint[] x, uint[] y, uint[] z)
		{
			return 0;
		}

		public static int Sub(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
		{
			return 0;
		}

		public static int Sub33At(int len, uint x, uint[] z, int zPos)
		{
			return 0;
		}

		public static int Sub33At(int len, uint x, uint[] z, int zOff, int zPos)
		{
			return 0;
		}

		public static int Sub33From(int len, uint x, uint[] z)
		{
			return 0;
		}

		public static int Sub33From(int len, uint x, uint[] z, int zOff)
		{
			return 0;
		}

		public static int SubBothFrom(int len, uint[] x, uint[] y, uint[] z)
		{
			return 0;
		}

		public static int SubBothFrom(int len, uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
		{
			return 0;
		}

		public static int SubDWordAt(int len, ulong x, uint[] z, int zPos)
		{
			return 0;
		}

		public static int SubDWordAt(int len, ulong x, uint[] z, int zOff, int zPos)
		{
			return 0;
		}

		public static int SubDWordFrom(int len, ulong x, uint[] z)
		{
			return 0;
		}

		public static int SubDWordFrom(int len, ulong x, uint[] z, int zOff)
		{
			return 0;
		}

		public static int SubFrom(int len, uint[] x, uint[] z)
		{
			return 0;
		}

		public static int SubFrom(int len, uint[] x, int xOff, uint[] z, int zOff)
		{
			return 0;
		}

		public static int SubWordAt(int len, uint x, uint[] z, int zPos)
		{
			return 0;
		}

		public static int SubWordAt(int len, uint x, uint[] z, int zOff, int zPos)
		{
			return 0;
		}

		public static int SubWordFrom(int len, uint x, uint[] z)
		{
			return 0;
		}

		public static int SubWordFrom(int len, uint x, uint[] z, int zOff)
		{
			return 0;
		}

		public static BigInteger ToBigInteger(int len, uint[] x)
		{
			return null;
		}

		public static void Zero(int len, uint[] z)
		{
		}
	}
}
