using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace Gley.TrafficSystem.Internal
{
	internal class DensityManager
	{
		private class RequestVehicle
		{
			internal UnityAction<VehicleComponent, int> CompleteMethod;

			internal List<int> Path;

			internal VehicleComponent Vehicle;

			internal VehicleTypes Type;

			internal Category Category;

			internal int Waypoint;

			internal RequestVehicle(int waypoint, VehicleTypes type, Category category, VehicleComponent vehicle, UnityAction<VehicleComponent, int> completeMethod, List<int> path)
			{
			}
		}

		private enum Category
		{
			Idle = 0,
			Ignored = 1
		}

		private readonly Queue<RequestVehicle> _requestedVehicles;

		private readonly AllVehiclesDataHandler _trafficVehicles;

		private readonly IdleVehiclesDataHandler _idleVehiclesDataHandler;

		private readonly PositionValidator _positionValidator;

		private readonly GridDataHandler _gridDataHandler;

		private readonly WaypointManager _waypointManager;

		private readonly TrafficWaypointsDataHandler _trafficWaypointsDataHandler;

		private readonly bool _useWaypointPriority;

		private readonly bool _debugDensity;

		private int _maxNrOfVehicles;

		private int _currentNrOfVehicles;

		private int _activeSquaresLevel;

		internal DensityManager(AllVehiclesDataHandler trafficVehicles, WaypointManager waypointManager, TrafficWaypointsDataHandler trafficWaypointsDataHandler, GridDataHandler gridDataHandler, PositionValidator positionValidator, NativeArray<float3> activeCameraPositions, int maxNrOfVehicles, Vector3 playerPosition, Vector3 playerDirection, int activeSquaresLevel, bool useWaypointPriority, int initialDensity, Area disableWaypointsArea, bool debugDensity)
		{
		}

		internal void SetTrafficDensity(int nrOfVehicles)
		{
		}

		internal void UpdateActiveSquares(int newLevel)
		{
		}

		internal void UpdateVehicleDensity(Vector3 playerPosition, Vector3 playerDirection, Vector3 activeCameraPosition)
		{
		}

		internal void AddExcludedVehicle(int vehicleIndex, Vector3 position, UnityAction<VehicleComponent, int> completeMethod)
		{
		}

		internal void AddVehicleAtPosition(Vector3 position, VehicleTypes type, UnityAction<VehicleComponent, int> completeMethod, List<int> path)
		{
		}

		internal void RemoveVehicle(int vehicleIndex)
		{
		}

		internal void UpdateCameraPositions(Transform[] activeCameras)
		{
		}

		internal void ExcludeVehicleFromSystem(int vehicleIndex)
		{
		}

		internal void AddExcludecVehicleToSystem(int vehicleIndex)
		{
		}

		internal void DisableAreaWaypoints(Area area)
		{
		}

		internal int GetClosestSpawnWaypoint(Vector3 position, VehicleTypes type)
		{
			return 0;
		}

		private void LoadInitialVehicles(List<CellData> gridCells, Vector3 playerPosition, Vector3 playerDirection)
		{
		}

		private void BeginAddVehicleProcess(Vector3 playerPosition, Vector3 playerDirection, CellData gridCell, bool ignorLOS)
		{
		}

		private void AddVehicleOnArea(Vector3 playerPosition, Vector3 playerDirection, CellData gridCell, bool ignorLOS)
		{
		}

		private bool AddVehicle(bool firstTime, int freeWaypointIndex, VehicleComponent vehicle)
		{
			return false;
		}

		public void InstantiateVehicle(int vehicleIndex, int targetWaypointIndex, Vector3 position, Quaternion rotation)
		{
		}
	}
}
