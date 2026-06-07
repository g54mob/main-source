using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public abstract class ECPoint
	{
		private class ValidityCallback : IPreCompCallback
		{
			private readonly ECPoint m_outer;

			private readonly bool m_decompressed;

			private readonly bool m_checkOrder;

			internal ValidityCallback(ECPoint outer, bool decompressed, bool checkOrder)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}
		}

		protected static ECFieldElement[] EMPTY_ZS;

		protected internal readonly ECCurve m_curve;

		protected internal readonly ECFieldElement m_x;

		protected internal readonly ECFieldElement m_y;

		protected internal readonly ECFieldElement[] m_zs;

		protected internal readonly bool m_withCompression;

		protected internal IDictionary m_preCompTable;

		public virtual ECCurve Curve => null;

		protected virtual int CurveCoordinateSystem => 0;

		public virtual ECFieldElement AffineXCoord => null;

		public virtual ECFieldElement AffineYCoord => null;

		public virtual ECFieldElement XCoord => null;

		public virtual ECFieldElement YCoord => null;

		protected internal ECFieldElement RawXCoord => null;

		protected internal ECFieldElement RawYCoord => null;

		protected internal ECFieldElement[] RawZCoords => null;

		public bool IsInfinity => false;

		public bool IsCompressed => false;

		protected internal abstract bool CompressionYTilde { get; }

		protected static ECFieldElement[] GetInitialZCoords(ECCurve curve)
		{
			return null;
		}

		protected ECPoint(ECCurve curve, ECFieldElement x, ECFieldElement y, bool withCompression)
		{
		}

		internal ECPoint(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression)
		{
		}

		protected abstract bool SatisfiesCurveEquation();

		protected virtual bool SatisfiesOrder()
		{
			return false;
		}

		public ECPoint GetDetachedPoint()
		{
			return null;
		}

		protected abstract ECPoint Detach();

		public virtual ECFieldElement GetZCoord(int index)
		{
			return null;
		}

		public virtual ECFieldElement[] GetZCoords()
		{
			return null;
		}

		protected virtual void CheckNormalized()
		{
		}

		public virtual bool IsNormalized()
		{
			return false;
		}

		public virtual ECPoint Normalize()
		{
			return null;
		}

		internal virtual ECPoint Normalize(ECFieldElement zInv)
		{
			return null;
		}

		protected virtual ECPoint CreateScaledPoint(ECFieldElement sx, ECFieldElement sy)
		{
			return null;
		}

		public bool IsValid()
		{
			return false;
		}

		internal bool IsValidPartial()
		{
			return false;
		}

		internal bool ImplIsValid(bool decompressed, bool checkOrder)
		{
			return false;
		}

		public virtual ECPoint ScaleX(ECFieldElement scale)
		{
			return null;
		}

		public virtual ECPoint ScaleXNegateY(ECFieldElement scale)
		{
			return null;
		}

		public virtual ECPoint ScaleY(ECFieldElement scale)
		{
			return null;
		}

		public virtual ECPoint ScaleYNegateX(ECFieldElement scale)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public virtual bool Equals(ECPoint other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public virtual byte[] GetEncoded()
		{
			return null;
		}

		public abstract byte[] GetEncoded(bool compressed);

		public abstract ECPoint Add(ECPoint b);

		public abstract ECPoint Subtract(ECPoint b);

		public abstract ECPoint Negate();

		public virtual ECPoint TimesPow2(int e)
		{
			return null;
		}

		public abstract ECPoint Twice();

		public abstract ECPoint Multiply(BigInteger b);

		public virtual ECPoint TwicePlus(ECPoint b)
		{
			return null;
		}

		public virtual ECPoint ThreeTimes()
		{
			return null;
		}
	}
}
