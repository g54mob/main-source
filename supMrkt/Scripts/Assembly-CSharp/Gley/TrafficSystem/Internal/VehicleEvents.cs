using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	public static class VehicleEvents
	{
		public delegate void ObjectInTrigger(int vehicleIndex, ObstacleTypes obstacleType, Collider other);

		public delegate void TriggerCleared(int vehicleIndex);

		public static event ObjectInTrigger onObjectInTrigger
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

		public static event TriggerCleared onTriggerCleared
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

		public static void TriggerObjectInTriggerEvent(int vehicleIndex, ObstacleTypes obstacleType, Collider other)
		{
		}

		public static void TriggerTriggerClearedEvent(int vehicleIndex)
		{
		}
	}
}
