using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class PathFindingDataHandler
	{
		private readonly PathFindingData _pedestrianPathFindingData;

		public PathFindingDataHandler(PathFindingData data)
		{
		}

		internal PathFindingWaypoint[] GetPathFindingWaypoints()
		{
			return null;
		}

		internal Vector3 GetWaypointPosition(int waypointIndex)
		{
			return default(Vector3);
		}

		internal int[] GetAllowedAgents(int waypointIndex)
		{
			return null;
		}

		private PathFindingWaypoint GetPathFindingWaypoint(int waypointIndex)
		{
			return null;
		}
	}
}
