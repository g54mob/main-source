using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class KDTree
	{
		private class Node
		{
			public Node Left { get; set; }

			public Node Right { get; set; }

			public RoadNetworkWaypoints.RoadWaypoint Waypoint { get; set; }

			public Node(RoadNetworkWaypoints.RoadWaypoint waypoint)
			{
				Waypoint = waypoint;
				Left = null;
				Right = null;
			}
		}

		private readonly Node _root;

		public KDTree(List<RoadNetworkWaypoints.RoadWaypoint> waypoints)
		{
			_root = BuildTree(waypoints, 0);
		}

		public RoadNetworkWaypoints.RoadWaypoint FindNearest(Vector2 target)
		{
			return FindNearest(_root, target, 0).Waypoint;
		}

		private Node BuildTree(List<RoadNetworkWaypoints.RoadWaypoint> waypoints, int depth)
		{
			if (waypoints.Count == 0)
			{
				return null;
			}
			int axis = depth % 2;
			waypoints.Sort((RoadNetworkWaypoints.RoadWaypoint a, RoadNetworkWaypoints.RoadWaypoint b) => (axis != 0) ? a.Position.z.CompareTo(b.Position.z) : a.Position.x.CompareTo(b.Position.x));
			int num = waypoints.Count / 2;
			RoadNetworkWaypoints.RoadWaypoint waypoint = waypoints[num];
			List<RoadNetworkWaypoints.RoadWaypoint> range = waypoints.GetRange(0, num);
			List<RoadNetworkWaypoints.RoadWaypoint> range2 = waypoints.GetRange(num + 1, waypoints.Count - num - 1);
			return new Node(waypoint)
			{
				Left = BuildTree(range, depth + 1),
				Right = BuildTree(range2, depth + 1)
			};
		}

		private Node CloserDistance(Vector2 target, Node a, Node b)
		{
			if (a == null)
			{
				return b;
			}
			if (b == null)
			{
				return a;
			}
			float num = Vector2.Distance(new Vector2(a.Waypoint.Position.x, a.Waypoint.Position.z), target);
			float num2 = Vector2.Distance(new Vector2(b.Waypoint.Position.x, b.Waypoint.Position.z), target);
			if (!(num < num2))
			{
				return b;
			}
			return a;
		}

		private Node FindNearest(Node node, Vector2 target, int depth)
		{
			if (node == null)
			{
				return null;
			}
			Node node2 = null;
			Node node3 = null;
			int num = depth % 2;
			if (num == 0)
			{
				if (target.x < node.Waypoint.Position.x)
				{
					node2 = node.Left;
					node3 = node.Right;
				}
				else
				{
					node2 = node.Right;
					node3 = node.Left;
				}
			}
			else if (target.y < node.Waypoint.Position.z)
			{
				node2 = node.Left;
				node3 = node.Right;
			}
			else
			{
				node2 = node.Right;
				node3 = node.Left;
			}
			Node node4 = CloserDistance(target, FindNearest(node2, target, depth + 1), node);
			if (((num == 0) ? ((target.x - node.Waypoint.Position.x) * (target.x - node.Waypoint.Position.x)) : ((target.y - node.Waypoint.Position.z) * (target.y - node.Waypoint.Position.z))) < Vector2.Distance(new Vector2(node.Waypoint.Position.x, node.Waypoint.Position.z), target))
			{
				node4 = CloserDistance(target, FindNearest(node3, target, depth + 1), node4);
			}
			return node4;
		}
	}
}
