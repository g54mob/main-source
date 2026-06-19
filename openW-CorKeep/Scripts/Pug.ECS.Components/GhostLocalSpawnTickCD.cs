using Unity.Entities;
using Unity.NetCode;

public struct GhostLocalSpawnTickCD : IComponentData, IQueryTypeParameter
{
	public NetworkTick spawnTick;
}
