using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class DrivingAI : IDestroyable
	{
		private readonly ActiveActions[] _driveActions;

		private readonly BlinkType[] _blinkTypes;

		private readonly float[] _waypointSpeed;

		private readonly DriveActions[] _currentActiveAction;

		private readonly DriveActions[] _movingActions;

		private readonly WaypointManager _waypointManager;

		private readonly TrafficWaypointsDataHandler _trafficWaypointsDataHandler;

		private readonly AllVehiclesDataHandler _allVehiclesDataHandler;

		private readonly VehiclePositioningSystem _vehiclePositioningSystem;

		private readonly PositionValidator _positionValidator;

		private PlayerInTrigger _playerInTrigger;

		private DynamicObstacleInTrigger _dynamicObstacleInTrigger;

		private BuildingInTrigger _buildingInTrigger;

		private VehicleCrash _vehicleCrash;

		internal DrivingAI(int nrOfVehicles, WaypointManager waypointManager, TrafficWaypointsDataHandler trafficWaypointsDataHandler, AllVehiclesDataHandler trafficVehicles, VehiclePositioningSystem vehiclePositioningSystem, PositionValidator positionValidator, PlayerInTrigger playerInTrigger, DynamicObstacleInTrigger dynamicObstacleInTrigger, BuildingInTrigger buildingInTrigger, VehicleCrash vehicleCrash)
		{
		}

		public void Assign()
		{
		}

		internal void SetPlayerInTriggerDelegate(PlayerInTrigger newDelegate)
		{
		}

		internal void SetDynamicObstacleInTriggerDelegate(DynamicObstacleInTrigger newDelegate)
		{
		}

		internal void SetBuildingInTriggerDelegate(BuildingInTrigger newDelegate)
		{
		}

		internal void SetVehicleCrashDelegate(VehicleCrash newDelegate)
		{
		}

		internal void VehicleActivated(int vehicleIndex)
		{
		}

		internal void RemoveVehicle(int index)
		{
		}

		internal void RemoveDriveAction(int index, DriveActions newAction)
		{
		}

		internal void TimedActionEnded(int index)
		{
		}

		internal void WaypointRequested(int vehicleIndex, VehicleTypes vehicleType, bool clearPath)
		{
		}

		internal void SetBlinkType(int vehicleIndex, BlinkType value, bool reset = false)
		{
		}

		internal void SetHazardLights(int vehicleIndex, bool activate)
		{
		}

		internal void ChangeLane(bool active, int vehicleIndex, RoadSide side)
		{
		}

		internal void AddDriveAction(int index, DriveActions newAction, bool force = false, RoadSide side = RoadSide.Any)
		{
		}

		internal float GetMaxSpeedMS(int index)
		{
			return 0f;
		}

		internal float GetWaypointSpeed(int vehicleIndex)
		{
			return 0f;
		}

		private DriveActions GetTriggerAction(int myIndex, Collider other)
		{
			return default(DriveActions);
		}

		private void ObjectInTriggerHandler(int vehicleIndex, ObstacleTypes obstacleType, Collider other)
		{
		}

		private void PlayerInTrigger(int vehicleIndex, Collider other)
		{
		}

		private void DynamicObjectInTrigger(int vehicleIndex, Collider other)
		{
		}

		private void BuildingObjectInTrigger(int vehicleIndex, Collider other)
		{
		}

		private void ApplyAction(int index)
		{
		}

		private float GetActionValue(DriveActions action, int index)
		{
			return 0f;
		}

		private void StopStateChangedHandler(int index, bool stopState)
		{
		}

		private void GiveWayStateChangedHandler(int index, bool giveWayState)
		{
		}

		private bool AllClear(int vehicleIndex, int freeWaypointIndex, bool clearPath)
		{
			return false;
		}

		private void ContinueStraight(int vehicleIndex, VehicleTypes vehicleType)
		{
		}

		private void NoWaypointsAvailable(int vehicleIndex, int waypointIndex)
		{
		}

		private void SetNextWaypoint(int vehicleIndex, int freeWaypointIndex)
		{
		}

		private void Blink(BlinkReasons blinkReason, int index, int newWaypointindex)
		{
		}

		private BlinkType DetermineBlinkDirection(float angle)
		{
			return default(BlinkType);
		}

		private float ComputeMaxPossibleSpeed(int index)
		{
			return 0f;
		}

		private void TriggerClearedHandler(int vehicleIndex)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
