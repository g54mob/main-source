using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct GiantCicadaBossCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public GiantCicadaBossInternalState internalState;

	[GhostField]
	public Entity weakSpotEntity;

	public bool shouldSpawnGuardsNow;

	public ThreadSafeTimerSimple voidAttackCooldownTimer;
}
