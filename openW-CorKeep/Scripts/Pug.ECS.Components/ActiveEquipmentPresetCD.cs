using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ActiveEquipmentPresetCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int Value;
}
