namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Abc
{
	internal class Tnaf
	{
		private static readonly BigInteger MinusOne;

		private static readonly BigInteger MinusTwo;

		private static readonly BigInteger MinusThree;

		private static readonly BigInteger Four;

		public const sbyte Width = 4;

		public const sbyte Pow2Width = 16;

		public static readonly ZTauElement[] Alpha0;

		public static readonly sbyte[][] Alpha0Tnaf;

		public static readonly ZTauElement[] Alpha1;

		public static readonly sbyte[][] Alpha1Tnaf;

		public static BigInteger Norm(sbyte mu, ZTauElement lambda)
		{
			return null;
		}

		public static SimpleBigDecimal Norm(sbyte mu, SimpleBigDecimal u, SimpleBigDecimal v)
		{
			return null;
		}

		public static ZTauElement Round(SimpleBigDecimal lambda0, SimpleBigDecimal lambda1, sbyte mu)
		{
			return null;
		}

		public static SimpleBigDecimal ApproximateDivisionByN(BigInteger k, BigInteger s, BigInteger vm, sbyte a, int m, int c)
		{
			return null;
		}

		public static sbyte[] TauAdicNaf(sbyte mu, ZTauElement lambda)
		{
			return null;
		}

		public static AbstractF2mPoint Tau(AbstractF2mPoint p)
		{
			return null;
		}

		public static sbyte GetMu(AbstractF2mCurve curve)
		{
			return 0;
		}

		public static sbyte GetMu(ECFieldElement curveA)
		{
			return 0;
		}

		public static sbyte GetMu(int curveA)
		{
			return 0;
		}

		public static BigInteger[] GetLucas(sbyte mu, int k, bool doV)
		{
			return null;
		}

		public static BigInteger GetTw(sbyte mu, int w)
		{
			return null;
		}

		public static BigInteger[] GetSi(AbstractF2mCurve curve)
		{
			return null;
		}

		public static BigInteger[] GetSi(int fieldSize, int curveA, BigInteger cofactor)
		{
			return null;
		}

		protected static int GetShiftsForCofactor(BigInteger h)
		{
			return 0;
		}

		public static ZTauElement PartModReduction(BigInteger k, int m, sbyte a, BigInteger[] s, sbyte mu, sbyte c)
		{
			return null;
		}

		public static AbstractF2mPoint MultiplyRTnaf(AbstractF2mPoint p, BigInteger k)
		{
			return null;
		}

		public static AbstractF2mPoint MultiplyTnaf(AbstractF2mPoint p, ZTauElement lambda)
		{
			return null;
		}

		public static AbstractF2mPoint MultiplyFromTnaf(AbstractF2mPoint p, sbyte[] u)
		{
			return null;
		}

		public static sbyte[] TauAdicWNaf(sbyte mu, ZTauElement lambda, sbyte width, BigInteger pow2w, BigInteger tw, ZTauElement[] alpha)
		{
			return null;
		}

		public static AbstractF2mPoint[] GetPreComp(AbstractF2mPoint p, sbyte a)
		{
			return null;
		}
	}
}
