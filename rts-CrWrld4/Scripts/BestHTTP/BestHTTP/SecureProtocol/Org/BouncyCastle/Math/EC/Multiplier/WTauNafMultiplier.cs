using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Abc;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	public class WTauNafMultiplier : AbstractECMultiplier
	{
		private class WTauNafCallback : IPreCompCallback
		{
			private readonly AbstractF2mPoint m_p;

			private readonly sbyte m_a;

			internal WTauNafCallback(AbstractF2mPoint p, sbyte a)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}
		}

		internal static readonly string PRECOMP_NAME;

		protected override ECPoint MultiplyPositive(ECPoint point, BigInteger k)
		{
			return null;
		}

		private AbstractF2mPoint MultiplyWTnaf(AbstractF2mPoint p, ZTauElement lambda, sbyte a, sbyte mu)
		{
			return null;
		}

		private static AbstractF2mPoint MultiplyFromWTnaf(AbstractF2mPoint p, sbyte[] u)
		{
			return null;
		}
	}
}
