using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MagicBarrierCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int barrierHealth;

	[GhostField]
	public int barrierMaxHealth;

	[GhostField]
	public TickTimer barrierRegenTimer;
}
