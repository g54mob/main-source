using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Link3")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/nodelink3.html")]
	public class NodeLink3 : GraphModifier
	{
		protected static Dictionary<GraphNode, NodeLink3> reference;

		public Transform end;

		public float costFactor;

		private NodeLink3Node startNode;

		private NodeLink3Node endNode;

		private MeshNode connectedNode1;

		private MeshNode connectedNode2;

		private Vector3 clamped1;

		private Vector3 clamped2;

		private bool postScanCalled;

		private static readonly Color GizmosColor;

		private static readonly Color GizmosColorSelected;

		public Transform StartTransform => null;

		public Transform EndTransform => null;

		public GraphNode StartNode => null;

		public GraphNode EndNode => null;

		public static NodeLink3 GetNodeLink(GraphNode node)
		{
			return null;
		}

		public override void OnPostScan()
		{
		}

		public void InternalOnPostScan()
		{
		}

		public override void OnGraphsPostUpdateBeforeAreaRecalculation()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void RemoveConnections(GraphNode node)
		{
		}

		[ContextMenu("Recalculate neighbours")]
		private void ContextApplyForce()
		{
		}

		public void Apply(bool forceNewCheck)
		{
		}

		public override void DrawGizmos()
		{
		}
	}
}
