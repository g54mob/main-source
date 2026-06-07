namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public class ScaleXNegateYPointMap : ECPointMap
	{
		protected readonly ECFieldElement scale;

		public ScaleXNegateYPointMap(ECFieldElement scale)
		{
		}

		public virtual ECPoint Map(ECPoint p)
		{
			return null;
		}
	}
}
