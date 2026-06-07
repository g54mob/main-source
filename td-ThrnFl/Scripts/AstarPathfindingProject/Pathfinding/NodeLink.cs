using System;
using Pathfinding.Drawing;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Link")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/nodelink.html")]
	public class NodeLink : GraphModifier
	{
		public Transform end;

		public float costFactor = 1f;

		public bool oneWay;

		public bool deleteConnection;

		public Transform Start => base.transform;

		public Transform End => end;

		public override void OnGraphsPostUpdateBeforeAreaRecalculation()
		{
			Apply();
		}

		public static void DrawArch(Vector3 a, Vector3 b, Vector3 up, Color color)
		{
			Vector3 vector = b - a;
			if (!(vector == Vector3.zero))
			{
				Vector3 rhs = Vector3.Cross(up, vector);
				Vector3 vector2 = Vector3.Cross(vector, rhs).normalized * vector.magnitude * 0.1f;
				Draw.Bezier(a, a + vector2, b + vector2, b, color);
			}
		}

		public virtual void Apply()
		{
			if (Start == null || End == null || AstarPath.active == null)
			{
				return;
			}
			GraphNode node = AstarPath.active.GetNearest(Start.position).node;
			GraphNode node2 = AstarPath.active.GetNearest(End.position).node;
			if (node != null && node2 != null)
			{
				if (deleteConnection)
				{
					GraphNode.Disconnect(node, node2);
					return;
				}
				uint cost = (uint)Math.Round((float)(node.position - node2.position).costMagnitude * costFactor);
				GraphNode.Connect(node, node2, cost, (!oneWay) ? OffMeshLinks.Directionality.TwoWay : OffMeshLinks.Directionality.OneWay);
			}
		}

		public override void DrawGizmos()
		{
			if (!(Start == null) && !(End == null))
			{
				DrawArch(Start.position, End.position, Vector3.up, deleteConnection ? Color.red : Color.green);
			}
		}
	}
}
