using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class WaypointManager : IDestroyable
	{
		private readonly Dictionary<int, int> _playerTarget;

		private readonly int[] _target;

		private readonly bool[] _hasPath;

		private readonly Dictionary<int, Queue<int>> _pathToDestination;

		private readonly GridDataHandler _gridDataHandler;

		private readonly TrafficWaypointsDataHandler _trafficWaypointsDataHandler;

		private List<int> _disabledWaypoints;

		private SpawnWaypointSelector _spawnWaypointSelector;

		private bool _debugGiveWay;

		internal WaypointManager(TrafficWaypointsDataHandler trafficWaypointsDataHandler, GridDataHandler gridDataHandler, int nrOfVehicles, SpawnWaypointSelector spawnWaypointSelector, bool debugGIveWay)
		{
		}

		public void Assign()
		{
		}

		internal int[] GetTargetWaypoints()
		{
			return null;
		}

		internal int GetTargetWaypointIndex(int agentIndex)
		{
			return 0;
		}

		internal Quaternion GetNextOrientation(int waypointIndex)
		{
			return default(Quaternion);
		}

		internal Quaternion GetPrevOrientation(int waypointIndex)
		{
			return default(Quaternion);
		}

		internal void EnableAllWaypoints()
		{
		}

		internal void AddDisabledWaypoint(int waypointIndex)
		{
		}

		internal List<int> GetDisabledWaypoints()
		{
			return null;
		}

		internal int GetCurrentLaneWaypointIndex(int agentIndex, VehicleTypes vehicleType)
		{
			return 0;
		}

		internal int GetAgentIndexAtTarget(int waypointIndex)
		{
			return 0;
		}

		internal void RegisterPlayer(int id, int waypointIndex)
		{
		}

		internal void UpdatePlayerWaypoint(int id, int waypointIndex)
		{
		}

		internal bool IsThisWaypointATarget(int waypointIndex)
		{
			return false;
		}

		internal bool AreTheseWaypointsATarget(int[] waypointsToCheck)
		{
			return false;
		}

		internal bool HaveCommonNeighbors(int fromWaypointIndex, int toWaypointIndex, int level = 0)
		{
			return false;
		}

		internal void SetNextWaypoint(int vehicleIndex, int waypointIndex)
		{
		}

		internal void RemoveAgent(int agentIndex)
		{
		}

		internal void SetTargetWaypoint(int agentIndex, int waypointIndex)
		{
		}

		internal bool CanContinueStraight(int vehicleIndex, VehicleTypes vehicleType)
		{
			return false;
		}

		internal bool CanEnterIntersection(int vehicleIndex)
		{
			return false;
		}

		internal bool AllPreviousWaypointsAreFree(int vehicleIndex, float distance, int waypointToCheck, ref int incomingCarIndex)
		{
			return false;
		}

		internal int IsInFront(int vehicleIndex1, int vehicleIndex2)
		{
			return 0;
		}

		internal bool IsSameTarget(int vehicleIndex1, int VehicleIndex2)
		{
			return false;
		}

		internal Quaternion GetTargetWaypointRotation(int agentIndex)
		{
			return default(Quaternion);
		}

		internal int GetOtherLaneWaypointIndex(int agentIndex, VehicleTypes vehicleType, RoadSide side = RoadSide.Any, Vector3 forwardVector = default(Vector3))
		{
			return 0;
		}

		internal int GetNeighborCellWaypoint(int row, int column, int depth, VehicleTypes carType, Vector3 playerPosition, Vector3 playerDirection, bool useWaypointPriority)
		{
			return 0;
		}

		internal void SetSpawnWaypointSelector(SpawnWaypointSelector spawnWaypointSelector)
		{
		}

		internal void SetAgentPath(int agentIndex, Queue<int> pathWaypoints)
		{
		}

		internal void RemoveAgentPath(int agentIndex)
		{
		}

		internal bool HasPath(int agentIndex)
		{
			return false;
		}

		internal Queue<int> GetPath(int agentIndex)
		{
			return null;
		}

		private void SetTargetWaypointIndex(int agentIndex, int waypointIndex)
		{
		}

		private void MarkWaypointAsPassed(int vehicleIndex)
		{
		}

		private bool IsTargetFree(int waypointIndex, float distance, int initialWaypointIndex, int currentCarIndex, ref int incomingCarIndex)
		{
			return false;
		}

		private int PeekPoint(int agentIndex)
		{
			return 0;
		}

		private int GetSideWaypoint(List<int> waypointIndexes, int currentWaypointIndex, RoadSide side, Vector3 forwardVector)
		{
			return 0;
		}

		private void TrafficLightChanged(int waypointIndex, bool newValue)
		{
		}

		private int ApplyNeighborSelectorMethod(List<Vector2Int> neighbors, Vector3 playerPosition, Vector3 playerDirection, VehicleTypes carType, bool useWaypointPriority)
		{
			return 0;
		}

		public void OnDestroy()
		{
		}
	}
}
