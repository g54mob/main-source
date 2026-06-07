using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Field;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public abstract class AbstractF2mCurve : ECCurve
	{
		private BigInteger[] si;

		public virtual bool IsKoblitz => false;

		public static BigInteger Inverse(int m, int[] ks, BigInteger x)
		{
			return null;
		}

		private static IFiniteField BuildField(int m, int k1, int k2, int k3)
		{
			return null;
		}

		protected AbstractF2mCurve(int m, int k1, int k2, int k3)
			: base(null)
		{
		}

		public override bool IsValidFieldElement(BigInteger x)
		{
			return false;
		}

		public override ECPoint CreatePoint(BigInteger x, BigInteger y, bool withCompression)
		{
			return null;
		}

		protected override ECPoint DecompressPoint(int yTilde, BigInteger X1)
		{
			return null;
		}

		internal ECFieldElement SolveQuadraticEquation(ECFieldElement beta)
		{
			return null;
		}

		internal virtual BigInteger[] GetSi()
		{
			return null;
		}
	}
}
