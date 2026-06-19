using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MineableCD : IComponentData, IQueryTypeParameter
{
	public bool playFailedEffectOnZeroDamage;
}
