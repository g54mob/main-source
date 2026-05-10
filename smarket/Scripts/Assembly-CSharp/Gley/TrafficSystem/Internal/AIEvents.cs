using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	public static class AIEvents
	{
		public delegate void ChangeDrivingState(int vehicleIndex, DriveActions action, float actionValue);

		public delegate void NotifyVehicles(int vehicleIndex, Collider collider);

		public delegate void ChangeDestination(int vehicleIndex);

		public static NotifyVehicles onNotifyVehicles;

		public static ChangeDestination onChangeDestination;

		public static event ChangeDrivingState onChangeDrivingState
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

		public static void TriggetChangeDrivingStateEvent(int vehicleIndex, DriveActions action, float actionValue)
		{
		}

		public static void TriggerNotifyVehiclesEvent(int vehicleIndex, Collider collider)
		{
		}

		public static void TriggerChangeDestinationEvent(int vehicleIndex)
		{
		}
	}
}
