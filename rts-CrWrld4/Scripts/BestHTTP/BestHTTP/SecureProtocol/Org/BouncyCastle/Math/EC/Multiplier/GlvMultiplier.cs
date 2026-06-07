using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	public class GlvMultiplier : AbstractECMultiplier
	{
		protected readonly ECCurve curve;

		protected readonly GlvEndomorphism glvEndomorphism;

		public GlvMultiplier(ECCurve curve, GlvEndomorphism glvEndomorphism)
		{
		}

		protected override ECPoint MultiplyPositive(ECPoint p, BigInteger k)
		{
			return null;
		}
	}
}
