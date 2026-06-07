namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.GM
{
	internal class SM2P256V1Curve : AbstractFpCurve
	{
		private class SM2P256V1LookupTable : AbstractECLookupTable
		{
			private readonly SM2P256V1Curve m_outer;

			private readonly uint[] m_table;

			private readonly int m_size;

			public override int Size => 0;

			internal SM2P256V1LookupTable(SM2P256V1Curve outer, uint[] table, int size)
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

		private const int SM2P256V1_DEFAULT_COORDS = 2;

		private const int SM2P256V1_FE_INTS = 8;

		private static readonly ECFieldElement[] SM2P256V1_AFFINE_ZS;

		protected readonly SM2P256V1Point m_infinity;

		public virtual BigInteger Q => null;

		public override ECPoint Infinity => null;

		public override int FieldSize => 0;

		public SM2P256V1Curve()
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
