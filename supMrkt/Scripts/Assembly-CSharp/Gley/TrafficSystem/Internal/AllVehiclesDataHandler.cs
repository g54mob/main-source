using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using Unity.Mathematics;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class AllVehiclesDataHandler
	{
		private readonly AllVehiclesData _allVehiclesData;

		internal AllVehiclesDataHandler(AllVehiclesData allVehiclesData)
		{
		}

		internal VehicleComponent[] GetAllVehicles()
		{
			return null;
		}

		internal VehicleComponent GetVehicle(int vehicleIndex)
		{
			return null;
		}

		internal Rigidbody GetRigidbody(int vehicleIndex)
		{
			return null;
		}

		internal Rigidbody GetTrailerRigidbody(int vehicleIndex)
		{
			return null;
		}

		internal Vector3 GetTrailerVelocity(int vehicleIndex)
		{
			return default(Vector3);
		}

		internal List<VehicleComponent> GetExcludedVehicleList()
		{
			return null;
		}

		internal int GetExcludedVehicleIndex(GameObject vehicle)
		{
			return 0;
		}

		internal bool VehicleIsExcluded(int vehicleIndex)
		{
			return false;
		}

		internal VehicleComponent GetExcludedVehicle(int vehicleIndex)
		{
			return null;
		}

		internal void SetExcludedValue(int vehicleIndex, bool excluded)
		{
		}

		internal void SetReverseLights(int vehicleIndex, bool active)
		{
		}

		internal void SetBrakeLights(int vehicleIndex, bool active)
		{
		}

		internal VehicleTypes GetVehicleType(int vehicleIndex)
		{
			return default(VehicleTypes);
		}

		internal void RemoveVehicle(int vehicleIndex)
		{
		}

		internal bool CanBeRemoved(int vehicleIndex)
		{
			return false;
		}

		internal Vector3 GetVelocity(int vehicleIndex)
		{
			return default(Vector3);
		}

		internal float GetCurrentSpeed(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetFollowSpeed(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetVehicleLength(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetVehicleWidth(int vehicleIndex)
		{
			return 0f;
		}

		internal void ActivateVehicle(VehicleComponent vehicle, Vector3 position, Quaternion vehicleRotation, Quaternion trailerRotation)
		{
		}

		internal Collider GetCollider(int vehicleIndex)
		{
			return null;
		}

		internal Vector3 GetHeading(int vehicleIndex)
		{
			return default(Vector3);
		}

		internal Vector3 GetForwardVector(int vehicleIndex)
		{
			return default(Vector3);
		}

		internal void SetCurrentAction(int vehicleIndex, DriveActions currentAction)
		{
		}

		internal void CurrentVehicleActionDone(int vehicleIndex)
		{
		}

		internal DriveActions GetCurrentAction(int vehicleIndex)
		{
			return default(DriveActions);
		}

		internal float GetMaxSpeed(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetPossibleMaxSpeed(int vehicleIndex)
		{
			return 0f;
		}

		internal void SetBlinkLights(int vehicleIndex, BlinkType blinkType)
		{
		}

		internal float GetSpringForce(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetPowerStep(int vehicleIndex)
		{
			return 0f;
		}

		internal float GetBrakeStep(int vehicleIndex)
		{
			return 0f;
		}

		internal Vector3 GetGroundDirection(int vehicleIndex)
		{
			return default(Vector3);
		}

		internal void UpdateVehicleScripts(int vehicleIndex, float volume, float realTimeSinceStartup)
		{
		}

		internal void UpdateVehicleLights(bool on)
		{
		}

		internal void TriggerColliderRemovedEvent(Collider[] colliders)
		{
		}

		internal float GetTriggerSize(int vehicleIndex)
		{
			return 0f;
		}

		internal void ModifyTriggerSize(int vehicleIndex, ModifyTriggerSize modifyTriggerSizeDelegate)
		{
		}

		internal float3 GetClosestObstacle(int vehicleIndex)
		{
			return default(float3);
		}

		internal Collider[] GetAllColliders(int vehicleIndex)
		{
			return null;
		}

		internal void SetMaxSpeed(int vehicleIndex, float speed)
		{
		}

		internal void ResetMaxSpeed(int vehicleIndex)
		{
		}

		internal bool HasTrailer(int vehicleIndex)
		{
			return false;
		}

		internal int GetTrailerWheels(int vehicleIndex)
		{
			return 0;
		}

		internal int GetVehicleIndex(GameObject vehicle)
		{
			return 0;
		}

		internal int GetTotalWheels()
		{
			return 0;
		}
	}
}
