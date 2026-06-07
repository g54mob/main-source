namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public abstract class AbstractFpPoint : ECPointBase
	{
		protected internal override bool CompressionYTilde => false;

		protected AbstractFpPoint(ECCurve curve, ECFieldElement x, ECFieldElement y, bool withCompression)
			: base(null, null, null, withCompression: false)
		{
		}

		protected AbstractFpPoint(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression)
			: base(null, null, null, withCompression: false)
		{
		}

		protected override bool SatisfiesCurveEquation()
		{
			return false;
		}

		public override ECPoint Subtract(ECPoint b)
		{
			return null;
		}
	}
}
