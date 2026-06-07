namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public class ScaleYPointMap : ECPointMap
	{
		protected readonly ECFieldElement scale;

		public ScaleYPointMap(ECFieldElement scale)
		{
		}

		public virtual ECPoint Map(ECPoint p)
		{
			return null;
		}
	}
}
