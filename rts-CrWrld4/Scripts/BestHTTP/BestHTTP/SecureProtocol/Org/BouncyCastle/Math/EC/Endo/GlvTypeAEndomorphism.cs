namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo
{
	public class GlvTypeAEndomorphism : GlvEndomorphism, ECEndomorphism
	{
		protected readonly GlvTypeAParameters m_parameters;

		protected readonly ECPointMap m_pointMap;

		public virtual ECPointMap PointMap => null;

		public virtual bool HasEfficientPointMap => false;

		public GlvTypeAEndomorphism(ECCurve curve, GlvTypeAParameters parameters)
		{
		}

		public virtual BigInteger[] DecomposeScalar(BigInteger k)
		{
			return null;
		}
	}
}
