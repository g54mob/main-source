using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Rfc8032
{
	public abstract class Ed448
	{
		public enum Algorithm
		{
			Ed448 = 0,
			Ed448ph = 1
		}

		private class PointExt
		{
			internal uint[] x;

			internal uint[] y;

			internal uint[] z;
		}

		private class PointPrecomp
		{
			internal uint[] x;

			internal uint[] y;
		}

		private const ulong M26UL = 67108863uL;

		private const ulong M28UL = 268435455uL;

		private const int PointBytes = 57;

		private const int ScalarUints = 14;

		private const int ScalarBytes = 57;

		public static readonly int PrehashSize;

		public static readonly int PublicKeySize;

		public static readonly int SecretKeySize;

		public static readonly int SignatureSize;

		private static readonly byte[] Dom4Prefix;

		private static readonly uint[] P;

		private static readonly uint[] L;

		private static readonly BigInteger N;

		private const int L_0 = 78101261;

		private const int L_1 = 141809365;

		private const int L_2 = 175155932;

		private const int L_3 = 64542499;

		private const int L_4 = 158326419;

		private const int L_5 = 191173276;

		private const int L_6 = 104575268;

		private const int L_7 = 137584065;

		private const int L4_0 = 43969588;

		private const int L4_1 = 30366549;

		private const int L4_2 = 163752818;

		private const int L4_3 = 258169998;

		private const int L4_4 = 96434764;

		private const int L4_5 = 227822194;

		private const int L4_6 = 149865618;

		private const int L4_7 = 550336261;

		private static readonly uint[] B_x;

		private static readonly uint[] B_y;

		private const int C_d = -39081;

		private const int WnafWidthBase = 7;

		private const int PrecompBlocks = 5;

		private const int PrecompTeeth = 5;

		private const int PrecompSpacing = 18;

		private const int PrecompPoints = 16;

		private const int PrecompMask = 15;

		private static readonly object precompLock;

		private static PointExt[] precompBaseTable;

		private static uint[] precompBase;

		private static byte[] CalculateS(byte[] r, byte[] k, byte[] s)
		{
			return null;
		}

		private static bool CheckContextVar(byte[] ctx)
		{
			return false;
		}

		private static int CheckPoint(uint[] x, uint[] y)
		{
			return 0;
		}

		private static int CheckPoint(uint[] x, uint[] y, uint[] z)
		{
			return 0;
		}

		private static bool CheckPointVar(byte[] p)
		{
			return false;
		}

		private static bool CheckScalarVar(byte[] s)
		{
			return false;
		}

		public static IXof CreatePrehash()
		{
			return null;
		}

		private static IXof CreateXof()
		{
			return null;
		}

		private static uint Decode16(byte[] bs, int off)
		{
			return 0u;
		}

		private static uint Decode24(byte[] bs, int off)
		{
			return 0u;
		}

		private static uint Decode32(byte[] bs, int off)
		{
			return 0u;
		}

		private static void Decode32(byte[] bs, int bsOff, uint[] n, int nOff, int nLen)
		{
		}

		private static bool DecodePointVar(byte[] p, int pOff, bool negate, PointExt r)
		{
			return false;
		}

		private static void DecodeScalar(byte[] k, int kOff, uint[] n)
		{
		}

		private static void Dom4(IXof d, byte x, byte[] y)
		{
		}

		private static void Encode24(uint n, byte[] bs, int off)
		{
		}

		private static void Encode32(uint n, byte[] bs, int off)
		{
		}

		private static void Encode56(ulong n, byte[] bs, int off)
		{
		}

		private static int EncodePoint(PointExt p, byte[] r, int rOff)
		{
			return 0;
		}

		public static void GeneratePrivateKey(SecureRandom random, byte[] k)
		{
		}

		public static void GeneratePublicKey(byte[] sk, int skOff, byte[] pk, int pkOff)
		{
		}

		private static sbyte[] GetWnafVar(uint[] n, int width)
		{
			return null;
		}

		private static void ImplSign(IXof d, byte[] h, byte[] s, byte[] pk, int pkOff, byte[] ctx, byte phflag, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
		{
		}

		private static void ImplSign(byte[] sk, int skOff, byte[] ctx, byte phflag, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
		{
		}

		private static void ImplSign(byte[] sk, int skOff, byte[] pk, int pkOff, byte[] ctx, byte phflag, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
		{
		}

		private static bool ImplVerify(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] ctx, byte phflag, byte[] m, int mOff, int mLen)
		{
			return false;
		}

		private static void PointAddVar(bool negate, PointExt p, PointExt r)
		{
		}

		private static void PointAddPrecomp(PointPrecomp p, PointExt r)
		{
		}

		private static PointExt PointCopy(PointExt p)
		{
			return null;
		}

		private static void PointDouble(PointExt r)
		{
		}

		private static void PointExtendXY(PointExt p)
		{
		}

		private static void PointLookup(int block, int index, PointPrecomp p)
		{
		}

		private static PointExt[] PointPrecompVar(PointExt p, int count)
		{
			return null;
		}

		private static void PointSetNeutral(PointExt p)
		{
		}

		public static void Precompute()
		{
		}

		private static void PruneScalar(byte[] n, int nOff, byte[] r)
		{
		}

		private static byte[] ReduceScalar(byte[] n)
		{
			return null;
		}

		private static void ScalarMultBase(byte[] k, PointExt r)
		{
		}

		private static void ScalarMultBaseEncoded(byte[] k, byte[] r, int rOff)
		{
		}

		internal static void ScalarMultBaseXY(byte[] k, int kOff, uint[] x, uint[] y)
		{
		}

		private static void ScalarMultStrausVar(uint[] nb, uint[] np, PointExt p, PointExt r)
		{
		}

		public static void Sign(byte[] sk, int skOff, byte[] ctx, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
		{
		}

		public static void Sign(byte[] sk, int skOff, byte[] pk, int pkOff, byte[] ctx, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
		{
		}

		public static void SignPrehash(byte[] sk, int skOff, byte[] ctx, byte[] ph, int phOff, byte[] sig, int sigOff)
		{
		}

		public static void SignPrehash(byte[] sk, int skOff, byte[] pk, int pkOff, byte[] ctx, byte[] ph, int phOff, byte[] sig, int sigOff)
		{
		}

		public static void SignPrehash(byte[] sk, int skOff, byte[] ctx, IXof ph, byte[] sig, int sigOff)
		{
		}

		public static void SignPrehash(byte[] sk, int skOff, byte[] pk, int pkOff, byte[] ctx, IXof ph, byte[] sig, int sigOff)
		{
		}

		public static bool Verify(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] ctx, byte[] m, int mOff, int mLen)
		{
			return false;
		}

		public static bool VerifyPrehash(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] ctx, byte[] ph, int phOff)
		{
			return false;
		}

		public static bool VerifyPrehash(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] ctx, IXof ph)
		{
			return false;
		}
	}
}
