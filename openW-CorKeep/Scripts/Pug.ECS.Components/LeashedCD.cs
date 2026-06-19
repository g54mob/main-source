using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct LeashedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity leashedToEntity;

	[GhostField]
	public int leashIndex;
}
