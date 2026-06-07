namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public class FpFieldElement : AbstractFpFieldElement
	{
		private readonly BigInteger q;

		private readonly BigInteger r;

		private readonly BigInteger x;

		public override string FieldName => null;

		public override int FieldSize => 0;

		public BigInteger Q => null;

		internal static BigInteger CalculateResidue(BigInteger p)
		{
			return null;
		}

		public FpFieldElement(BigInteger q, BigInteger x)
		{
		}

		internal FpFieldElement(BigInteger q, BigInteger r, BigInteger x)
		{
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

		public override ECFieldElement Invert()
		{
			return null;
		}

		public override ECFieldElement Sqrt()
		{
			return null;
		}

		private ECFieldElement CheckSqrt(ECFieldElement z)
		{
			return null;
		}

		private BigInteger[] LucasSequence(BigInteger P, BigInteger Q, BigInteger k)
		{
			return null;
		}

		protected virtual BigInteger ModAdd(BigInteger x1, BigInteger x2)
		{
			return null;
		}

		protected virtual BigInteger ModDouble(BigInteger x)
		{
			return null;
		}

		protected virtual BigInteger ModHalf(BigInteger x)
		{
			return null;
		}

		protected virtual BigInteger ModHalfAbs(BigInteger x)
		{
			return null;
		}

		protected virtual BigInteger ModInverse(BigInteger x)
		{
			return null;
		}

		protected virtual BigInteger ModMult(BigInteger x1, BigInteger x2)
		{
			return null;
		}

		protected virtual BigInteger ModReduce(BigInteger x)
		{
			return null;
		}

		protected virtual BigInteger ModSubtract(BigInteger x1, BigInteger x2)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public virtual bool Equals(FpFieldElement other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
