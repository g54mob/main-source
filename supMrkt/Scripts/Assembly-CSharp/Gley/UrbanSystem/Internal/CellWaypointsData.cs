using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class CellWaypointsData
	{
		[SerializeField]
		private List<int> _waypoints;

		[SerializeField]
		private List<SpawnWaypoint> _spawnWaypoints;

		[SerializeField]
		private bool _hasWaypoints;

		[SerializeField]
		private bool _hasSpawnWaypoints;

		public List<int> Waypoints => null;

		public List<SpawnWaypoint> SpawnWaypoints => null;

		public bool HasWaypoints
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool HasSpawnWaypoints
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CellWaypointsData(List<int> waypoints, List<SpawnWaypoint> spawnWaypoints, bool hasWaypoints, bool hasSpawnWaypoints)
		{
		}
	}
}
