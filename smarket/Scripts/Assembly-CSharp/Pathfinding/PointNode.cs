using System;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public class PointNode : GraphNode
	{
		public Connection[] connections;

		public GameObject gameObject;

		public void SetPosition(Int3 value)
		{
		}

		public PointNode(AstarPath astar)
			: base(null)
		{
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return default(Vector3);
		}

		public override void GetConnections(Action<GraphNode> action)
		{
		}

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override void UpdateRecursiveG(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public override bool ContainsConnection(GraphNode node)
		{
			return false;
		}

		public override void AddConnection(GraphNode node, uint cost)
		{
		}

		public override void RemoveConnection(GraphNode node)
		{
		}

		public override void Open(Path path, PathNode pathNode, PathHandler handler)
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
