using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Rfc8032
{
	public abstract class Ed25519
	{
		public enum Algorithm
		{
			Ed25519 = 0,
			Ed25519ctx = 1,
			Ed25519ph = 2
		}

		private class PointAccum
		{
			internal int[] x;

			internal int[] y;

			internal int[] z;

			internal int[] u;

			internal int[] v;
		}

		private class PointExt
		{
			internal int[] x;

			internal int[] y;

			internal int[] z;

			internal int[] t;
		}

		private class PointPrecomp
		{
			internal int[] ypx_h;

			internal int[] ymx_h;

			internal int[] xyd;
		}

		private const long M28L = 268435455L;

		private const long M32L = 4294967295L;

		private const int PointBytes = 32;

		private const int ScalarUints = 8;

		private const int ScalarBytes = 32;

		public static readonly int PrehashSize;

		public static readonly int PublicKeySize;

		public static readonly int SecretKeySize;

		public static readonly int SignatureSize;

		private static readonly byte[] Dom2Prefix;

		private static readonly uint[] P;

		private static readonly uint[] L;

		private const int L0 = -50998291;

		private const int L1 = 19280294;

		private const int L2 = 127719000;

		private const int L3 = -6428113;

		private const int L4 = 5343;

		private static readonly int[] B_x;

		private static readonly int[] B_y;

		private static readonly int[] C_d;

		private static readonly int[] C_d2;

		private static readonly int[] C_d4;

		private const int WnafWidthBase = 7;

		private const int PrecompBlocks = 8;

		private const int PrecompTeeth = 4;

		private const int PrecompSpacing = 8;

		private const int PrecompPoints = 8;

		private const int PrecompMask = 7;

		private static readonly object precompLock;

		private static PointExt[] precompBaseTable;

		private static int[] precompBase;

		private static byte[] CalculateS(byte[] r, byte[] k, byte[] s)
		{
			return null;
		}

		private static bool CheckContextVar(byte[] ctx, byte phflag)
		{
			return false;
		}

		private static int CheckPoint(int[] x, int[] y)
		{
			return 0;
		}

		private static int CheckPoint(int[] x, int[] y, int[] z)
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

		private static IDigest CreateDigest()
		{
			return null;
		}

		public static IDigest CreatePrehash()
		{
			return null;
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

		private static void Dom2(IDigest d, byte phflag, byte[] ctx)
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

		private static int EncodePoint(PointAccum p, byte[] r, int rOff)
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

		private static void ImplSign(IDigest d, byte[] h, byte[] s, byte[] pk, int pkOff, byte[] ctx, byte phflag, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
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

		private static void PointAddVar(bool negate, PointExt p, PointAccum r)
		{
		}

		private static void PointAddVar(bool negate, PointExt p, PointExt q, PointExt r)
		{
		}

		private static void PointAddPrecomp(PointPrecomp p, PointAccum r)
		{
		}

		private static PointExt PointCopy(PointAccum p)
		{
			return null;
		}

		private static PointExt PointCopy(PointExt p)
		{
			return null;
		}

		private static void PointDouble(PointAccum r)
		{
		}

		private static void PointExtendXY(PointAccum p)
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

		private static void PointSetNeutral(PointAccum p)
		{
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

		private static void ScalarMultBase(byte[] k, PointAccum r)
		{
		}

		private static void ScalarMultBaseEncoded(byte[] k, byte[] r, int rOff)
		{
		}

		internal static void ScalarMultBaseYZ(byte[] k, int kOff, int[] y, int[] z)
		{
		}

		private static void ScalarMultStrausVar(uint[] nb, uint[] np, PointExt p, PointAccum r)
		{
		}

		public static void Sign(byte[] sk, int skOff, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
		{
		}

		public static void Sign(byte[] sk, int skOff, byte[] pk, int pkOff, byte[] m, int mOff, int mLen, byte[] sig, int sigOff)
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

		public static void SignPrehash(byte[] sk, int skOff, byte[] ctx, IDigest ph, byte[] sig, int sigOff)
		{
		}

		public static void SignPrehash(byte[] sk, int skOff, byte[] pk, int pkOff, byte[] ctx, IDigest ph, byte[] sig, int sigOff)
		{
		}

		public static bool Verify(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] m, int mOff, int mLen)
		{
			return false;
		}

		public static bool Verify(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] ctx, byte[] m, int mOff, int mLen)
		{
			return false;
		}

		public static bool VerifyPrehash(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] ctx, byte[] ph, int phOff)
		{
			return false;
		}

		public static bool VerifyPrehash(byte[] sig, int sigOff, byte[] pk, int pkOff, byte[] ctx, IDigest ph)
		{
			return false;
		}
	}
}
