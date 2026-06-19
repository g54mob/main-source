using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct DeathStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public bool allowHardcoreRespawn;

		[GhostField]
		public bool isDyingOrDead;

		[GhostField]
		public bool spawnedPlayer;

		[GhostField]
		public TickTimer respawnTimer;
	}
}
