namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecP128R1Curve : AbstractFpCurve
	{
		private class SecP128R1LookupTable : AbstractECLookupTable
		{
			private readonly SecP128R1Curve m_outer;

			private readonly uint[] m_table;

			private readonly int m_size;

			public override int Size => 0;

			internal SecP128R1LookupTable(SecP128R1Curve outer, uint[] table, int size)
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

		private const int SECP128R1_DEFAULT_COORDS = 2;

		private const int SECP128R1_FE_INTS = 4;

		private static readonly ECFieldElement[] SECP128R1_AFFINE_ZS;

		protected readonly SecP128R1Point m_infinity;

		public virtual BigInteger Q => null;

		public override ECPoint Infinity => null;

		public override int FieldSize => 0;

		public SecP128R1Curve()
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
