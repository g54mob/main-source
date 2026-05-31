using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[AddComponentMenu("Pathfinding/Modifiers/Raycast Modifier")]
	[RequireComponent(typeof(Seeker))]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_raycast_modifier.php")]
	public class RaycastModifier : MonoModifier
	{
		public enum Quality
		{
			Low = 0,
			Medium = 1,
			High = 2,
			Highest = 3
		}

		private class Filter
		{
			public Path path;

			public readonly Func<GraphNode, bool> cachedDelegate;

			private bool CanTraverse(GraphNode node)
			{
				return false;
			}
		}

		public bool useRaycasting;

		public LayerMask mask;

		[Tooltip("Checks around the line between two points, not just the exact line.\nMake sure the ground is either too far below or is not inside the mask since otherwise the raycast might always hit the ground.")]
		public bool thickRaycast;

		[Tooltip("Distance from the ray which will be checked for colliders")]
		public float thickRaycastRadius;

		[Tooltip("Check for intersections with 2D colliders instead of 3D colliders.")]
		public bool use2DPhysics;

		[Tooltip("Offset from the original positions to perform the raycast.\nCan be useful to avoid the raycast intersecting the ground or similar things you do not want to it intersect")]
		public Vector3 raycastOffset;

		[Tooltip("Use raycasting on the graphs. Only currently works with GridGraph and NavmeshGraph and RecastGraph. This is a pro version feature.")]
		public bool useGraphRaycasting;

		[Tooltip("When using the high quality mode the script will try harder to find a shorter path. This is significantly slower than the greedy low quality approach.")]
		public Quality quality;

		private static readonly int[] iterationsByQuality;

		private static List<Vector3> buffer;

		private static float[] DPCosts;

		private static int[] DPParents;

		private Filter cachedFilter;

		private NNConstraint cachedNNConstraint;

		public override int Order => 0;

		public override void Apply(Path p)
		{
		}

		private List<Vector3> ApplyGreedy(Path p, List<Vector3> points, Func<GraphNode, bool> filter, NNConstraint nnConstraint)
		{
			return null;
		}

		private List<Vector3> ApplyDP(Path p, List<Vector3> points, Func<GraphNode, bool> filter, NNConstraint nnConstraint)
		{
			return null;
		}

		protected bool ValidateLine(GraphNode n1, GraphNode n2, Vector3 v1, Vector3 v2, Func<GraphNode, bool> filter, NNConstraint nnConstraint)
		{
			return false;
		}
	}
}
