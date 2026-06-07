using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Link2")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_node_link2.php")]
	public class NodeLink2 : GraphModifier
	{
		protected static Dictionary<GraphNode, NodeLink2> reference;

		public Transform end;

		public float costFactor;

		public bool oneWay;

		private GraphNode connectedNode1;

		private GraphNode connectedNode2;

		private Vector3 clamped1;

		private Vector3 clamped2;

		private bool postScanCalled;

		private static readonly Color GizmosColor;

		private static readonly Color GizmosColorSelected;

		public Transform StartTransform => null;

		public Transform EndTransform => null;

		public PointNode startNode { get; private set; }

		public PointNode endNode { get; private set; }

		[Obsolete("Use startNode instead (lowercase s)")]
		public GraphNode StartNode => null;

		[Obsolete("Use endNode instead (lowercase e)")]
		public GraphNode EndNode => null;

		public static NodeLink2 GetNodeLink(GraphNode node)
		{
			return null;
		}

		public override void OnPostScan()
		{
		}

		public void InternalOnPostScan()
		{
		}

		public override void OnGraphsPostUpdate()
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

		public virtual void OnDrawGizmosSelected()
		{
		}

		public void OnDrawGizmos()
		{
		}

		public void OnDrawGizmos(bool selected)
		{
		}

		internal static void SerializeReferences(GraphSerializationContext ctx)
		{
		}

		internal static void DeserializeReferences(GraphSerializationContext ctx)
		{
		}
	}
}
