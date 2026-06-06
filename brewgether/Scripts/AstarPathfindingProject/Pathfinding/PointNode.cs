using System;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class PointNode : GraphNode
	{
		public Connection[] connections;

		public GameObject gameObject;

		[Obsolete("Set node.position instead")]
		public void SetPosition(Int3 value)
		{
		}

		public PointNode()
		{
		}

		public PointNode(AstarPath astar)
		{
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return default(Vector3);
		}

		public override bool ContainsPoint(Vector3 point)
		{
			return false;
		}

		public override bool ContainsPointInGraphSpace(Int3 point)
		{
			return false;
		}

		public override void GetConnections<T>(GetConnectionsWithData<T> action, ref T data, int connectionFilter)
		{
		}

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override bool ContainsOutgoingConnection(GraphNode node)
		{
			return false;
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
		}

		public override void RemovePartialConnection(GraphNode node)
		{
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
		}

		public override void OpenAtPoint(Path path, uint pathNodeIndex, Int3 pos, uint gScore)
		{
		}

		public override int GetGizmoHashCode()
		{
			return 0;
		}

		public override void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
		}

		public override void SerializeReferences(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeReferences(GraphSerializationContext ctx)
		{
		}
	}
}
