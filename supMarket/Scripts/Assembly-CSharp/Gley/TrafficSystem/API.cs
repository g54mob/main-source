using System;
using System.Collections.Generic;
using Gley.TrafficSystem.Internal;
using Gley.UrbanSystem.Internal;
using UnityEngine;
using UnityEngine.Events;

namespace Gley.TrafficSystem
{
	public static class API
	{
		public static void Initialize(Transform activeCamera, int nrOfVehicles, VehiclePool vehiclePool)
		{
		}

		public static void Initialize(Transform activeCamera, int nrOfVehicles, VehiclePool vehiclePool, TrafficOptions trafficOptions)
		{
		}

		public static void Initialize(Transform[] activeCameras, int nrOfVehicles, VehiclePool vehiclePool, TrafficOptions trafficOptions)
		{
		}

		public static bool IsInitialized()
		{
			return false;
		}

		public static void SetCamera(Transform activeCamera)
		{
		}

		public static void SetCameras(Transform[] activeCameras)
		{
		}

		public static void ClearPathForSpecialVehicles(bool active, RoadSide side)
		{
		}

		public static void StopVehicleDriving(GameObject vehicle)
		{
		}

		public static void AddVehicleWithPath(Vector3 position, VehicleTypes vehicleType, Vector3 destination)
		{
		}

		public static void AddVehicleWithPath(Vector3 position, VehicleTypes vehicleType, Vector3 destination, UnityAction<VehicleComponent, int> completeMethod)
		{
		}

		public static void RemoveVehicle(GameObject vehicle)
		{
		}

		public static void RemoveVehicle(int vehicleIndex)
		{
		}

		public static void ClearTrafficOnArea(Vector3 center, float radius)
		{
		}

		public static void SetActiveSquares(int level)
		{
		}

		public static void SetTrafficDensity(int nrOfVehicles)
		{
		}

		public static void DisableAreaWaypoints(Vector3 center, float radius)
		{
		}

		public static void AddExcludedVehicle(int vehicleIndex, Vector3 position)
		{
		}

		public static void AddExcludedVehicle(int vehicleIndex, Vector3 position, UnityAction<VehicleComponent, int> completeMethod)
		{
		}

		public static void AddVehicle(Vector3 position, VehicleTypes vehicleType)
		{
		}

		public static void AddVehicle(Vector3 position, VehicleTypes vehicleType, UnityAction<VehicleComponent, int> completeMethod)
		{
		}

		public static void UpdateVehicleLights(bool on)
		{
		}

		public static void SetEngineVolume(float volume)
		{
		}

		public static void ExcludeVehicleFromSystem(int vehicleIndex)
		{
		}

		public static void AddExcludedVehicleToSystem(int vehicleIndex)
		{
		}

		public static int GetVehicleIndex(GameObject vehicle)
		{
			return 0;
		}

		public static VehicleComponent GetVehicleComponent(int vehicleIndex)
		{
			return null;
		}

		public static List<VehicleComponent> GetExcludedVehicleList()
		{
			return null;
		}

		public static int GetExcludedVehicleIndex(GameObject vehicle)
		{
			return 0;
		}

		public static void TriggerColliderRemovedEvent(Collider collider)
		{
		}

		public static void TriggerColliderRemovedEvent(Collider[] collider)
		{
		}

		[Obsolete("GetVehicleList is deprecated, please use GetAllVehicles instead.")]
		public static List<VehicleComponent> GetVehicleList()
		{
			return null;
		}

		public static VehicleComponent[] GetAllVehicles()
		{
			return null;
		}

		public static float GetVehicleSpeed(int vehicleIndex)
		{
			return 0f;
		}

		public static DriveActions GetVehicleState(int vehicleIndex)
		{
			return default(DriveActions);
		}

		public static void RemoveVehicleControl(int vehicleIndex)
		{
		}

		public static void AddVehicleControl(int vehicleIndex)
		{
		}

		public static void EnableAllWaypoints()
		{
		}

		public static void SetVehiclePath(int vehicleIndex, Queue<int> pathWaypoints)
		{
		}

		public static void RemoveVehiclePath(int vehicleIndex)
		{
		}

		public static TrafficWaypoint GetWaypointFromIndex(int waypointIndex)
		{
			return null;
		}

		public static void AddWaypointEvent(int waypointIndex, string data)
		{
		}

		public static void RemoveWaypointEvent(int waypointIndex)
		{
		}

		public static void SetIntersectionRoadToGreen(string intersectionName, int roadIndex, bool doNotChangeAgain = false)
		{
		}

		public static void SetHazardLights(int vehicleIndex, bool activate)
		{
		}

		public static void AddDrivingAction(int vehicleIndex, DriveActions action, bool force)
		{
		}

		public static void RemoveDrivingAction(int vehicleIndex, DriveActions action)
		{
		}

		public static void ChangeLane(bool active, int vehicleIndex, RoadSide side = RoadSide.Any)
		{
		}

		public static void SetDestination(int vehicleIndex, Vector3 position)
		{
		}

		public static List<int> GetPath(Vector3 startPosition, Vector3 endPosition, VehicleTypes vehicleType)
		{
			return null;
		}

		public static void SetPriorityCrossingStopState(string crossingName, bool stop, bool stopUpdate = true)
		{
		}

		public static bool GetPriorityCrossingStopState(string crossingName)
		{
			return false;
		}

		public static TrafficLightsColor GetTrafficLightsCrossingState(string crossingName)
		{
			return default(TrafficLightsColor);
		}

		public static void SetTrafficLightsCrossingState(string crossingName, TrafficLightsColor newColor, bool stopUpdate = false)
		{
		}

		internal static GridDataHandler GetGridDataHandler()
		{
			return null;
		}

		public static void InstantiateTrafficVehicle(int vehicleIndex, Vector3 frontWheelsPosition, Quaternion vehicleRotation, Vector3 initialVelocity, Vector3 initialAngularVelocity, int nextWaypointIndex)
		{
		}

		public static int GetClosestWaypoint(Vector3 position, Vector3 direction)
		{
			return 0;
		}
	}
}
