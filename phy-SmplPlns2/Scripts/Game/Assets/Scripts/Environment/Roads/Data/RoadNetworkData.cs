using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads.Data
{
	[CreateAssetMenu(fileName = "RoadNetworkData", menuName = "Cars/Road Network Data", order = 1)]
	public class RoadNetworkData : ScriptableObject
	{
		public enum RoadConnectionDirection
		{
			Forward = 0,
			Reverse = 1
		}

		[Serializable]
		public class Road
		{
			public int id;

			public string roadTypeId;

			public string segmentName;

			public float speedMultiplier = 1f;

			public List<Vector3> waypoints;
		}

		[Serializable]
		public class RoadConnection
		{
			public RoadConnectionDirection direction;

			public int entryLane = -1;

			public int entryRoadID;

			public int entryWaypointIndex;

			public int exitRoadID;

			public int exitWaypointIndex;

			public float probability;

			public bool reversed;
		}

		public List<RoadConnection> connections;

		public List<Road> roads;
	}
}
