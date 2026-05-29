using System.Collections.Generic;
using UnityEngine;

namespace Gley.TrafficSystem
{
	public class DefaultDelegates
	{
		public static void PlayerInTriggerBehaviour(int vehicleIndex, Collider player)
		{
		}

		public static void DynamicObstacleInTriggerBehaviour(int vehicleIndex, Collider obstacle)
		{
		}

		public static void BuildingInTriggerBehaviour(int vehicleIndex, Collider building)
		{
		}

		public static void VehicleCrashBehaviour(int vehicleIndex, ObstacleTypes obstacleType, Collider other)
		{
		}

		private static DriveActions GetCrashAction(int myIndex, Collider other)
		{
			return default(DriveActions);
		}

		public static int GetRandomSpawnWaypoint(List<Vector2Int> neighbors, Vector3 position, Vector3 direction, VehicleTypes vehicleType, bool useWaypointPriority)
		{
			return 0;
		}

		public static int GetForwardSpawnWaypoint(List<Vector2Int> neighbors, Vector3 position, Vector3 direction, VehicleTypes vehicleType, bool useWaypointPriority)
		{
			return 0;
		}

		private static int GetPossibleWaypoint(Vector2Int selectedNeighbor, VehicleTypes vehicleType, bool usePriority)
		{
			return 0;
		}

		public static void TrafficLightBehaviour(TrafficLightsColor currentRoadColor, GameObject[] redLightObjects, GameObject[] yellowLightObjects, GameObject[] greenLightObjects, string name)
		{
		}

		private static void SetLight(bool active, GameObject[] lightObjects, string name)
		{
		}

		public static void TriggerSizeModifier(float currentSpeed, BoxCollider frontCollider, float maxSpeed, float minTriggerLength, float maxTriggerLength)
		{
		}
	}
}
