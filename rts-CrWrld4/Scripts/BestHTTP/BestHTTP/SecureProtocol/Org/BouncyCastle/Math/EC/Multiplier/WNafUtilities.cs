using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	public abstract class WNafUtilities
	{
		private class ConfigureBasepointCallback : IPreCompCallback
		{
			private readonly ECCurve m_curve;

			private readonly int m_confWidth;

			internal ConfigureBasepointCallback(ECCurve curve, int confWidth)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}
		}

		private class MapPointCallback : IPreCompCallback
		{
			private readonly WNafPreCompInfo m_infoP;

			private readonly bool m_includeNegated;

			private readonly ECPointMap m_pointMap;

			internal MapPointCallback(WNafPreCompInfo infoP, bool includeNegated, ECPointMap pointMap)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}
		}

		private class PrecomputeCallback : IPreCompCallback
		{
			private readonly ECPoint m_p;

			private readonly int m_minWidth;

			private readonly bool m_includeNegated;

			internal PrecomputeCallback(ECPoint p, int minWidth, bool includeNegated)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}

			private bool CheckExisting(WNafPreCompInfo existingWNaf, int width, int reqPreCompLen, bool includeNegated)
			{
				return false;
			}

			private bool CheckTable(ECPoint[] table, int reqLen)
			{
				return false;
			}
		}

		private class PrecomputeWithPointMapCallback : IPreCompCallback
		{
			private readonly ECPoint m_point;

			private readonly ECPointMap m_pointMap;

			private readonly WNafPreCompInfo m_fromWNaf;

			private readonly bool m_includeNegated;

			internal PrecomputeWithPointMapCallback(ECPoint point, ECPointMap pointMap, WNafPreCompInfo fromWNaf, bool includeNegated)
			{
			}

			public PreCompInfo Precompute(PreCompInfo existing)
			{
				return null;
			}

			private bool CheckExisting(WNafPreCompInfo existingWNaf, int width, int reqPreCompLen, bool includeNegated)
			{
				return false;
			}

			private bool CheckTable(ECPoint[] table, int reqLen)
			{
				return false;
			}
		}

		public static readonly string PRECOMP_NAME;

		private static readonly int[] DEFAULT_WINDOW_SIZE_CUTOFFS;

		private static readonly int MAX_WIDTH;

		private static readonly ECPoint[] EMPTY_POINTS;

		public static void ConfigureBasepoint(ECPoint p)
		{
		}

		public static int[] GenerateCompactNaf(BigInteger k)
		{
			return null;
		}

		public static int[] GenerateCompactWindowNaf(int width, BigInteger k)
		{
			return null;
		}

		public static byte[] GenerateJsf(BigInteger g, BigInteger h)
		{
			return null;
		}

		public static byte[] GenerateNaf(BigInteger k)
		{
			return null;
		}

		public static byte[] GenerateWindowNaf(int width, BigInteger k)
		{
			return null;
		}

		public static int GetNafWeight(BigInteger k)
		{
			return 0;
		}

		public static WNafPreCompInfo GetWNafPreCompInfo(ECPoint p)
		{
			return null;
		}

		public static WNafPreCompInfo GetWNafPreCompInfo(PreCompInfo preCompInfo)
		{
			return null;
		}

		public static int GetWindowSize(int bits)
		{
			return 0;
		}

		public static int GetWindowSize(int bits, int maxWidth)
		{
			return 0;
		}

		public static int GetWindowSize(int bits, int[] windowSizeCutoffs)
		{
			return 0;
		}

		public static int GetWindowSize(int bits, int[] windowSizeCutoffs, int maxWidth)
		{
			return 0;
		}

		[Obsolete]
		public static ECPoint MapPointWithPrecomp(ECPoint p, int minWidth, bool includeNegated, ECPointMap pointMap)
		{
			return null;
		}

		public static WNafPreCompInfo Precompute(ECPoint p, int minWidth, bool includeNegated)
		{
			return null;
		}

		public static WNafPreCompInfo PrecomputeWithPointMap(ECPoint p, ECPointMap pointMap, WNafPreCompInfo fromWNaf, bool includeNegated)
		{
			return null;
		}

		private static byte[] Trim(byte[] a, int length)
		{
			return null;
		}

		private static int[] Trim(int[] a, int length)
		{
			return null;
		}

		private static ECPoint[] ResizeTable(ECPoint[] a, int length)
		{
			return null;
		}
	}
}
