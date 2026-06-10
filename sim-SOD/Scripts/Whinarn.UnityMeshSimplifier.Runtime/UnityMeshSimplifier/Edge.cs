using System.Runtime.CompilerServices;

namespace UnityMeshSimplifier
{
	public class Edge
	{
		public enum QState
		{
			QIsNotCalculated = 0,
			QIsCalculated = 1,
			QPenaltyIsCalculated = 2,
			ErrorIsCalculated = 3
		}

		public Triangle containingTriangle;

		public int vertexA;

		public int vertexB;

		public int vSmall;

		public int vLarge;

		public ulong key;

		public int hashCode;

		public double error;

		public double errorKeyed;

		public Vector3d p;

		public SymmetricMatrix q;

		public SymmetricMatrix qTwice;

		public SymmetricMatrix qPenaltyBorderVertexA;

		public SymmetricMatrix qPenaltyBorderVertexB;

		public bool isDeleted;

		public bool isBorder2D;

		public bool isUVSeam;

		public bool isUVFoldover;

		public int index;

		public QState flagCalculateQstate;

		public readonly int ova;

		public readonly int ovb;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Edge(int vertexA, int vertexB)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InitIndex(int vertexA, int vertexB)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReplaceVertex(int oldVertex, int newVertex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong CalculateKey(int vertexA, int vertexB)
		{
			return 0uL;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
