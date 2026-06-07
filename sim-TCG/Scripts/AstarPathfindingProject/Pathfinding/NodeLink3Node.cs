using System;
using UnityEngine;

namespace Pathfinding
{
	public class NodeLink3Node : PointNode
	{
		public NodeLink3 link;

		public Vector3 portalA;

		public Vector3 portalB;

		public NodeLink3Node(AstarPath astar)
		{
			astar.InitializeNode(this);
		}

		public override bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			left = portalA;
			right = portalB;
			if (connections.Length < 2)
			{
				return false;
			}
			if (connections.Length != 2)
			{
				throw new Exception("Invalid NodeLink3Node. Expected 2 connections, found " + connections.Length);
			}
			return true;
		}

		public GraphNode GetOther(GraphNode a)
		{
			if (connections.Length < 2)
			{
				return null;
			}
			if (connections.Length != 2)
			{
				throw new Exception("Invalid NodeLink3Node. Expected 2 connections, found " + connections.Length);
			}
			if (a != connections[0].node)
			{
				return (connections[0].node as NodeLink3Node).GetOtherInternal(this);
			}
			return (connections[1].node as NodeLink3Node).GetOtherInternal(this);
		}

		private GraphNode GetOtherInternal(GraphNode a)
		{
			if (connections.Length < 2)
			{
				return null;
			}
			if (a != connections[0].node)
			{
				return connections[0].node;
			}
			return connections[1].node;
		}
	}
}
