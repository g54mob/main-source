using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MerchantCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool hasNewItems;

	public int previousAmountOfItems;
}
