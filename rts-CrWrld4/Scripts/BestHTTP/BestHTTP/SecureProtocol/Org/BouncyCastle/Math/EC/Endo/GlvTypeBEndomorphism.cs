namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo
{
	public class GlvTypeBEndomorphism : GlvEndomorphism, ECEndomorphism
	{
		protected readonly GlvTypeBParameters m_parameters;

		protected readonly ECPointMap m_pointMap;

		public virtual ECPointMap PointMap => null;

		public virtual bool HasEfficientPointMap => false;

		public GlvTypeBEndomorphism(ECCurve curve, GlvTypeBParameters parameters)
		{
		}

		public virtual BigInteger[] DecomposeScalar(BigInteger k)
		{
			return null;
		}
	}
}
