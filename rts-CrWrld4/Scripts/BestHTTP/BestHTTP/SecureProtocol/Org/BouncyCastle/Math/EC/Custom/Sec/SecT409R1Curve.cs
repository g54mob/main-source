namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecT409R1Curve : AbstractF2mCurve
	{
		private class SecT409R1LookupTable : AbstractECLookupTable
		{
			private readonly SecT409R1Curve m_outer;

			private readonly ulong[] m_table;

			private readonly int m_size;

			public override int Size => 0;

			internal SecT409R1LookupTable(SecT409R1Curve outer, ulong[] table, int size)
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

			private ECPoint CreatePoint(ulong[] x, ulong[] y)
			{
				return null;
			}
		}

		private const int SECT409R1_DEFAULT_COORDS = 6;

		private const int SECT409R1_FE_LONGS = 7;

		private static readonly ECFieldElement[] SECT409R1_AFFINE_ZS;

		protected readonly SecT409R1Point m_infinity;

		public override ECPoint Infinity => null;

		public override int FieldSize => 0;

		public override bool IsKoblitz => false;

		public virtual int M => 0;

		public virtual bool IsTrinomial => false;

		public virtual int K1 => 0;

		public virtual int K2 => 0;

		public virtual int K3 => 0;

		public SecT409R1Curve()
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

		public override ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
		{
			return null;
		}
	}
}
