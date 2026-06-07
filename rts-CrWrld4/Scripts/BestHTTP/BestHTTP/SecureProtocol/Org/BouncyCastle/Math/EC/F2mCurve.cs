using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public class F2mCurve : AbstractF2mCurve
	{
		private class DefaultF2mLookupTable : AbstractECLookupTable
		{
			private readonly F2mCurve m_outer;

			private readonly long[] m_table;

			private readonly int m_size;

			public override int Size => 0;

			internal DefaultF2mLookupTable(F2mCurve outer, long[] table, int size)
			{
			}

			public override ECPoint Lookup(int index)
			{
				return null;
			}

			public override ECPoint LookupVar(int index)
			{
				return null;
			}

			private ECPoint CreatePoint(long[] x, long[] y)
			{
				return null;
			}
		}

		private const int F2M_DEFAULT_COORDS = 6;

		private readonly int m;

		private readonly int k1;

		private readonly int k2;

		private readonly int k3;

		protected readonly F2mPoint m_infinity;

		public override int FieldSize => 0;

		public override ECPoint Infinity => null;

		public int M => 0;

		public int K1 => 0;

		public int K2 => 0;

		public int K3 => 0;

		public F2mCurve(int m, int k, BigInteger a, BigInteger b)
			: base(0, 0, 0, 0)
		{
		}

		public F2mCurve(int m, int k, BigInteger a, BigInteger b, BigInteger order, BigInteger cofactor)
			: base(0, 0, 0, 0)
		{
		}

		public F2mCurve(int m, int k1, int k2, int k3, BigInteger a, BigInteger b)
			: base(0, 0, 0, 0)
		{
		}

		public F2mCurve(int m, int k1, int k2, int k3, BigInteger a, BigInteger b, BigInteger order, BigInteger cofactor)
			: base(0, 0, 0, 0)
		{
		}

		protected F2mCurve(int m, int k1, int k2, int k3, ECFieldElement a, ECFieldElement b, BigInteger order, BigInteger cofactor)
			: base(0, 0, 0, 0)
		{
		}

		protected override ECCurve CloneCurve()
		{
			return null;
		}

		public override bool SupportsCoordinateSystem(int coord)
		{
			return false;
		}

		protected override ECMultiplier CreateDefaultMultiplier()
		{
			return null;
		}

		public override ECFieldElement FromBigInteger(BigInteger x)
		{
			return null;
		}

		protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y, bool withCompression)
		{
			return null;
		}

		protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression)
		{
			return null;
		}

		public bool IsTrinomial()
		{
			return false;
		}

		public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
		{
			return null;
		}
	}
}
