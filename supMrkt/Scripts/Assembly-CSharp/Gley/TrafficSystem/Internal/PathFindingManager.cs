using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class PathFindingManager
	{
		private readonly GridDataHandler _gridDataHandler;

		private readonly PathFindingDataHandler _trafficPathFindingDataHandler;

		private readonly AStar _aStar;

		internal PathFindingManager(GridDataHandler gridDataHandler, PathFindingDataHandler trafficPathFindingDataHandler)
		{
		}

		internal List<int> GetPathToDestination(int vehicleIndex, int currentWaypointIndex, Vector3 position, VehicleTypes vehicleType)
		{
			return null;
		}

		internal List<int> GetPath(Vector3 startPosition, Vector3 endPosition, VehicleTypes vehicleType)
		{
			return null;
		}

		private int GetClosestPathFindingWaypoint(Vector3 position, int type)
		{
			return 0;
		}
	}
}
