using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class TrafficWaypointsDataHandler
	{
		private readonly TrafficWaypointsData _trafficWaypointsData;

		internal TrafficWaypointsDataHandler(TrafficWaypointsData data)
		{
		}

		internal void SetTemperaryDisabledValue(int waypointIndex, bool value)
		{
		}

		internal void SetTemperaryDisabledValue(List<int> waypointIndexes, bool value)
		{
		}

		internal void SetIntersection(int waypointIndex, IIntersection intersection, bool giveWay, bool stop, bool enter, bool exit)
		{
		}

		internal void SetStopValue(int waypointIndex, bool value)
		{
		}

		private void SetTriggerEventValue(int waypointIndex, bool value)
		{
		}

		private void SetGiveWayValue(int waypointIndex, bool value)
		{
		}

		internal void SetEventData(int waypointIndex, string data)
		{
		}

		internal TrafficWaypoint GetWaypointFromIndex(int waypointIndex)
		{
			return null;
		}

		internal VehicleTypes[] GetAllowedVehicles(int waypointIndex)
		{
			return null;
		}

		internal int[] GetNeighbors(int waypointIndex)
		{
			return null;
		}

		internal int[] GetOtherLanes(int waypointIndex)
		{
			return null;
		}

		internal int[] GetPrevs(int waypointIndex)
		{
			return null;
		}

		internal int[] GetGiveWayWaypointList(int waypointIndex)
		{
			return null;
		}

		internal List<int> GetNeighborsWithConditions(int waypointIndex, VehicleTypes vehicleType)
		{
			return null;
		}

		internal List<int> GetNeighborsWithConditions(int waypointIndex)
		{
			return null;
		}

		internal List<int> GetOtherLanesWithConditions(int waypointIndex, VehicleTypes vehicleType)
		{
			return null;
		}

		internal List<int> GetOtherLanesWithConditions(int waypointIndex)
		{
			return null;
		}

		internal Vector3 GetPosition(int waypointIndex)
		{
			return default(Vector3);
		}

		internal string GetName(int waypointIndex)
		{
			return null;
		}

		internal float GetLaneWidth(int waypointIndex)
		{
			return 0f;
		}

		internal string GetEventData(int waypointIndex)
		{
			return null;
		}

		internal float GetMaxSpeed(int waypointIndex)
		{
			return 0f;
		}

		internal bool HasNeighbors(int waypointIndex)
		{
			return false;
		}

		internal bool HasPrevs(int waypointIndex)
		{
			return false;
		}

		internal List<IIntersection> GetAssociatedIntersections(int waypointIndex)
		{
			return null;
		}

		internal bool HasNeighborsForVehicleType(int waypointIndex, VehicleTypes vehicleType)
		{
			return false;
		}

		internal bool HasWaypointInNeighbors(int waypointIndex, int waypointToCheck)
		{
			return false;
		}

		internal bool HasOtherLanes(int waypointIndex)
		{
			return false;
		}

		internal bool IsTemporaryDisabled(int waypointIndex)
		{
			return false;
		}

		internal bool IsInIntersection(int waypointIndex)
		{
			return false;
		}

		internal bool IsComplexGiveWay(int waypointIndex)
		{
			return false;
		}

		internal bool IsZipperGiveWay(int waypointIndex)
		{
			return false;
		}

		internal bool IsStop(int waypointIndex)
		{
			return false;
		}

		internal bool IsGiveWay(int waypointIndex)
		{
			return false;
		}

		internal bool IsExit(int waypointIndex)
		{
			return false;
		}

		internal bool IsEnter(int waypointIndex)
		{
			return false;
		}

		internal bool IsTriggerEvent(int waypointIndex)
		{
			return false;
		}

		private bool IsWaypointIndexValid(int waypointIndex)
		{
			return false;
		}

		private TrafficWaypoint GetWaypoint(int waypointIndex)
		{
			return null;
		}
	}
}
