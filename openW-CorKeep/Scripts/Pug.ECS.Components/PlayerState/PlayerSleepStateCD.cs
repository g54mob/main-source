using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct PlayerSleepStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public bool wasPreviouslyForcedSleep;

		[GhostField]
		public TickTimer minSleepTimer;

		[GhostField]
		public TickTimer qualitySleepTimer;

		[GhostField]
		public bool wasPreviouslyAsleepFromBeingStill;
	}
}
