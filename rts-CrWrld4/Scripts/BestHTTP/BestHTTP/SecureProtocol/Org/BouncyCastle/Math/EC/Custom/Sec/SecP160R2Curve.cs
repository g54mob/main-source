namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecP160R2Curve : AbstractFpCurve
	{
		private class SecP160R2LookupTable : AbstractECLookupTable
		{
			private readonly SecP160R2Curve m_outer;

			private readonly uint[] m_table;

			private readonly int m_size;

			public override int Size => 0;

			internal SecP160R2LookupTable(SecP160R2Curve outer, uint[] table, int size)
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

			private ECPoint CreatePoint(uint[] x, uint[] y)
			{
				return null;
			}
		}

		public static readonly BigInteger q;

		private const int SECP160R2_DEFAULT_COORDS = 2;

		private const int SECP160R2_FE_INTS = 5;

		private static readonly ECFieldElement[] SECP160R2_AFFINE_ZS;

		protected readonly SecP160R2Point m_infinity;

		public virtual BigInteger Q => null;

		public override ECPoint Infinity => null;

		public override int FieldSize => 0;

		public SecP160R2Curve()
			: base(null)
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
