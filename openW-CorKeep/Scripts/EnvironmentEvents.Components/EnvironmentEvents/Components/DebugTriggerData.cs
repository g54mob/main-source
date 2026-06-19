using Unity.Burst;

namespace EnvironmentEvents.Components
{
	public struct DebugTriggerData
	{
		public EnvironmentEventType attemptToTriggerEventNow;

		public bool bypassTriggerRequirements;

		public bool resetEventCooldowns;

		public bool eventsDisabled;

		public static readonly SharedStatic<DebugTriggerData> debugTriggerData = SharedStatic<DebugTriggerData>.GetOrCreateUnsafe(0u, -6282299995484106980L, 0L);
	}
}
