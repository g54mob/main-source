namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public class ScaleXPointMap : ECPointMap
	{
		protected readonly ECFieldElement scale;

		public ScaleXPointMap(ECFieldElement scale)
		{
		}

		public virtual ECPoint Map(ECPoint p)
		{
			return null;
		}
	}
}
