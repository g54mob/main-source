using System.Diagnostics;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	public class BBTree : IAstarPooledObject
	{
		private struct BBTreeBox
		{
			public IntRect rect;

			public int nodeOffset;

			public int left;

			public int right;

			public bool IsLeaf => false;

			public BBTreeBox(IntRect rect)
			{
				this.rect = default(IntRect);
				nodeOffset = 0;
				left = 0;
				right = 0;
			}

			public BBTreeBox(int nodeOffset, IntRect rect)
			{
				this.rect = default(IntRect);
				this.nodeOffset = 0;
				left = 0;
				right = 0;
			}

			public bool Contains(Vector3 point)
			{
				return false;
			}
		}

		private BBTreeBox[] tree;

		private TriangleMeshNode[] nodeLookup;

		private int count;

		private int leafNodes;

		private const int MaximumLeafSize = 4;

		public Rect Size => default(Rect);

		public void Clear()
		{
		}

		void IAstarPooledObject.OnEnterPool()
		{
		}

		private void EnsureCapacity(int c)
		{
		}

		private void EnsureNodeCapacity(int c)
		{
		}

		private int GetBox(IntRect rect)
		{
			return 0;
		}

		public void RebuildFrom(TriangleMeshNode[] nodes)
		{
		}

		private static int SplitByX(TriangleMeshNode[] nodes, int[] permutation, int from, int to, int divider)
		{
			return 0;
		}

		private static int SplitByZ(TriangleMeshNode[] nodes, int[] permutation, int from, int to, int divider)
		{
			return 0;
		}

		private int RebuildFromInternal(TriangleMeshNode[] nodes, int[] permutation, IntRect[] nodeBounds, int from, int to, bool odd)
		{
			return 0;
		}

		private static IntRect NodeBounds(int[] permutation, IntRect[] nodeBounds, int from, int to)
		{
			return default(IntRect);
		}

		[Conditional("ASTARDEBUG")]
		private static void DrawDebugRect(IntRect rect)
		{
		}

		[Conditional("ASTARDEBUG")]
		private static void DrawDebugNode(TriangleMeshNode node, float yoffset, Color color)
		{
		}

		public NNInfoInternal QueryClosest(Vector3 p, NNConstraint constraint, out float distance)
		{
			distance = default(float);
			return default(NNInfoInternal);
		}

		public NNInfoInternal QueryClosestXZ(Vector3 p, NNConstraint constraint, ref float distance, NNInfoInternal previous)
		{
			return default(NNInfoInternal);
		}

		private void SearchBoxClosestXZ(int boxi, Vector3 p, ref float closestSqrDist, NNConstraint constraint, ref NNInfoInternal nnInfo)
		{
		}

		public NNInfoInternal QueryClosest(Vector3 p, NNConstraint constraint, ref float distance, NNInfoInternal previous)
		{
			return default(NNInfoInternal);
		}

		private void SearchBoxClosest(int boxi, Vector3 p, ref float closestSqrDist, NNConstraint constraint, ref NNInfoInternal nnInfo)
		{
		}

		private void GetOrderedChildren(ref int first, ref int second, out float firstDist, out float secondDist, Vector3 p)
		{
			firstDist = default(float);
			secondDist = default(float);
		}

		public TriangleMeshNode QueryInside(Vector3 p, NNConstraint constraint)
		{
			return null;
		}

		private TriangleMeshNode SearchBoxInside(int boxi, Vector3 p, NNConstraint constraint)
		{
			return null;
		}

		public void OnDrawGizmos()
		{
		}

		private void OnDrawGizmos(int boxi, int depth)
		{
		}

		private static bool NodeIntersectsCircle(TriangleMeshNode node, Vector3 p, float radius)
		{
			return false;
		}

		private static bool RectIntersectsCircle(IntRect r, Vector3 p, float radius)
		{
			return false;
		}

		private static float SquaredRectPointDistance(IntRect r, Vector3 p)
		{
			return 0f;
		}
	}
}
