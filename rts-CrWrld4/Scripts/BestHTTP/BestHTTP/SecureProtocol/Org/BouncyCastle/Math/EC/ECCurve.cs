using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Field;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public abstract class ECCurve
	{
		public class Config
		{
			protected ECCurve outer;

			protected int coord;

			protected ECEndomorphism endomorphism;

			protected ECMultiplier multiplier;

			internal Config(ECCurve outer, int coord, ECEndomorphism endomorphism, ECMultiplier multiplier)
			{
			}

			public Config SetCoordinateSystem(int coord)
			{
				return null;
			}

			public Config SetEndomorphism(ECEndomorphism endomorphism)
			{
				return null;
			}

			public Config SetMultiplier(ECMultiplier multiplier)
			{
				return null;
			}

			public ECCurve Create()
			{
				return null;
			}
		}

		private class DefaultLookupTable : AbstractECLookupTable
		{
			private readonly ECCurve m_outer;

			private readonly byte[] m_table;

			private readonly int m_size;

			public override int Size => 0;

			internal DefaultLookupTable(ECCurve outer, byte[] table, int size)
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

			private ECPoint CreatePoint(byte[] x, byte[] y)
			{
				return null;
			}
		}

		public const int COORD_AFFINE = 0;

		public const int COORD_HOMOGENEOUS = 1;

		public const int COORD_JACOBIAN = 2;

		public const int COORD_JACOBIAN_CHUDNOVSKY = 3;

		public const int COORD_JACOBIAN_MODIFIED = 4;

		public const int COORD_LAMBDA_AFFINE = 5;

		public const int COORD_LAMBDA_PROJECTIVE = 6;

		public const int COORD_SKEWED = 7;

		protected readonly IFiniteField m_field;

		protected ECFieldElement m_a;

		protected ECFieldElement m_b;

		protected BigInteger m_order;

		protected BigInteger m_cofactor;

		protected int m_coord;

		protected ECEndomorphism m_endomorphism;

		protected ECMultiplier m_multiplier;

		public abstract int FieldSize { get; }

		public abstract ECPoint Infinity { get; }

		public virtual IFiniteField Field => null;

		public virtual ECFieldElement A => null;

		public virtual ECFieldElement B => null;

		public virtual BigInteger Order => null;

		public virtual BigInteger Cofactor => null;

		public virtual int CoordinateSystem => 0;

		public static int[] GetAllCoordinateSystems()
		{
			return null;
		}

		protected ECCurve(IFiniteField field)
		{
		}

		public abstract ECFieldElement FromBigInteger(BigInteger x);

		public abstract bool IsValidFieldElement(BigInteger x);

		public virtual Config Configure()
		{
			return null;
		}

		public virtual ECPoint ValidatePoint(BigInteger x, BigInteger y)
		{
			return null;
		}

		public virtual ECPoint ValidatePoint(BigInteger x, BigInteger y, bool withCompression)
		{
			return null;
		}

		public virtual ECPoint CreatePoint(BigInteger x, BigInteger y)
		{
			return null;
		}

		public virtual ECPoint CreatePoint(BigInteger x, BigInteger y, bool withCompression)
		{
			return null;
		}

		protected abstract ECCurve CloneCurve();

		protected internal abstract ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y, bool withCompression);

		protected internal abstract ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression);

		protected virtual ECMultiplier CreateDefaultMultiplier()
		{
			return null;
		}

		public virtual bool SupportsCoordinateSystem(int coord)
		{
			return false;
		}

		public virtual PreCompInfo GetPreCompInfo(ECPoint point, string name)
		{
			return null;
		}

		public virtual PreCompInfo Precompute(ECPoint point, string name, IPreCompCallback callback)
		{
			return null;
		}

		public virtual ECPoint ImportPoint(ECPoint p)
		{
			return null;
		}

		public virtual void NormalizeAll(ECPoint[] points)
		{
		}

		public virtual void NormalizeAll(ECPoint[] points, int off, int len, ECFieldElement iso)
		{
		}

		public virtual ECLookupTable CreateCacheSafeLookupTable(ECPoint[] points, int off, int len)
		{
			return null;
		}

		protected virtual void CheckPoint(ECPoint point)
		{
		}

		protected virtual void CheckPoints(ECPoint[] points)
		{
		}

		protected virtual void CheckPoints(ECPoint[] points, int off, int len)
		{
		}

		public virtual bool Equals(ECCurve other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		protected abstract ECPoint DecompressPoint(int yTilde, BigInteger X1);

		public virtual ECEndomorphism GetEndomorphism()
		{
			return null;
		}

		public virtual ECMultiplier GetMultiplier()
		{
			return null;
		}

		public virtual ECPoint DecodePoint(byte[] encoded)
		{
			return null;
		}
	}
}
