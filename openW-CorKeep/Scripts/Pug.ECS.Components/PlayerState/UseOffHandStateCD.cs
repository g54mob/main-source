using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct UseOffHandStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer offHandCooldownTimer;

		[GhostField]
		public float shieldedAmount;

		[GhostField]
		public float3 initialDashDirection;

		[GhostField]
		public TickTimer moveTimer;

		[GhostField]
		public TickTimer minionDetonationTimer;

		[GhostField]
		public TickTimer remoteDetonatorTimer;

		[GhostField]
		public TickTimer minShieldTimer;

		[GhostField]
		public TickTimer parryTimer;

		[GhostField]
		public bool remoteDetonatorHadAnyTriggered;

		public bool useDashNextUpdate;

		public bool useMinionDetonationNextUpdate;

		public bool useRemoteDetonatorNextUpdate;

		public bool IsParrying(NetworkTick currentTick)
		{
			if (!parryTimer.IsTimerElapsed(currentTick))
			{
				return parryTimer.isRunning;
			}
			return false;
		}
	}
}
