using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct CollectedAndEnabledSoulsMask : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int Value;

	public bool HasSoulEnabled(SoulID soulID)
	{
		return (Value & (1 << (int)soulID)) != 0;
	}
}
