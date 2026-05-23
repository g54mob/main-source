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
			position = value;
		}

		public PointNode()
		{
		}

		public PointNode(AstarPath astar)
		{
			astar.InitializeNode(this);
		}

		public override Vector3 ClosestPointOnNode(Vector3 p)
		{
			return (Vector3)position;
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

		public override void ClearConnections(bool alsoReverse)
		{
			if (alsoReverse && connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					connections[i].node.RemovePartialConnection(this);
				}
			}
			connections = null;
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public override bool ContainsOutgoingConnection(GraphNode node)
		{
			if (connections == null)
			{
				return false;
			}
			for (int i = 0; i < connections.Length; i++)
			{
				if (connections[i].node == node && connections[i].isOutgoing)
				{
					return true;
				}
			}
			return false;
		}

		public override void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming)
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
						connections[i].shapeEdgeInfo = Connection.PackShapeEdgeInfo(isOutgoing, isIncoming);
						return;
					}
				}
			}
			int num = ((connections != null) ? connections.Length : 0);
			Connection[] array = new Connection[num + 1];
			for (int j = 0; j < num; j++)
			{
				array[j] = connections[j];
			}
			array[num] = new Connection(node, cost, isOutgoing, isIncoming);
			connections = array;
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
			if (base.Graph is PointGraph pointGraph)
			{
				pointGraph.RegisterConnectionLength((node.position - position).sqrMagnitudeLong);
			}
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
					Connection[] array = new Connection[num - 1];
					for (int j = 0; j < i; j++)
					{
						array[j] = connections[j];
					}
					for (int k = i + 1; k < num; k++)
					{
						array[k - 1] = connections[k];
					}
					connections = array;
					AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
					break;
				}
			}
		}

		public override void Open(Path path, uint pathNodeIndex, uint gScore)
		{
			path.OpenCandidateConnectionsToEndNode(position, pathNodeIndex, pathNodeIndex, gScore);
			if (connections == null)
			{
				return;
			}
			for (int i = 0; i < connections.Length; i++)
			{
				GraphNode node = connections[i].node;
				if (connections[i].isOutgoing && path.CanTraverse(this, node))
				{
					if (node is PointNode)
					{
						path.OpenCandidateConnection(pathNodeIndex, node.NodeIndex, gScore, connections[i].cost, 0u, node.position);
					}
					else
					{
						node.OpenAtPoint(path, pathNodeIndex, position, gScore);
					}
				}
			}
		}

		public override void OpenAtPoint(Path path, uint pathNodeIndex, Int3 pos, uint gScore)
		{
			if (path.CanTraverse(this))
			{
				path.OpenCandidateConnectionsToEndNode(pos, pathNodeIndex, pathNodeIndex, gScore);
				uint costMagnitude = (uint)(pos - position).costMagnitude;
				path.OpenCandidateConnection(pathNodeIndex, base.NodeIndex, gScore, costMagnitude, 0u, position);
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

		public override void SerializeNode(GraphSerializationContext ctx)
		{
			base.SerializeNode(ctx);
			ctx.SerializeInt3(position);
		}

		public override void DeserializeNode(GraphSerializationContext ctx)
		{
			base.DeserializeNode(ctx);
			position = ctx.DeserializeInt3();
		}

		public override void SerializeReferences(GraphSerializationContext ctx)
		{
			ctx.SerializeConnections(connections, serializeMetadata: true);
		}

		public override void DeserializeReferences(GraphSerializationContext ctx)
		{
			connections = ctx.DeserializeConnections(ctx.meta.version >= AstarSerializer.V4_3_85);
		}
	}
}
