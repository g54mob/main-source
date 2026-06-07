namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public abstract class AbstractFpCurve : ECCurve
	{
		protected AbstractFpCurve(BigInteger q)
			: base(null)
		{
		}

		public override bool IsValidFieldElement(BigInteger x)
		{
			return false;
		}

		protected override ECPoint DecompressPoint(int yTilde, BigInteger X1)
		{
			return null;
		}
	}
}
