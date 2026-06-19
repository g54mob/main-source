using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct MinecartRidingStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public int2 nextPlannedTurningWorldTilePos;

		[GhostField]
		public int2 vectorToNextPlannedTurningWorldTilePos;

		[GhostField]
		public int2 lastTurnedTile;

		[GhostField]
		public TickTimer timeSinceBreakingTimer;

		[GhostField]
		public float2 activeVelocity;

		[GhostField]
		public bool hasAPlannedTurningPointSet;

		[GhostField]
		public bool canTurn;

		[GhostField]
		public bool isBreaking;

		public bool IsMoving => math.length(activeVelocity) > 0f;

		public float Margin => 0.1f + 0.35f * math.clamp(math.length(activeVelocity) * 0.001f, 0f, 1f);
	}
}
