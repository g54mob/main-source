using System;
using Pathfinding.Serialization;
using Pathfinding.Util;
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
			if (alsoReverse && connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					connections[i].node.RemovePartialConnection(this);
				}
			}
			ArrayPool<Connection>.Release(ref connections, allowNonPowerOfTwo: true);
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public override void GetConnections<T>(GetConnectionsWithData<T> action, ref T data, int connectionFilter = 32)
		{
			if (connections == null)
			{
				return;
			}
			for (int i = 0; i < connections.Length; i++)
			{
				if ((connections[i].shapeEdgeInfo & connectionFilter) != 0)
				{
					action(connections[i].node, ref data);
				}
			}
		}

		public override bool ContainsOutgoingConnection(GraphNode node)
		{
			if (connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					if (connections[i].node == node && connections[i].isOutgoing)
					{
						return true;
					}
				}
			}
			return false;
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
		{
			AddPartialConnection(node, cost, Connection.PackShapeEdgeInfo(isOutgoing, isIncoming));
		}

		public void AddPartialConnection(GraphNode node, uint cost, byte shapeEdgeInfo)
		{
			if (node == null)
			{
				throw new ArgumentNullException();
			}
			if (connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					if (connections[i].node == node)
					{
						connections[i].cost = cost;
						connections[i].shapeEdgeInfo = shapeEdgeInfo;
						return;
					}
				}
			}
			int num = ((connections != null) ? connections.Length : 0);
			Connection[] array = ArrayPool<Connection>.ClaimWithExactLength(num + 1);
			for (int j = 0; j < num; j++)
			{
				array[j] = connections[j];
			}
			array[num] = new Connection(node, cost, shapeEdgeInfo);
			if (connections != null)
			{
				ArrayPool<Connection>.Release(ref connections, allowNonPowerOfTwo: true);
			}
			connections = array;
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public override void RemovePartialConnection(GraphNode node)
		{
			if (connections == null)
			{
				return;
			}
			for (int i = 0; i < connections.Length; i++)
			{
				if (connections[i].node == node)
				{
					int num = connections.Length;
					Connection[] array = ArrayPool<Connection>.ClaimWithExactLength(num - 1);
					for (int j = 0; j < i; j++)
					{
						array[j] = connections[j];
					}
					for (int k = i + 1; k < num; k++)
					{
						array[k - 1] = connections[k];
					}
					if (connections != null)
					{
						ArrayPool<Connection>.Release(ref connections, allowNonPowerOfTwo: true);
					}
					connections = array;
					AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
					break;
				}
			}
		}

		public override int GetGizmoHashCode()
		{
			int num = base.GetGizmoHashCode();
			if (connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					num ^= 17 * connections[i].GetHashCode();
				}
			}
			return num;
		}

		public override void SerializeReferences(GraphSerializationContext ctx)
		{
			ctx.SerializeConnections(connections, serializeMetadata: true);
		}

		public override void DeserializeReferences(GraphSerializationContext ctx)
		{
			connections = ctx.DeserializeConnections(deserializeMetadata: true);
		}
	}
}
