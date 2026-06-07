using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo
{
	public abstract class EndoUtilities
	{
		private class MapPointCallback : IPreCompCallback
		{
			private readonly ECEndomorphism m_endomorphism;

			private readonly ECPoint m_point;

			internal MapPointCallback(ECEndomorphism endomorphism, ECPoint point)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}

			private bool CheckExisting(EndoPreCompInfo existingEndo, ECEndomorphism endomorphism)
			{
				return false;
			}
		}

		public static readonly string PRECOMP_NAME;

		public static BigInteger[] DecomposeScalar(ScalarSplitParameters p, BigInteger k)
		{
			return null;
		}

		public static ECPoint MapPoint(ECEndomorphism endomorphism, ECPoint p)
		{
			return null;
		}

		private static BigInteger CalculateB(BigInteger k, BigInteger g, int t)
		{
			return null;
		}
	}
}
