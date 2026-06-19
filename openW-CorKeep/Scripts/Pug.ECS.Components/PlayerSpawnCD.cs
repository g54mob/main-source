using Unity.Entities;
using Unity.NetCode;

public struct PlayerSpawnCD : IComponentData, IQueryTypeParameter
{
	public const float IMMUNITY_TIME_AFTER_SPAWN = 4f;

	[GhostField]
	public NetworkTick lastRespawnTick;
}
