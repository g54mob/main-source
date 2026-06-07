namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	public class FixedPointUtilities
	{
		private class FixedPointCallback : IPreCompCallback
		{
			private readonly ECPoint m_p;

			internal FixedPointCallback(ECPoint p)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}

			private bool CheckExisting(FixedPointPreCompInfo existingFP, int n)
			{
				return false;
			}

			private bool CheckTable(ECLookupTable table, int n)
			{
				return false;
			}
		}

		public static readonly string PRECOMP_NAME;

		public static int GetCombSize(ECCurve c)
		{
			return 0;
		}

		public static FixedPointPreCompInfo GetFixedPointPreCompInfo(PreCompInfo preCompInfo)
		{
			return null;
		}

		public static FixedPointPreCompInfo Precompute(ECPoint p)
		{
			return null;
		}
	}
}
