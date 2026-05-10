using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class Funnel
	{
		public struct FunnelPortals
		{
			public List<Vector3> left;

			public List<Vector3> right;
		}

		public struct PathPart
		{
			public int startIndex;

			public int endIndex;

			public Vector3 startPoint;

			public Vector3 endPoint;

			public bool isLink;
		}

		public static List<PathPart> SplitIntoParts(Path path)
		{
			return null;
		}

		public static FunnelPortals ConstructFunnelPortals(List<GraphNode> nodes, PathPart part)
		{
			return default(FunnelPortals);
		}

		public static void ShrinkPortals(FunnelPortals portals, float shrink)
		{
		}

		private static bool UnwrapHelper(Vector3 portalStart, Vector3 portalEnd, Vector3 prevPoint, Vector3 nextPoint, ref Quaternion mRot, ref Vector3 mOffset)
		{
			return false;
		}

		public static void Unwrap(FunnelPortals funnel, Vector2[] left, Vector2[] right)
		{
		}

		private static int FixFunnel(Vector2[] left, Vector2[] right, int numPortals)
		{
			return 0;
		}

		protected static Vector2 ToXZ(Vector3 p)
		{
			return default(Vector2);
		}

		protected static Vector3 FromXZ(Vector2 p)
		{
			return default(Vector3);
		}

		protected static bool RightOrColinear(Vector2 a, Vector2 b)
		{
			return false;
		}

		protected static bool LeftOrColinear(Vector2 a, Vector2 b)
		{
			return false;
		}

		public static List<Vector3> Calculate(FunnelPortals funnel, bool unwrap, bool splitAtEveryPortal)
		{
			return null;
		}

		private static void Calculate(Vector2[] left, Vector2[] right, int numPortals, int startIndex, List<int> funnelPath, int maxCorners, out bool lastCorner)
		{
			lastCorner = default(bool);
		}
	}
}
