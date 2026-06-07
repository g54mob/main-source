using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public abstract class MeshNode : GraphNode
	{
		public Connection[] connections;

		public abstract Int3 GetVertex(int i);

		public abstract int GetVertexCount();

		public abstract Vector3 ClosestPointOnNodeXZ(Vector3 p);

		public override void ClearConnections(bool alsoReverse = true)
		{
		}

		public override void GetConnections<T>(NodeActionWithData<T> action, ref T data, int connectionFilter = 32)
		{
		}

		public override bool ContainsOutgoingConnection(GraphNode node)
		{
			return false;
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
		}

		public void AddPartialConnection(GraphNode node, uint cost, byte shapeEdgeInfo)
		{
		}

		public override void RemovePartialConnection(GraphNode node)
		{
		}

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
