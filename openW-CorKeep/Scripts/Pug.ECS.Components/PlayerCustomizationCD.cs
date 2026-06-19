using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PlayerCustomizationCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public PlayerCustomizationNetcode customization;

	[GhostField]
	public int triggerCount;
}
