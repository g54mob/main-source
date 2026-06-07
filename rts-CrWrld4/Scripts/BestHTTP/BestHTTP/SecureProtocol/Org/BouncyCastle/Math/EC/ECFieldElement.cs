namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public abstract class ECFieldElement
	{
		public abstract string FieldName { get; }

		public abstract int FieldSize { get; }

		public virtual int BitLength => 0;

		public virtual bool IsOne => false;

		public virtual bool IsZero => false;

		public abstract BigInteger ToBigInteger();

		public abstract ECFieldElement Add(ECFieldElement b);

		public abstract ECFieldElement AddOne();

		public abstract ECFieldElement Subtract(ECFieldElement b);

		public abstract ECFieldElement Multiply(ECFieldElement b);

		public abstract ECFieldElement Divide(ECFieldElement b);

		public abstract ECFieldElement Negate();

		public abstract ECFieldElement Square();

		public abstract ECFieldElement Invert();

		public abstract ECFieldElement Sqrt();

		public virtual ECFieldElement MultiplyMinusProduct(ECFieldElement b, ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public virtual ECFieldElement MultiplyPlusProduct(ECFieldElement b, ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public virtual ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public virtual ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public virtual ECFieldElement SquarePow(int pow)
		{
			return null;
		}

		public virtual bool TestBitZero()
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public virtual bool Equals(ECFieldElement other)
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
	}
}
