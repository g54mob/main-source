namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Djb
{
	internal class Curve25519 : AbstractFpCurve
	{
		private class Curve25519LookupTable : AbstractECLookupTable
		{
			private readonly Curve25519 m_outer;

			private readonly uint[] m_table;

			private readonly int m_size;

			public override int Size => 0;

			internal Curve25519LookupTable(Curve25519 outer, uint[] table, int size)
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

		private static readonly BigInteger C_a;

		private static readonly BigInteger C_b;

		private const int CURVE25519_DEFAULT_COORDS = 4;

		private const int CURVE25519_FE_INTS = 8;

		private static readonly ECFieldElement[] CURVE25519_AFFINE_ZS;

		protected readonly Curve25519Point m_infinity;

		public virtual BigInteger Q => null;

		public override ECPoint Infinity => null;

		public override int FieldSize => 0;

		public Curve25519()
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
