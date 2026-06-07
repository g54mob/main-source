namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecP224R1FieldElement : AbstractFpFieldElement
	{
		public static readonly BigInteger Q;

		protected internal readonly uint[] x;

		public override bool IsZero => false;

		public override bool IsOne => false;

		public override string FieldName => null;

		public override int FieldSize => 0;

		public SecP224R1FieldElement(BigInteger x)
		{
		}

		public SecP224R1FieldElement()
		{
		}

		protected internal SecP224R1FieldElement(uint[] x)
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

		public virtual bool Equals(SecP224R1FieldElement other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private static bool IsSquare(uint[] x)
		{
			return false;
		}

		private static void RM(uint[] nc, uint[] d0, uint[] e0, uint[] d1, uint[] e1, uint[] f1, uint[] t)
		{
		}

		private static void RP(uint[] nc, uint[] d1, uint[] e1, uint[] f1, uint[] t)
		{
		}

		private static void RS(uint[] d, uint[] e, uint[] f, uint[] t)
		{
		}

		private static bool TrySqrt(uint[] nc, uint[] r, uint[] t)
		{
			return false;
		}
	}
}
