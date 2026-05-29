using System;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public abstract class MeshNode : GraphNode
	{
		public Connection[] connections;

		protected MeshNode(AstarPath astar)
			: base(null)
		{
		}

		public abstract Int3 GetVertex(int i);

		public abstract int GetVertexCount();

		public abstract Vector3 ClosestPointOnNodeXZ(Vector3 p);

		public override void ClearConnections(bool alsoReverse)
		{
		}

		public override void GetConnections(Action<GraphNode> action)
		{
		}

		public override bool ContainsConnection(GraphNode node)
		{
			return false;
		}

		public override void UpdateRecursiveG(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public override void AddConnection(GraphNode node, uint cost)
		{
		}

		public void AddConnection(GraphNode node, uint cost, byte shapeEdge)
		{
		}

		public override void RemoveConnection(GraphNode node)
		{
		}

		public virtual bool ContainsPoint(Int3 point)
		{
			return false;
		}

		public abstract bool ContainsPoint(Vector3 point);

		public abstract bool ContainsPointInGraphSpace(Int3 point);

		public override int GetGizmoHashCode()
		{
			return 0;
		}

		public override void SerializeReferences(GraphSerializationContext ctx)
		{
		}

		public override void DeserializeReferences(GraphSerializationContext ctx)
		{
		}
	}
}
