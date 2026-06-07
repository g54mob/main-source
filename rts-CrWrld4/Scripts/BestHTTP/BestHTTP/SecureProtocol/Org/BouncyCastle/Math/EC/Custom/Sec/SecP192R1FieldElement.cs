namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecP192R1FieldElement : AbstractFpFieldElement
	{
		public static readonly BigInteger Q;

		protected internal readonly uint[] x;

		public override bool IsZero => false;

		public override bool IsOne => false;

		public override string FieldName => null;

		public override int FieldSize => 0;

		public SecP192R1FieldElement(BigInteger x)
		{
		}

		public SecP192R1FieldElement()
		{
		}

		protected internal SecP192R1FieldElement(uint[] x)
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

		public virtual bool Equals(SecP192R1FieldElement other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
