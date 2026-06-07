using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	public class KDTree
	{
		public KDTree[] lr;

		public Vector3 pivot;

		public int pivotIndex;

		public int axis;

		private const int numDims = 3;

		public static KDTree MakeFromPoints(params Vector3[] points)
		{
			return null;
		}

		private static KDTree MakeFromPointsInner(int depth, int stIndex, int enIndex, Vector3[] points, int[] inds)
		{
			return null;
		}

		private static void SwapElements(int[] arr, int a, int b)
		{
		}

		private static int FindSplitPoint(Vector3[] points, int[] inds, int stIndex, int enIndex, int axis)
		{
			return 0;
		}

		public static int FindPivotIndex(Vector3[] points, int[] inds, int stIndex, int enIndex, int axis)
		{
			return 0;
		}

		public static int[] Iota(int num)
		{
			return null;
		}

		public int FindNearest(Vector3 pt)
		{
			return 0;
		}

		private void Search(Vector3 pt, ref float bestSqSoFar, ref int bestIndex)
		{
		}

		private float DistFromSplitPlane(Vector3 pt, Vector3 planePt, int axis)
		{
			return 0f;
		}

		public string Dump(int level)
		{
			return null;
		}
	}
}
