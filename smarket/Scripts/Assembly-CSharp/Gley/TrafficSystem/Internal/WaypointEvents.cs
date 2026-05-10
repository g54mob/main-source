using System.Runtime.CompilerServices;

namespace Gley.TrafficSystem.Internal
{
	public static class WaypointEvents
	{
		public delegate void TrafficLightChanged(int waypointIndex, bool stop);

		public delegate void StopStateChanged(int vehicleIndex, bool stopState);

		public delegate void GiveWayStateChanged(int vehicleIndex, bool giveWayState);

		public static event TrafficLightChanged onTrafficLightChanged
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

		public static event StopStateChanged onStopStateChanged
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

		public static event GiveWayStateChanged onGiveWayStateChanged
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

		public static void TriggerTrafficLightChangedEvent(int waypointIndex, bool stop)
		{
		}

		public static void TriggerStopStateChangedEvent(int vehicleIndex, bool stopState)
		{
		}

		public static void TriggerGiveWayStateChangedEvent(int vehicleIndex, bool giveWayState)
		{
		}
	}
}
