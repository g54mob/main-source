using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct CoinAmountCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int Value;
}
