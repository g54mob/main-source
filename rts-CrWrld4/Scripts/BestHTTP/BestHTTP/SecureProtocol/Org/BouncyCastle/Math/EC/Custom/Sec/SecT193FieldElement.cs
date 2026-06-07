namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecT193FieldElement : AbstractF2mFieldElement
	{
		protected internal readonly ulong[] x;

		public override bool IsOne => false;

		public override bool IsZero => false;

		public override string FieldName => null;

		public override int FieldSize => 0;

		public override bool HasFastTrace => false;

		public virtual int Representation => 0;

		public virtual int M => 0;

		public virtual int K1 => 0;

		public virtual int K2 => 0;

		public virtual int K3 => 0;

		public SecT193FieldElement(BigInteger x)
		{
		}

		public SecT193FieldElement()
		{
		}

		protected internal SecT193FieldElement(ulong[] x)
		{
		}

		public override bool TestBitZero()
		{
			return false;
		}

		public override BigInteger ToBigInteger()
		{
			return null;
		}

		public override ECFieldElement Add(ECFieldElement b)
		{
			return null;
		}

		public override ECFieldElement AddOne()
		{
			return null;
		}

		public override ECFieldElement Subtract(ECFieldElement b)
		{
			return null;
		}

		public override ECFieldElement Multiply(ECFieldElement b)
		{
			return null;
		}

		public override ECFieldElement MultiplyMinusProduct(ECFieldElement b, ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public override ECFieldElement MultiplyPlusProduct(ECFieldElement b, ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public override ECFieldElement Divide(ECFieldElement b)
		{
			return null;
		}

		public override ECFieldElement Negate()
		{
			return null;
		}

		public override ECFieldElement Square()
		{
			return null;
		}

		public override ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public override ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
		{
			return null;
		}

		public override ECFieldElement SquarePow(int pow)
		{
			return null;
		}

		public override ECFieldElement HalfTrace()
		{
			return null;
		}

		public override int Trace()
		{
			return 0;
		}

		public override ECFieldElement Invert()
		{
			return null;
		}

		public override ECFieldElement Sqrt()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override bool Equals(ECFieldElement other)
		{
			return false;
		}

		public virtual bool Equals(SecT193FieldElement other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
