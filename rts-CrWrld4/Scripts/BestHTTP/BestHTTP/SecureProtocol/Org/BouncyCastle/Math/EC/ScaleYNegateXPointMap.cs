namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public class ScaleYNegateXPointMap : ECPointMap
	{
		protected readonly ECFieldElement scale;

		public ScaleYNegateXPointMap(ECFieldElement scale)
		{
		}

		public virtual ECPoint Map(ECPoint p)
		{
			return null;
		}
	}
}
