using System;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class PathFindingWaypoint : IHeapItem<PathFindingWaypoint>, IComparable<PathFindingWaypoint>
	{
		[SerializeField]
		private int[] _allowedAgents;

		[SerializeField]
		private int[] _neighbours;

		[SerializeField]
		private int[] _movementPenalty;

		[SerializeField]
		private Vector3 _worldPosition;

		[SerializeField]
		private int _listIndex;

		internal int[] Neighbours => null;

		internal int[] AllowedAgents => null;

		internal int[] MovementPenalty => null;

		internal Vector3 WorldPosition => default(Vector3);

		internal int ListIndex => 0;

		internal int FCost => 0;

		internal int Parent { get; set; }

		internal int GCost { get; set; }

		internal int HCost { get; set; }

		public int HeapIndex { get; set; }

		public PathFindingWaypoint(int listIndex, Vector3 worldPosition, int gCost, int hCost, int parent, int[] neighbours, int[] movementPenalty, int[] allowedAgents)
		{
		}

		public int CompareTo(PathFindingWaypoint nodeToCompare)
		{
			return 0;
		}
	}
}
