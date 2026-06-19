using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct LastDamageTakenTimeCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public NetworkTick lastDamageTick;
}
