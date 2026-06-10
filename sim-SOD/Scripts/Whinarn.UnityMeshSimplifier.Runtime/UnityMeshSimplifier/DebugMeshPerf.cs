using UnityEngine;

namespace UnityMeshSimplifier
{
	internal class DebugMeshPerf
	{
		public int nrErrorEval;

		public int nrEdgeReinsert;

		public int nrLoopTest;

		public int nrLoopComplete;

		public int nrErrorTypeEllipsoid;

		public int nrErrorTypeVertex;

		public int nrBorder2D;

		public int nrUVSeamEdge;

		public int nrUVFoldoverEdge;

		public int nrEdgeLag;

		public int nrEdgeRejected;

		public int nrTrisBefore;

		public int nrTrisAfter;

		public double lastErrorValue;

		public int[] Triplets;

		private static DebugMeshPerf singleton;

		public static DebugMeshPerf Data => null;

		private DebugMeshPerf()
		{
		}

		public void Reset()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static Color[] UpdateVertexColor(Vertex[] vertices, Edge[] v2e)
		{
			return null;
		}
	}
}
