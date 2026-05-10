using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gley.TrafficSystem
{
	public class Events
	{
		public delegate void VehicleAdded(int vehicleIndex);

		public delegate void VehicleRemoved(int vehicleIndex);

		public delegate void DestinationReached(int vehicleIndex);

		public delegate void WaypointReached(int vehicleIndex, int waypointIndex, string data);

		public static VehicleAdded onVehicleAdded;

		public static VehicleRemoved onVehicleRemoved;

		public static DestinationReached onDestinationReached;

		public static WaypointReached onWaypointReached;

		public static event VehicleCrash onVehicleCrashed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void TriggerVehicleAddedEvent(int vehicleIndex)
		{
		}

		public static void TriggerVehicleRemovedEvent(int vehicleIndex)
		{
		}

		public static void TriggerVehicleCrashEvent(int vehicleIndex, ObstacleTypes obstacleType, Collider other)
		{
		}

		public static void TriggerDestinationReachedEvent(int vehicleIndex)
		{
		}

		public static void TriggerWaypointReachedEvent(int vehicleIndex, int waypointIndex, string data)
		{
		}
	}
}
