using System;
using System.Collections.Generic;
using Motorways;
using UnityEngine;

public class MenuRoadPlanner : MonoBehaviour
{
	[Serializable]
	public struct RoadNode
	{
		public Vector2Int startPosition;

		public TileDirection direction;

		public int length;

		public Vector2Int StartPoint => startPosition;

		public Vector2Int EndPoint
		{
			get
			{
				Vector2Int adjacencyOffsetForDirection = TileUtilities.GetAdjacencyOffsetForDirection(direction);
				adjacencyOffsetForDirection.x *= length;
				adjacencyOffsetForDirection.y *= length;
				return startPosition + adjacencyOffsetForDirection;
			}
		}
	}

	public List<RoadNode> roads;

	public Vector3 offset;

	[TextArea]
	[Header("In Order: x, y, length, direction")]
	public string outputFormat = "ScheduleLineOfRoads(new Vector2Int({0}, {1}), {2}, TileDirection.{3})\n";
}
