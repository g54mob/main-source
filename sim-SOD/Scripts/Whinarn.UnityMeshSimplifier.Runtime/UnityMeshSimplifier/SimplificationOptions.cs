using System;
using UnityEngine;

namespace UnityMeshSimplifier
{
	[Serializable]
	public struct SimplificationOptions
	{
		public static readonly SimplificationOptions Default;

		[Tooltip("If the border edges should be preserved.")]
		public bool PreserveBorderEdges;

		[Tooltip("If the UV seam edges should be preserved.")]
		public bool PreserveUVSeamEdges;

		[Tooltip("If the UV foldover edges should be preserved.")]
		public bool PreserveUVFoldoverEdges;

		[Tooltip("If a feature for smarter vertex linking should be enabled, reducing artifacts at the cost of slower simplification.")]
		public bool EnableSmartLink;

		[Tooltip("The maximum distance between two vertices in order to link them.")]
		public double VertexLinkDistance;

		[Tooltip("The maximum squared distance between two vertices in order to link them.")]
		public int MaxIterationCount;

		[Tooltip("The agressiveness of the mesh simplification. Higher number equals higher quality, but more expensive to run.")]
		public double Agressiveness;
	}
}
